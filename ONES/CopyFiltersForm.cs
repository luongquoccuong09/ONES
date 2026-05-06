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
	// Token: 0x02000084 RID: 132
	public partial class CopyFiltersForm : System.Windows.Forms.Form
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x0002CDFF File Offset: 0x0002AFFF
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x0002CE07 File Offset: 0x0002B007
		public List<Element> ReturnViews { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x0002CE10 File Offset: 0x0002B010
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x0002CE18 File Offset: 0x0002B018
		public List<Element> Returnviewfilters { get; set; }

		// Token: 0x060002E6 RID: 742 RVA: 0x0002CE24 File Offset: 0x0002B024
		public CopyFiltersForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = _uidoc.Document;
			this.view = this.doc.ActiveView;
			this.radioButtonAll.Checked = true;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.JapaneseUI();
			}
			base.CancelButton = this.buttonClose;
			base.MaximizeBox = false;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0002CEC8 File Offset: 0x0002B0C8
		private void CopyFIltersForm_Load(object sender, EventArgs e)
		{
			this.allViews = new FilteredElementCollector(this.doc).OfCategory((BuiltInCategory)(-2000279)).ToElements().ToList<Element>();
			this.allViews.Sort((Element x, Element y) => string.Compare(x.Name, y.Name));
			foreach (UIView uiview in this.uidoc.GetOpenUIViews())
			{
				this.activeViews.Add(this.doc.GetElement(uiview.ViewId));
			}
			List<Element> list = new List<Element>();
			foreach (ElementId elementId in this.view.GetFilters())
			{
				try
				{
					Element element = this.doc.GetElement(elementId);
					list.Add(element);
				}
				catch (Exception)
				{
				}
			}
			this.checkedListBoxViews.DataSource = this.allViews;
			this.checkedListBoxViews.DisplayMember = "Name";
			this.checkedListBoxFilters.DataSource = list;
			this.checkedListBoxFilters.DisplayMember = "Name";
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0002D024 File Offset: 0x0002B224
		private void JapaneseUI()
		{
			this.radioButtonActive.Text = "アクティブビュー";
			this.radioButtonAll.Text = "すべてのビュー";
			this.buttonFiltersSA.Text = "すべて選択";
			this.buttonFiltersSN.Text = "選択解除";
			this.buttonViewsSA.Text = "すべて選択";
			this.buttonViewsSN.Text = "選択解除";
			this.buttonCopy.Text = "コピー";
			this.labelFilters.Text = "フィルタ";
			this.labelViews.Text = "ビュー";
			this.buttonClose.Text = "閉じる";
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0002D0D4 File Offset: 0x0002B2D4
		private void buttonCopy_Click(object sender, EventArgs e)
		{
			OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
			using (Transaction transaction = new Transaction(this.doc))
			{
				transaction.Start("Copy Filters");
				foreach (Element element in this.checkedListBoxViews.CheckedItems.OfType<Element>().ToList<Element>())
				{
					try
					{
						ElementId id = element.Id;
						if (id != this.view.Id)
						{
							View view = this.doc.GetElement(id) as View;
							foreach (Element element2 in this.checkedListBoxFilters.CheckedItems.OfType<Element>().ToList<Element>())
							{
								ElementId id2 = element2.Id;
								overrideGraphicSettings = this.view.GetFilterOverrides(id2);
								try
								{
									view.AddFilter(id2);
								}
								catch (Exception)
								{
								}
								try
								{
									view.SetFilterOverrides(id2, overrideGraphicSettings);
								}
								catch (Exception)
								{
								}
							}
						}
					}
					catch (Exception ex)
					{
						Autodesk.Revit.UI.TaskDialog.Show("Exception", ex.Message);
					}
				}
				transaction.Commit();
			}
			base.Close();
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0002D2B0 File Offset: 0x0002B4B0
		private void buttonFiltersSA_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.checkedListBoxFilters.Items.Count; i++)
			{
				this.checkedListBoxFilters.SetItemChecked(i, true);
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0002D2E8 File Offset: 0x0002B4E8
		private void buttonFiltersSN_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.checkedListBoxFilters.Items.Count; i++)
			{
				this.checkedListBoxFilters.SetItemChecked(i, false);
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0002D320 File Offset: 0x0002B520
		private void buttonViewsSA_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.checkedListBoxViews.Items.Count; i++)
			{
				this.checkedListBoxViews.SetItemChecked(i, true);
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0002D358 File Offset: 0x0002B558
		private void buttonViewsSN_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.checkedListBoxViews.Items.Count; i++)
			{
				this.checkedListBoxViews.SetItemChecked(i, false);
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x000023A6 File Offset: 0x000005A6
		private void checkedListBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0002D38D File Offset: 0x0002B58D
		private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
		{
			this.checkedListBoxViews.DataSource = this.allViews;
			this.checkedListBoxViews.DisplayMember = "Name";
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0002D3B0 File Offset: 0x0002B5B0
		private void radioButtonActive_CheckedChanged(object sender, EventArgs e)
		{
			this.checkedListBoxViews.DataSource = this.activeViews;
			this.checkedListBoxViews.DisplayMember = "Name";
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x04000218 RID: 536
		private Document doc;

		// Token: 0x04000219 RID: 537
		private View view;

		// Token: 0x0400021A RID: 538
		private UIDocument uidoc;

		// Token: 0x0400021B RID: 539
		private List<Element> allViews = new List<Element>();

		// Token: 0x0400021C RID: 540
		private List<Element> activeViews = new List<Element>();
	}
}



