using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
	// Token: 0x02000070 RID: 112
	public partial class JoinElementsForm : System.Windows.Forms.Form
	{
		// Token: 0x06000269 RID: 617 RVA: 0x00027480 File Offset: 0x00025680
		public JoinElementsForm(Document _doc)
		{
			this.InitializeComponent();
			this.doc = _doc;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.JapaneseUI();
			}
			this.radioButtonAView.Checked = true;
			this.radioButtonGeometry.Checked = true;
			base.CancelButton = this.buttonClose;
			base.MaximizeBox = false;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0002755C File Offset: 0x0002575C
		private void JoinElementsForm_Load(object sender, EventArgs e)
		{
			string name = "Structural Columns";
			string name2 = "Structural Framing";
			string name3 = "Structural Foundation";
			string name4 = "Floors";
			string name5 = "Walls";
			string name6 = "Generic Model";
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				name = "構造柱";
				name2 = "構造梁";
				name3 = "構造基礎";
				name4 = "床";
				name5 = "壁";
				name6 = "一般モデル";
			}
			var dataSource = new[]
			{
				new
				{
					Name = name,
					Value = this.filterSColumns
				},
				new
				{
					Name = name2,
					Value = this.filterSFraming
				},
				new
				{
					Name = name3,
					Value = this.filterSFoundation
				},
				new
				{
					Name = name4,
					Value = this.filterFloors
				},
				new
				{
					Name = name5,
					Value = this.filterWalls
				},
				new
				{
					Name = name6,
					Value = this.filterSGeneric
				}
			};
			var dataSource2 = new[]
			{
				new
				{
					Name = name,
					Value = this.filterSColumns
				},
				new
				{
					Name = name2,
					Value = this.filterSFraming
				},
				new
				{
					Name = name3,
					Value = this.filterSFoundation
				},
				new
				{
					Name = name4,
					Value = this.filterFloors
				},
				new
				{
					Name = name5,
					Value = this.filterWalls
				},
				new
				{
					Name = name6,
					Value = this.filterSGeneric
				}
			};
			this.comboBoxTop.DataSource = dataSource;
			this.comboBoxTop.DisplayMember = "Name";
			this.comboBoxTop.ValueMember = "Value";
			this.comboBoxBottom.DataSource = dataSource2;
			this.comboBoxBottom.DisplayMember = "Name";
			this.comboBoxBottom.ValueMember = "Value";
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00027704 File Offset: 0x00025904
		private void JapaneseUI()
		{
			this.Text = "結合";
			this.buttonJoin.Text = "結合する";
			this.buttonClose.Text = "閉じる";
			this.labelTop.Text = "優先度：高↑";
			this.labelBottom.Text = "優先度：低↓";
			this.radioButtonAll.Text = "すべてのビュー";
			this.radioButtonAView.Text = "アクティブビュー";
			this.groupBoxElements.Text = "要素";
			this.groupBoxIntersection.Text = "交差点タイプ（オプション）";
			this.radioButtonGeometry.Text = "ジオメトリ";
			this.radioButtonBoundingBox.Text = "境界ボックス";
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000277BC File Offset: 0x000259BC
		private void buttonJoin_Click(object sender, EventArgs e)
		{
			View activeView = this.doc.ActiveView;
			ElementCategoryFilter elementCategoryFilter = this.comboBoxTop.SelectedValue as ElementCategoryFilter;
			ElementCategoryFilter elementCategoryFilter2 = this.comboBoxBottom.SelectedValue as ElementCategoryFilter;
			if (elementCategoryFilter == null || elementCategoryFilter2 == null)
			{
				RevitTaskDialog.Show("Error", "Categories are failed to get");
				base.Close();
			}
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc).WhereElementIsNotElementType().WherePasses(elementCategoryFilter);
			if (this.radioButtonAView.Checked)
			{
				filteredElementCollector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id).WhereElementIsNotElementType().WherePasses(elementCategoryFilter);
			}
			using (Transaction transaction = new Transaction(this.doc))
			{
				transaction.Start("Join Elements");
				foreach (Element element in filteredElementCollector)
				{
					try
					{
						FilteredElementCollector filteredElementCollector2 = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id);
						if (!this.radioButtonAView.Checked)
						{
							filteredElementCollector2 = new FilteredElementCollector(this.doc);
						}
						filteredElementCollector2.WhereElementIsNotElementType().WherePasses(elementCategoryFilter2);
						BoundingBoxXYZ boundingBoxXYZ = element.get_BoundingBox(this.doc.ActiveView);
						Outline outline = new Outline(boundingBoxXYZ.Min, boundingBoxXYZ.Max);
						outline.Scale(1.0);
						BoundingBoxIntersectsFilter boundingBoxIntersectsFilter = new BoundingBoxIntersectsFilter(outline);
						filteredElementCollector2.Excluding(new List<ElementId>
						{
							element.Id
						}).WherePasses(boundingBoxIntersectsFilter);
						if (this.radioButtonGeometry.Checked)
						{
							Solid solid;
							if (element is FamilyInstance)
							{
								solid = Utils.SolidOfInstanceUnionOriginal(element, activeView);
							}
							else
							{
								solid = Utils.SolidOfElementUnion(element, activeView);
							}
							if (solid == null)
							{
								continue;
							}
							ElementIntersectsSolidFilter elementIntersectsSolidFilter = new ElementIntersectsSolidFilter(solid);
							filteredElementCollector2.WherePasses(elementIntersectsSolidFilter);
						}
						foreach (Element element2 in filteredElementCollector2)
						{
							try
							{
								if (!JoinGeometryUtils.AreElementsJoined(this.doc, element, element2))
								{
									JoinGeometryUtils.JoinGeometry(this.doc, element, element2);
								}
								if (!JoinGeometryUtils.IsCuttingElementInJoin(this.doc, element, element2))
								{
									JoinGeometryUtils.SwitchJoinOrder(this.doc, element, element2);
								}
							}
							catch (Exception)
							{
							}
						}
					}
					catch (Exception)
					{
					}
				}
				transaction.Commit();
			}
			base.Close();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040001B2 RID: 434
		private Document doc;

		// Token: 0x040001B3 RID: 435
		private ElementCategoryFilter filterWalls = new ElementCategoryFilter(BuiltInCategory.OST_Walls);

		// Token: 0x040001B4 RID: 436
		private ElementCategoryFilter filterFloors = new ElementCategoryFilter(BuiltInCategory.OST_Floors);

		// Token: 0x040001B5 RID: 437
		private ElementCategoryFilter filterSFraming = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);

		// Token: 0x040001B6 RID: 438
		private ElementCategoryFilter filterSColumns = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);

		// Token: 0x040001B7 RID: 439
		private ElementCategoryFilter filterSFoundation = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation);

		// Token: 0x040001B8 RID: 440
		private ElementCategoryFilter filterSGeneric = new ElementCategoryFilter(BuiltInCategory.OST_GenericModel);
	}
}

