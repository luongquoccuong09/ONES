using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
	// Token: 0x0200006C RID: 108
	public partial class FilterRevitForm : System.Windows.Forms.Form
	{
		// Token: 0x0600025D RID: 605 RVA: 0x00026C90 File Offset: 0x00024E90
		public FilterRevitForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = _uidoc.Document;
			base.CancelButton = this.buttonClose;
			base.AcceptButton = this.buttonSelect;
			base.MaximizeBox = false;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00026CD0 File Offset: 0x00024ED0
		private void SelectFilterForm_Load(object sender, EventArgs e)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc).OfClass(typeof(ParameterFilterElement));
			foreach (Element element in filteredElementCollector)
			{
				ParameterFilterElement parameterFilterElement = (ParameterFilterElement)element;
				try
				{
					string[] items = new string[]
					{
						parameterFilterElement.Name
					};
					ListViewItem value = new ListViewItem(items)
					{
						Tag = parameterFilterElement
					};
					this.listView1.Items.Add(value);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000023A6 File Offset: 0x000005A6
		private void buttonShow_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00026D74 File Offset: 0x00024F74
		private void buttonSelect_Click(object sender, EventArgs e)
		{
			try
			{
				ParameterFilterElement parameterFilterElement = null;
				ListView.SelectedListViewItemCollection selectedItems = this.listView1.SelectedItems;
				foreach (object obj in selectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					parameterFilterElement = (listViewItem.Tag as ParameterFilterElement);
				}
				if (parameterFilterElement != null)
				{
					FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc).WhereElementIsNotElementType();
					ElementFilter elementFilter = parameterFilterElement.GetElementFilter();
					ICollection<ElementId> categories = parameterFilterElement.GetCategories();
					List<ElementId> list = new List<ElementId>();
					foreach (ElementId elementId in categories)
					{
						ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(elementId);
						FilteredElementCollector filteredElementCollector2 = new FilteredElementCollector(this.doc).WhereElementIsNotElementType().WherePasses(elementCategoryFilter);
						filteredElementCollector2.WherePasses(elementFilter);
						list.AddRange(filteredElementCollector2.ToElementIds());
					}
					this.uidoc.Selection.SetElementIds(list);
				}
			}
			catch (Exception ex)
			{
				Debug.Print(ex.Message);
			}
			base.Close();
		}

		// Token: 0x040001AB RID: 427
		private UIDocument uidoc;

		// Token: 0x040001AC RID: 428
		private Document doc;
	}
}

