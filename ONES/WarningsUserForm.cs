using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000068 RID: 104
	public partial class WarningsUserForm : System.Windows.Forms.Form
	{
		// Token: 0x06000251 RID: 593 RVA: 0x00026195 File Offset: 0x00024395
		public WarningsUserForm(Document _doc)
		{
			this.InitializeComponent();
			this.doc = _doc;
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000261C8 File Offset: 0x000243C8
		private void WarningsUserForm_Load(object sender, EventArgs e)
		{
			this.warnings = this.doc.GetWarnings();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (FailureMessage failureMessage in this.warnings)
			{
				try
				{
					ICollection<ElementId> failingElements = failureMessage.GetFailingElements();
					foreach (ElementId elementId in failingElements)
					{
						try
						{
							WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(this.doc, elementId);
							string creator = worksharingTooltipInfo.Creator;
							try
							{
								hashSet.Add(creator);
							}
							catch (Exception)
							{
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
			IList<string> list = new List<string>();
			foreach (string item in hashSet)
			{
				list.Add(item);
			}
			this.comboBoxUsers.DataSource = list;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0002630C File Offset: 0x0002450C
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.comboBoxUsers.SelectedItem != null)
			{
				List<ElementId> list = new List<ElementId>();
				foreach (FailureMessage failureMessage in this.warnings)
				{
					try
					{
						ICollection<ElementId> failingElements = failureMessage.GetFailingElements();
						foreach (ElementId elementId in failingElements)
						{
							try
							{
								WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(this.doc, elementId);
								string creator = worksharingTooltipInfo.Creator;
								if (creator == this.comboBoxUsers.SelectedItem.ToString())
								{
									list.Add(elementId);
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
				using (Transaction transaction = new Transaction(this.doc))
				{
					transaction.Start("Isolate Warnings");
					this.doc.ActiveView.IsolateElementsTemporary(list);
					transaction.Commit();
				}
				base.Close();
			}
		}

		// Token: 0x040001A4 RID: 420
		private Document doc;

		// Token: 0x040001A5 RID: 421
		private IList<FailureMessage> warnings = new List<FailureMessage>();
	}
}

