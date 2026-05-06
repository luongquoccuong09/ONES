using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
	// Token: 0x02000074 RID: 116
	public partial class TestForm : System.Windows.Forms.Form
	{
		// Token: 0x0600027A RID: 634 RVA: 0x000285F8 File Offset: 0x000267F8
		public TestForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = _uidoc.Document;
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
					ListViewItem listViewItem = new ListViewItem(items);
					listViewItem.Tag = parameterFilterElement;
					this.listView1.Items.Add(listViewItem);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000023A6 File Offset: 0x000005A6
		private void TestForm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000286BC File Offset: 0x000268BC
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				ParameterFilterElement parameterFilterElement = null;
				ListView.SelectedListViewItemCollection selectedItems = this.listView1.SelectedItems;
				foreach (object obj in selectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					parameterFilterElement = (listViewItem.Tag as ParameterFilterElement);
					TaskDialog.Show("Filter Element", parameterFilterElement.Name);
				}
				if (parameterFilterElement != null)
				{
					ElementFilter elementFilter = parameterFilterElement.GetElementFilter();
					FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc).WhereElementIsNotElementType().WherePasses(elementFilter);
					foreach (Element element in filteredElementCollector)
					{
						string[] items = new string[]
						{
							element.Name
						};
						ListViewItem listViewItem2 = new ListViewItem(items);
						listViewItem2.Tag = element;
						this.listView2.Items.Add(listViewItem2);
					}
				}
			}
			catch (Exception ex)
			{
				TaskDialog.Show("Error", ex.Message);
			}
		}

		// Token: 0x040001C9 RID: 457
		private UIDocument uidoc;

		// Token: 0x040001CA RID: 458
		private Document doc;
	}
}

