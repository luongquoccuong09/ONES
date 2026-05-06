using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ONES.Properties;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
	// Token: 0x0200008F RID: 143
	public partial class HealthCheckForm : System.Windows.Forms.Form
	{
		// Token: 0x06000362 RID: 866 RVA: 0x00034E88 File Offset: 0x00033088
		public HealthCheckForm(UIApplication _uiapp)
		{
			this.InitializeComponent();
			this.uiapp = _uiapp;
			this.uidoc = this.uiapp.ActiveUIDocument;
			Autodesk.Revit.ApplicationServices.Application application = this.uiapp.Application;
			this.doc = this.uidoc.Document;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.labelDevelopment.Text = "作業中";
			}
			base.MaximizeBox = false;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00034F18 File Offset: 0x00033118
		private void HealthCheckForm_Load(object sender, EventArgs e)
		{
			double num = (double)this.FileSize(0.1);
			double factor = 10.0 / num;
			this.Warnings(factor);
			this.WarningElements(5.0 / num);
			this.InPlace(30.0 / num);
			this.CADImport(40.0 / num);
			this.TotalViews(10.0 / num);
			this.UnusedFilters(20.0 / num);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00034FA4 File Offset: 0x000331A4
		private void UpdateEmoji(PictureBox pictureBox, int score)
		{
			if (score <= 10)
			{
				pictureBox.Image = Resources._10_96;
				return;
			}
			if (score <= 20)
			{
				pictureBox.Image = Resources._20_96;
				return;
			}
			if (score <= 30)
			{
				pictureBox.Image = Resources._30_96;
				return;
			}
			if (score <= 40)
			{
				pictureBox.Image = Resources._40_96;
				return;
			}
			if (score <= 50)
			{
				pictureBox.Image = Resources._50_96;
				return;
			}
			if (score <= 60)
			{
				pictureBox.Image = Resources._60_96;
				return;
			}
			if (score <= 70)
			{
				pictureBox.Image = Resources._70_96;
				return;
			}
			if (score <= 80)
			{
				pictureBox.Image = Resources._80_96;
				return;
			}
			if (score <= 90)
			{
				pictureBox.Image = Resources._90_96;
				return;
			}
			if (score > 90)
			{
				pictureBox.Image = Resources._100_96;
			}
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0003505A File Offset: 0x0003325A
		private int Score(int count, double factor)
		{
			return 100 - Convert.ToInt32((double)count * factor);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00035068 File Offset: 0x00033268
		private int Warnings(double factor)
		{
			int count = this.doc.GetWarnings().Count;
			this.labelCountWarnings.Text = count.ToString();
			int num = this.Score(count, factor);
			this.UpdateEmoji(this.pictureBoxWarnings, num);
			return num;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000350B0 File Offset: 0x000332B0
		private int WarningElements(double factor)
		{
			IList<FailureMessage> warnings = this.doc.GetWarnings();
			HashSet<ElementId> hashSet = new HashSet<ElementId>();
			foreach (FailureMessage failureMessage in warnings)
			{
				ICollection<ElementId> failingElements = failureMessage.GetFailingElements();
				foreach (ElementId item in failingElements)
				{
					hashSet.Add(item);
				}
			}
			int count = hashSet.Count;
			this.labelCountWarningElements.Text = count.ToString();
			int num = this.Score(count, factor);
			this.UpdateEmoji(this.pictureBoxWarningElements, num);
			return num;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00035184 File Offset: 0x00033384
		private int InPlace(double factor)
		{
			List<Family> list = (from Family x in new FilteredElementCollector(this.doc).OfClass(typeof(Family))
			where x.IsInPlace
			select x).ToList<Family>();
			int count = list.Count;
			this.labelCountInPlace.Text = count.ToString();
			int num = this.Score(count, factor);
			this.UpdateEmoji(this.pictureBoxInPlace, num);
			return num;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0003520C File Offset: 0x0003340C
		private int CADImport(double factor)
		{
			List<ImportInstance> list = (from ImportInstance i in new FilteredElementCollector(this.doc).OfClass(typeof(ImportInstance))
			where !i.IsLinked
			select i).ToList<ImportInstance>();
			list.RemoveAll((ImportInstance item) => item == null);
			int count = list.Count;
			this.labelCountCAD.Text = count.ToString();
			int num = this.Score(count, factor);
			this.UpdateEmoji(this.pictureBoxCAD, num);
			return num;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000352B8 File Offset: 0x000334B8
		private int FileSize(double factor)
		{
			string fileName = Utils.LocalFilePath(this.uiapp);
			long length = new FileInfo(fileName).Length;
			int num = Convert.ToInt32(length / 1024L / 1024L);
			this.labelCountFileSize.Text = num.ToString() + " MB";
			int score = this.Score(num, factor);
			this.UpdateEmoji(this.pictureBoxFileSize, score);
			return num;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00035328 File Offset: 0x00033528
		private int TotalViews(double factor)
		{
			int count = this.doc.GetWarnings().Count;
			this.labelCountWarnings.Text = count.ToString();
			int num = this.Score(count, factor);
			this.UpdateEmoji(this.pictureBoxTotalViews, num);
			return num;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00035370 File Offset: 0x00033570
		private int UnusedFilters(double factor)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc).OfCategory(BuiltInCategory.OST_Views);
			ICollection<ElementId> collection = new FilteredElementCollector(this.doc).OfClass(typeof(ParameterFilterElement)).ToElementIds();
			foreach (Element element in filteredElementCollector)
			{
				View view = (View)element;
				foreach (ElementId item in view.GetFilters())
				{
					collection.Remove(item);
				}
			}
			int count = collection.Count;
			this.labelCountFilters.Text = count.ToString();
			int num = this.Score(count, factor);
			this.UpdateEmoji(this.pictureBoxFilters, num);
			return num;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00035468 File Offset: 0x00033668
		private int PerformanceAdvisor(double factor)
		{
			IList<FailureMessage> list = PerformanceAdviser.GetPerformanceAdviser().ExecuteAllRules(this.doc);
			HashSet<ElementId> hashSet = new HashSet<ElementId>();
			foreach (FailureMessage failureMessage in list)
			{
				foreach (ElementId item in failureMessage.GetFailingElements())
				{
					hashSet.Add(item);
				}
			}
			int count = hashSet.Count;
			this.labelCountPerAdvisor.Text = count.ToString();
			int num = this.Score(count, factor);
			this.UpdateEmoji(this.pictureBoxPerAdvisor, num);
			return num;
		}

		// Token: 0x04000267 RID: 615
		private UIApplication uiapp;

		// Token: 0x04000268 RID: 616
		private UIDocument uidoc;

		// Token: 0x04000269 RID: 617
		private Document doc;
	}
}

