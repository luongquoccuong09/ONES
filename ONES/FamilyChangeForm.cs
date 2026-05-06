using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
	// Token: 0x02000050 RID: 80
	public partial class FamilyChangeForm : System.Windows.Forms.Form
	{
		// Token: 0x0600021C RID: 540 RVA: 0x00023100 File Offset: 0x00021300
		public FamilyChangeForm(UIDocument _uidoc, Element _element)
		{
			this.InitializeComponent();
			this.doc = _uidoc.Document;
			this.element = _element;
			this.instance = (_element as FamilyInstance);
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.buttonChange.Text = "変化する";
				this.buttonCancel.Text = "キャンセル";
				this.labelFamily.Text = "ファミリ名前";
				this.groupBoxCategory.Text = "カテゴリー";
				this.radioButtonAll.Text = "全てのカテゴリー";
				this.radioButtonSame.Text = "同じカテゴリー";
			}
			this.radioButtonSame.Checked = true;
			base.CancelButton = this.buttonCancel;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000231DC File Offset: 0x000213DC
		private void FamilyChangeForm_Load(object sender, EventArgs e)
		{
			this.families = new List<Family>();
			this.familiesAll = new List<Family>();
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc).OfClass(typeof(Family));
			foreach (Element element in filteredElementCollector)
			{
				Family family = (Family)element;
				try
				{
					if (this.instance.Symbol.Family.FamilyCategoryId == family.FamilyCategoryId)
					{
						this.families.Add(family);
					}
					this.familiesAll.Add(family);
				}
				catch (Exception)
				{
				}
			}
			this.families.RemoveAll((Family item) => item == null);
			this.families.Sort((Family x, Family y) => string.Compare(x.Name, y.Name));
			this.familiesAll.RemoveAll((Family item) => item == null);
			this.familiesAll.Sort((Family x, Family y) => string.Compare(x.Name, y.Name));
			this.comboBoxFamily.DataSource = this.families;
			this.comboBoxFamily.DisplayMember = "Name";
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0002336C File Offset: 0x0002156C
		private void buttonChange_Click(object sender, EventArgs e)
		{
			FamilyInstance familyInstance = this.element as FamilyInstance;
			FamilySymbol symbol = familyInstance.Symbol;
			if (this.doc == null || symbol == null)
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			if (familyInstance.Symbol.Family == null)
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			Family family = this.comboBoxFamily.SelectedItem as Family;
			if (family == null)
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			Document document = this.doc.EditFamily(family);
			if (document == null)
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			FamilyManager familyManager = document.FamilyManager;
			if (familyManager == null)
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			string name = this.element.Name;
			using (Transaction transaction = new Transaction(document, "Add Type to Family"))
			{
				try
				{
					transaction.Start();
					FamilyType familyType = familyManager.NewType(name);
					if (familyType != null)
					{
						try
						{
							foreach (Parameter parameter in symbol.GetOrderedParameters())
							{
								try
								{
									FamilyParameter familyParameter = familyManager.get_Parameter(parameter.Definition.Name);
									if (parameter.StorageType.Equals(4))
									{
										familyManager.Set(familyParameter, parameter.AsElementId());
									}
									else if (parameter.StorageType.Equals(3))
									{
										familyManager.Set(familyParameter, parameter.AsString());
									}
									else if (parameter.StorageType.Equals(1))
									{
										familyManager.Set(familyParameter, parameter.AsInteger());
									}
									else if (parameter.StorageType.Equals(2))
									{
										familyManager.Set(familyParameter, parameter.AsDouble());
									}
								}
								catch (Exception)
								{
								}
							}
						}
						catch (Exception ex)
						{
							RevitTaskDialog.Show("Exception", ex.Message);
						}
					}
					transaction.Commit();
					if (transaction.GetStatus() != TransactionStatus.Committed)
					{
						base.DialogResult = DialogResult.Abort;
						base.Close();
					}
					LoadOpts loadOpts = new LoadOpts();
					family = document.LoadFamily(this.doc, loadOpts);
				}
				catch (Exception ex2)
				{
					transaction.RollBack();
					RevitTaskDialog.Show("Error", ex2.Message);
				}
			}
			try
			{
				ISet<ElementId> familySymbolIds = family.GetFamilySymbolIds();
				foreach (ElementId elementId in familySymbolIds)
				{
					FamilySymbol familySymbol = this.doc.GetElement(elementId) as FamilySymbol;
					if (familySymbol != null && familySymbol.Name == name)
					{
						using (Transaction transaction2 = new Transaction(this.doc, "Change Symbol Assignment"))
						{
							transaction2.Start();
							familyInstance.Symbol = familySymbol;
							transaction2.Commit();
							break;
						}
					}
				}
			}
			catch (Exception ex3)
			{
				RevitTaskDialog.Show("Exception", ex3.Message);
			}
			base.Close();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00023750 File Offset: 0x00021950
		private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButtonAll.Checked)
			{
				this.comboBoxFamily.DataSource = this.familiesAll;
				this.comboBoxFamily.DisplayMember = "Name";
				return;
			}
			this.comboBoxFamily.DataSource = this.families;
			this.comboBoxFamily.DisplayMember = "Name";
		}

		// Token: 0x04000197 RID: 407
		private Document doc;

		// Token: 0x04000198 RID: 408
		private Element element;

		// Token: 0x04000199 RID: 409
		private FamilyInstance instance;

		// Token: 0x0400019A RID: 410
		private List<Family> families;

		// Token: 0x0400019B RID: 411
		private List<Family> familiesAll;
	}
}

