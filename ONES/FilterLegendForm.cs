using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;

namespace ONES
{
	// Token: 0x02000027 RID: 39
	public partial class FilterLegendForm : System.Windows.Forms.Form
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x000130B8 File Offset: 0x000112B8
		public FilterLegendForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.groupBoxView.Text = "凡例ビュー";
				this.groupBoxSize.Text = "凡例の大きさ";
				this.groupBoxText.Text = "使用する文字タイプ";
				this.groupBoxFilter.Text = "フィルター";
				this.buttonCheck.Text = "すべて選択";
				this.buttonUncheck.Text = "選択解除";
			}
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00013188 File Offset: 0x00011388
		private void FilterLegendForm_Load(object sender, EventArgs e)
		{
			this.view = this.uidoc.ActiveView;
			List<View> list = (from View x in new FilteredElementCollector(this.doc).OfCategory((BuiltInCategory)(-2000279)).WhereElementIsNotElementType()
                               where (int)x.ViewType == 11
                               select x).ToList<View>();
			list.Sort((View x, View y) => string.Compare(x.Name, y.Name));
			this.comboBoxView.DataSource = list;
			this.comboBoxView.DisplayMember = "Name";
			List<Element> list2 = new FilteredElementCollector(this.doc).OfClass(typeof(TextNoteType)).ToList<Element>();
			list2.Sort((Element x, Element y) => string.Compare(x.Name, y.Name));
			this.comboBoxText.DataSource = list2;
			this.comboBoxText.DisplayMember = "Name";
			this.viewfilters = new List<Element>();
			foreach (ElementId elementId in this.view.GetFilters())
			{
				try
				{
					Element element = this.doc.GetElement(elementId);
					this.viewfilters.Add(element);
				}
				catch (Exception)
				{
				}
			}
			this.checkedListBoxFilters.DataSource = this.viewfilters;
			this.checkedListBoxFilters.DisplayMember = "Name";
			for (int i = 0; i < this.checkedListBoxFilters.Items.Count; i++)
			{
				this.checkedListBoxFilters.SetItemChecked(i, true);
			}
			this.textBoxWidth.Text = "10";
			this.textBoxHeight.Text = "5";
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00013374 File Offset: 0x00011574
		private void buttonCheck_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.checkedListBoxFilters.Items.Count; i++)
			{
				this.checkedListBoxFilters.SetItemChecked(i, true);
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000133AC File Offset: 0x000115AC
		private void buttonUncheck_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.checkedListBoxFilters.Items.Count; i++)
			{
				this.checkedListBoxFilters.SetItemChecked(i, false);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000133E4 File Offset: 0x000115E4
		private void buttonOK_Click(object sender, EventArgs e)
		{
			using (Transaction transaction = new Transaction(this.doc, "Filled Region"))
			{
				transaction.Start();
				double num = Utils.UnitMilimeterToFeet(Convert.ToDouble(this.textBoxWidth.Text));
				double num2 = Utils.UnitMilimeterToFeet(Convert.ToDouble(this.textBoxHeight.Text));
				double num3 = Utils.UnitMilimeterToFeet(5.0);
				FilteredElementCollector source = new FilteredElementCollector(this.doc).OfClass(typeof(FilledRegionType));
				FilledRegionType filledRegionType = source.FirstOrDefault<Element>() as FilledRegionType;
				ElementId id = source.FirstOrDefault<Element>().Id;
				Element element = this.comboBoxText.SelectedItem as Element;
				View view = this.comboBoxView.SelectedItem as View;
				List<Element> list = this.checkedListBoxFilters.CheckedItems.OfType<Element>().ToList<Element>();
				XYZ xyz = new XYZ();
				foreach (Element element2 in list)
				{
					List<Curve> list2 = Utils.RectangleCurves(xyz, num, num2);
					CurveLoop item = CurveLoop.Create(list2);
					OverrideGraphicSettings filterOverrides = this.view.GetFilterOverrides(element2.Id);
					string text = this.view.Name + "_" + element2.Name;
					text = text.Replace(':', '_').Replace('/', '_').Replace('?', '_').Replace('*', '_').Replace('[', '_').Replace(']', '_').Replace('\\', '_').Replace('{', '_').Replace('}', '_');
					if (this.checkBoxForeground.Checked)
					{
						FilledRegionType filledRegionType2 = filledRegionType.Duplicate(text) as FilledRegionType;
						filledRegionType2.ForegroundPatternColor = filterOverrides.SurfaceForegroundPatternColor;
						filledRegionType2.ForegroundPatternId = filterOverrides.SurfaceForegroundPatternId;
						FilledRegion.Create(this.doc, filledRegionType2.Id, view.Id, new List<CurveLoop>
						{
							item
						});
						xyz += new XYZ(num + num3, 0.0, 0.0);
					}
					if (this.checkBoxBackground.Checked)
					{
						FilledRegionType filledRegionType3 = filledRegionType.Duplicate(text) as FilledRegionType;
						filledRegionType3.BackgroundPatternColor = filterOverrides.SurfaceBackgroundPatternColor;
						filledRegionType3.BackgroundPatternId = filterOverrides.CutBackgroundPatternId;
						FilledRegion.Create(this.doc, filledRegionType3.Id, view.Id, new List<CurveLoop>
						{
							item
						});
						xyz += new XYZ(num + num3, 0.0, 0.0);
					}
					XYZ xyz2 = new XYZ(xyz.X, xyz.Y - num2 / 2.0, xyz.Z);
					TextNote.Create(this.doc, view.Id, xyz2, this.view.Name + "_" + element2.Name, element.Id);
					xyz = new XYZ(0.0, xyz.Y - num2 * 3.0 / 2.0, 0.0);
				}
				transaction.Commit();
			}
			base.Close();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00013778 File Offset: 0x00011978
		private FilledRegionType FilledRegionMake(FilledRegionType regionType, string name, OverrideGraphicSettings overrideGraphic)
		{
			FilledRegionType filledRegionType = regionType.Duplicate(name) as FilledRegionType;
			filledRegionType.ForegroundPatternColor = overrideGraphic.SurfaceForegroundPatternColor;
			filledRegionType.ForegroundPatternId = overrideGraphic.SurfaceForegroundPatternId;
			return filledRegionType;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000137AC File Offset: 0x000119AC
		private void buttonUp_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.checkedListBoxFilters.SelectedIndex;
			if (selectedIndex > 0)
			{
				this.viewfilters.Insert(selectedIndex - 1, this.viewfilters[selectedIndex]);
				this.viewfilters.RemoveAt(selectedIndex + 1);
				this.checkedListBoxFilters.SelectedIndex = selectedIndex - 1;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00013800 File Offset: 0x00011A00
		private void buttonDown_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.checkedListBoxFilters.SelectedIndex;
			if (selectedIndex < this.checkedListBoxFilters.Items.Count - 1 & selectedIndex != -1)
			{
				this.viewfilters.Insert(selectedIndex + 2, this.viewfilters[selectedIndex]);
				this.viewfilters.RemoveAt(selectedIndex);
				this.checkedListBoxFilters.SelectedIndex = selectedIndex + 1;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040000B8 RID: 184
		private UIDocument uidoc;

		// Token: 0x040000B9 RID: 185
		private Document doc;

		// Token: 0x040000BA RID: 186
		private View view;

		// Token: 0x040000BB RID: 187
		private List<Element> viewfilters;
	}
}



