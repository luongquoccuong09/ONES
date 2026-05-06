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
	// Token: 0x0200007E RID: 126
	public partial class PurgeForm : System.Windows.Forms.Form
	{
		// Token: 0x060002CD RID: 717 RVA: 0x0002B810 File Offset: 0x00029A10
		public PurgeForm(UIApplication uiapp, List<Element> _elementsForm)
		{
			this.InitializeComponent();
			this.uidoc = uiapp.ActiveUIDocument;
			this.doc = this.uidoc.Document;
			this.elementsForm = _elementsForm;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.JapaneseUI();
			}
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0002B89C File Offset: 0x00029A9C
		private void _PurgeForm_Load(object sender, EventArgs e)
		{
			this.listView1.Items.Clear();
			this.labelCount.Text = "Count: " + this.elementsForm.Count.ToString();
			foreach (Element element in this.elementsForm)
			{
				try
				{
					string text = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					try
					{
						text = this.doc.GetElement(element.OwnerViewId).Name;
					}
					catch (Exception)
					{
					}
					try
					{
						text2 = element.Category.Name;
					}
					catch (Exception)
					{
					}
					try
					{
						text3 = element.Name;
					}
					catch (Exception)
					{
					}
					try
					{
						text4 = element.Id.ToString();
					}
					catch (Exception)
					{
					}
					try
					{
						text5 = element.OwnerViewId.ToString();
					}
					catch (Exception)
					{
					}
					string[] items = new string[]
					{
						text2,
						text3,
						text4,
						text5,
						text
					};
					ListViewItem listViewItem = new ListViewItem(items);
					listViewItem.Tag = element;
					this.listView1.Items.Add(listViewItem);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0002BA3C File Offset: 0x00029C3C
		private void JapaneseUI()
		{
			this.buttonPurge.Text = "パージ";
			this.buttonShow.Text = "表示";
			this.buttonSA.Text = "全て選択";
			this.buttonSN.Text = "選択を解除";
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0002BA8C File Offset: 0x00029C8C
		private void buttonPurge_Click(object sender, EventArgs e)
		{
			using (Transaction transaction = new Transaction(this.doc))
			{
				transaction.Start("Purge");
				ListView.CheckedListViewItemCollection checkedItems = this.listView1.CheckedItems;
				foreach (object obj in checkedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					try
					{
						Element element = listViewItem.Tag as Element;
						this.doc.Delete(element.Id);
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
				}
				transaction.Commit();
			}
			base.Close();
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0002BB64 File Offset: 0x00029D64
		private void buttonSA_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = true;
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0002BBA4 File Offset: 0x00029DA4
		private void buttonSN_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = false;
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0002BBE4 File Offset: 0x00029DE4
		private void buttonShow_Click(object sender, EventArgs e)
		{
			ListView.CheckedListViewItemCollection checkedItems = this.listView1.CheckedItems;
			IList<ElementId> list = new List<ElementId>();
			foreach (object obj in checkedItems)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				try
				{
					Element element = listViewItem.Tag as Element;
					list.Add(element.Id);
				}
				catch (Exception ex)
				{
					Debug.Print(ex.Message);
				}
			}
			try
			{
				this.uidoc.ShowElements(list);
				this.uidoc.Selection.SetElementIds(list);
			}
			catch (Exception ex2)
			{
				Autodesk.Revit.UI.TaskDialog.Show("Error", ex2.Message);
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x04000208 RID: 520
		private Document doc;

		// Token: 0x04000209 RID: 521
		private UIDocument uidoc;

		// Token: 0x0400020A RID: 522
		private List<Element> elementsForm = new List<Element>();
	}
}

