using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
	// Token: 0x02000016 RID: 22
	public partial class TimelinerForm : System.Windows.Forms.Form
	{
		// Token: 0x06000061 RID: 97 RVA: 0x0000B0E1 File Offset: 0x000092E1
		public TimelinerForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			base.MaximizeBox = false;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000B10E File Offset: 0x0000930E
		private void TimelinerForm_Load(object sender, EventArgs e)
		{
			this.radioButtonCategory.Checked = true;
			this.textBoxCategory.Text = "1000";
			this.textBoxElement.Text = "20";
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000B13C File Offset: 0x0000933C
		private void buttonOk_Click(object sender, EventArgs e)
		{
			View activeView = this.uidoc.ActiveView;
			base.Hide();
			FilteredElementCollector source = new FilteredElementCollector(this.doc).OfClass(typeof(Level));
			List<ICollection<ElementId>> list = new List<ICollection<ElementId>>();
			IEnumerable<Level> enumerable = from Level lvl in source
			orderby lvl.Elevation
			select lvl;
			foreach (Level level in enumerable)
			{
				TimelinerForm.AddInstancesOnLevelToIdGroupList(list, level, BuiltInCategory.OST_StructuralFoundation);
				TimelinerForm.AddInstancesOnReferenceLevelToIdGroupList(list, level, BuiltInCategory.OST_StructuralFraming);
				TimelinerForm.AddInstancesOnLevelToIdGroupList(list, level, BuiltInCategory.OST_Floors);
				TimelinerForm.AddInstancesOnLevelToIdGroupList(list, level, BuiltInCategory.OST_StructuralColumns);
				TimelinerForm.AddInstancesOnLevelToIdGroupList(list, level, BuiltInCategory.OST_Walls);
			}
			using (TransactionGroup transactionGroup = new TransactionGroup(this.doc))
			{
				transactionGroup.Start("Animation");
				using (Transaction transaction = new Transaction(this.doc, "Animation"))
				{
					transaction.Start();
					List<ICollection<ElementId>> list2 = new List<ICollection<ElementId>>
					{
						TimelinerForm.CollectorCategory(this.doc, activeView, BuiltInCategory.OST_StructuralFoundation),
						TimelinerForm.CollectorCategory(this.doc, activeView, BuiltInCategory.OST_StructuralFraming),
						TimelinerForm.CollectorCategory(this.doc, activeView, BuiltInCategory.OST_Floors),
						TimelinerForm.CollectorCategory(this.doc, activeView, BuiltInCategory.OST_StructuralColumns),
						TimelinerForm.CollectorCategory(this.doc, activeView, BuiltInCategory.OST_Walls)
					};
					foreach (ICollection<ElementId> collection in list2)
					{
						try
						{
							if (collection.Count > 0)
							{
								activeView.HideElements(collection);
							}
						}
						catch (Exception)
						{
						}
					}
					this.uidoc.RefreshActiveView();
					transaction.Commit();
					Thread.Sleep(500);
					string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					string text = Path.Combine(folderPath, "Timeliner");
					Directory.CreateDirectory(text);
					ImageExportOptions imageExportOptions = new ImageExportOptions();
					imageExportOptions.ZoomType = ZoomFitType.FitToPage;
					imageExportOptions.PixelSize = 1024;
					imageExportOptions.ImageResolution = ImageResolution.DPI_600;
					imageExportOptions.FitDirection = FitDirectionType.Vertical;
					imageExportOptions.ExportRange = ExportRange.CurrentView;
					imageExportOptions.HLRandWFViewsFileType = ImageFileType.PNG;
					imageExportOptions.ShadowViewsFileType = ImageFileType.PNG;
					int num = 0;
					if (this.radioButtonCategory.Checked)
					{
						int millisecondsTimeout;
						if (!int.TryParse(this.textBoxCategory.Text, out millisecondsTimeout))
						{
							RevitTaskDialog.Show("Input Error", "Please input number as millisecond");
							goto IL_432;
						}
						using (List<ICollection<ElementId>>.Enumerator enumerator3 = list.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								ICollection<ElementId> collection2 = enumerator3.Current;
								transaction.Start();
								activeView.UnhideElements(collection2);
								this.uidoc.RefreshActiveView();
								Thread.Sleep(millisecondsTimeout);
								transaction.Commit();
								if (this.checkBoxExport.Checked)
								{
									string filePath = Path.Combine(folderPath, text, num.ToString("D4"));
									imageExportOptions.FilePath = filePath;
									this.doc.ExportImage(imageExportOptions);
									num++;
								}
							}
							goto IL_432;
						}
					}
					if (this.radioButtonElement.Checked)
					{
						int millisecondsTimeout2;
						if (!int.TryParse(this.textBoxElement.Text, out millisecondsTimeout2))
						{
							RevitTaskDialog.Show("Input Error", "Please input only number");
						}
						else
						{
							foreach (ICollection<ElementId> collection3 in list)
							{
								foreach (ElementId item in collection3)
								{
									transaction.Start();
									activeView.UnhideElements(new List<ElementId>
									{
										item
									});
									this.uidoc.RefreshActiveView();
									Thread.Sleep(millisecondsTimeout2);
									transaction.Commit();
									if (this.checkBoxExport.Checked)
									{
										string filePath2 = Path.Combine(folderPath, text, num.ToString("D4"));
										imageExportOptions.FilePath = filePath2;
										this.doc.ExportImage(imageExportOptions);
										num++;
									}
								}
							}
						}
					}
				}
				IL_432:
				transactionGroup.Assimilate();
			}
			base.Close();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000B65C File Offset: 0x0000985C
		private static void AddInstancesOnLevelToIdGroupList(List<ICollection<ElementId>> idGroupsInOrder, Level level, BuiltInCategory category)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(level.Document);
			filteredElementCollector.WherePasses(new ElementLevelFilter(level.Id));
			filteredElementCollector.OfCategory(category);
			filteredElementCollector.WhereElementIsNotElementType();
			ICollection<ElementId> collection = filteredElementCollector.ToElementIds();
			if (collection.Count > 0)
			{
				idGroupsInOrder.Add(collection);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000B6B0 File Offset: 0x000098B0
		private static void AddInstancesOnReferenceLevelToIdGroupList(List<ICollection<ElementId>> idGroupsInOrder, Level level, BuiltInCategory category)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(level.Document);
			filteredElementCollector.OfCategory(category);
			filteredElementCollector.WhereElementIsNotElementType();
			FilterRule filterRule = ParameterFilterRuleFactory.CreateEqualsRule(new ElementId(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM), level.Id);
			filteredElementCollector.WherePasses(new ElementParameterFilter(filterRule));
			ICollection<ElementId> collection = filteredElementCollector.ToElementIds();
			if (collection.Count > 0)
			{
				idGroupsInOrder.Add(collection);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000B714 File Offset: 0x00009914
		private static ICollection<ElementId> CollectorCategory(Document doc, View view, BuiltInCategory category)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(doc, view.Id);
			filteredElementCollector.OfCategory(category);
			filteredElementCollector.WhereElementIsNotElementType();
			return filteredElementCollector.ToElementIds();
		}

		// Token: 0x04000054 RID: 84
		private UIDocument uidoc;

		// Token: 0x04000055 RID: 85
		private Document doc;
	}
}



