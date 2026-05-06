using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
	// Token: 0x0200003C RID: 60
	public partial class TypeSelector : System.Windows.Forms.Form
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00022008 File Offset: 0x00020208
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00022010 File Offset: 0x00020210
		public Element ReturnType { get; set; }

		// Token: 0x060001DF RID: 479 RVA: 0x0002201C File Offset: 0x0002021C
		public TypeSelector(UIDocument _uidoc, List<Element> _elementTypes)
		{
			this.InitializeComponent();
			this.doc = _uidoc.Document;
			this.elementTypes = _elementTypes;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.buttonOk.Text = "OK";
				this.buttonCancel.Text = "キャンセル";
				this.labelName.Text = "タイプ名";
			}
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000220C0 File Offset: 0x000202C0
		private void TypeSelector_Load(object sender, EventArgs e)
		{
			this.comboBoxTypes.DataSource = this.elementTypes;
			this.comboBoxTypes.DisplayMember = "Name";
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000220E3 File Offset: 0x000202E3
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000220F2 File Offset: 0x000202F2
		private void buttonOk_Click(object sender, EventArgs e)
		{
			this.ReturnType = (this.comboBoxTypes.SelectedItem as Element);
			if (this.ReturnType == null)
			{
				base.DialogResult = DialogResult.Abort;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x04000186 RID: 390
		private List<Element> elementTypes = new List<Element>();

		// Token: 0x04000187 RID: 391
		private Document doc;
	}
}

