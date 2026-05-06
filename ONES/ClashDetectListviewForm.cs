using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;

namespace ONES
{
	// Token: 0x02000023 RID: 35
	public partial class ClashDetectListviewForm : System.Windows.Forms.Form
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x0001250C File Offset: 0x0001070C
		public ClashDetectListviewForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00012534 File Offset: 0x00010734
		private void ClashDetectionForm_Load(object sender, EventArgs e)
		{
			Selection selection = this.uidoc.Selection;
			ICollection<ElementId> elementIds = selection.GetElementIds();
			if (elementIds.Count == 0)
			{
				Autodesk.Revit.UI.TaskDialog.Show("Revit", "You haven't selected any elements.");
				base.Close();
			}
			foreach (ElementId elementId in elementIds)
			{
				try
				{
					Element element = this.doc.GetElement(elementId);
					FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id).WherePasses(new ElementIntersectsElementFilter(element));
					string[] items = new string[]
					{
						"Selected Element",
						element.Category.Name,
						element.Name,
						elementId.ToString()
					};
					ListViewItem listViewItem = new ListViewItem(items);
					listViewItem.Tag = element;
					this.listViewClash.Items.Add(listViewItem);
					string empty = string.Empty;
					foreach (Element element2 in filteredElementCollector)
					{
						string[] items2 = new string[]
						{
							"Intersecting Element",
							element2.Category.Name,
							element2.Name,
							element2.Id.ToString()
						};
						ListViewItem listViewItem2 = new ListViewItem(items2);
						listViewItem2.Tag = element;
						this.listViewClash.Items.Add(listViewItem2);
					}
					string[] items3 = new string[]
					{
						""
					};
					ListViewItem value = new ListViewItem(items3);
					this.listViewClash.Items.Add(value);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00012738 File Offset: 0x00010938
		private void buttonExport_Click(object sender, EventArgs e)
		{
			Selection selection = this.uidoc.Selection;
			ICollection<ElementId> elementIds = selection.GetElementIds();
			Worksheet worksheet = Utils.ExcelWorksheet("Clash");
			worksheet.Cells[1, 1] = "STATE";
			worksheet.Cells[1, 2] = "CATEGORY";
			worksheet.Cells[1, 3] = "NAME";
			worksheet.Cells[1, 4] = "ID";
			int num = 2;
			foreach (ElementId elementId in elementIds)
			{
				try
				{
					Element element = this.doc.GetElement(elementId);
					BoundingBoxXYZ boundingBoxXYZ = element.get_BoundingBox(this.doc.ActiveView);
					Outline outline = new Outline(boundingBoxXYZ.Min, boundingBoxXYZ.Max);
					outline.Scale(0.99);
					BoundingBoxIntersectsFilter boundingBoxIntersectsFilter = new BoundingBoxIntersectsFilter(outline);
					FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id);
					filteredElementCollector.Excluding(new List<ElementId>
					{
						element.Id
					}).WherePasses(boundingBoxIntersectsFilter);
					num++;
					worksheet.Cells[num, 1] = "Selected Element";
					worksheet.Cells[num, 2] = element.Category.Name;
					worksheet.Cells[num, 3] = element.Name;
					worksheet.Cells[num, 4] = elementId;
					num++;
					string empty = string.Empty;
					foreach (Element element2 in filteredElementCollector)
					{
						worksheet.Cells[num, 1] = "Intersected Element";
						worksheet.Cells[num, 2] = element2.Category.Name;
						worksheet.Cells[num, 3] = element2.Name;
						worksheet.Cells[num, 4] = element2.Id;
						num++;
					}
				}
				catch (Exception)
				{
				}
			}
			Utils.ExcelTitleStyle(worksheet);
		}

		// Token: 0x040000AF RID: 175
		private UIDocument uidoc;

		// Token: 0x040000B0 RID: 176
		private Document doc;
	}
}

