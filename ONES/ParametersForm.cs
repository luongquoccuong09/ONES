using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
	// Token: 0x02000029 RID: 41
	public partial class ParametersForm : System.Windows.Forms.Form
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x00014DA8 File Offset: 0x00012FA8
		public ParametersForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00014DC0 File Offset: 0x00012FC0
		private void ParametersForm_Load(object sender, EventArgs e)
		{
			Document document = this.uidoc.Document;
			Selection selection = this.uidoc.Selection;
			Element element = document.GetElement(selection.GetElementIds().First<ElementId>());
			ParameterSet parameters = element.Parameters;
			foreach (object obj in parameters)
			{
				Parameter parameter = (Parameter)obj;
				string[] items = new string[]
				{
					parameter.Definition.Name
				};
				ListViewItem listViewItem = new ListViewItem(items);
				listViewItem.Tag = parameter;
				this.listView1.Items.Add(listViewItem);
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00014E84 File Offset: 0x00013084
		private void buttonOk_Click(object sender, EventArgs e)
		{
			Document document = this.uidoc.Document;
			Selection selection = this.uidoc.Selection;
			ListView.SelectedListViewItemCollection selectedItems = this.listView1.SelectedItems;
			using (Transaction transaction = new Transaction(document, "Input Parameter"))
			{
				transaction.Start();
				foreach (object obj in selectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					Parameter parameter = listViewItem.Tag as Parameter;
					string name = parameter.Definition.Name;
					foreach (ElementId elementId in selection.GetElementIds())
					{
						try
						{
							Element element = document.GetElement(elementId);
							Parameter parameter2 = element.GetParameters(name).First<Parameter>();
							parameter2.Set(elementId.ToString());
						}
						catch (Exception)
						{
						}
					}
				}
				transaction.Commit();
			}
			base.Close();
		}

		// Token: 0x040000DF RID: 223
		private UIDocument uidoc;
	}
}

