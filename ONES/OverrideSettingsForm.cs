using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
	// Token: 0x02000014 RID: 20
	public partial class OverrideSettingsForm : System.Windows.Forms.Form
	{
		// Token: 0x06000051 RID: 81 RVA: 0x0000A420 File Offset: 0x00008620
		public OverrideSettingsForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.JapaneseUI();
			}
			base.CancelButton = this.buttonClose;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000A48D File Offset: 0x0000868D
		private void SettingsForm_Load(object sender, EventArgs e)
		{
			this.FormUpdate();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000A498 File Offset: 0x00008698
		private void JapaneseUI()
		{
			this.groupBoxGraphic.Text = "グラフィック設定";
			this.checkBoxHalftone.Text = "ハーフトーン";
			this.checkBoxLine.Text = "線";
			this.checkBoxNest.Text = "ネスト";
			this.checkBoxSurface.Text = "サーフェス";
			this.checkBoxCut.Text = "切断面";
			this.groupBoxTransparency.Text = "透過度";
			this.buttonDefault.Text = "ディフォルト";
			this.buttonClose.Text = "閉じる";
			this.buttonSave.Text = "保存";
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000A548 File Offset: 0x00008748
		private void FormUpdate()
		{
			this.checkBoxHalftone.Checked = Settings.Default.OverrideHalftone;
			this.checkBoxLine.Checked = Settings.Default.OverrideLine;
			this.checkBoxSurface.Checked = Settings.Default.OverrideSurface;
			this.checkBoxCut.Checked = Settings.Default.OverrideCut;
			this.checkBoxNest.Checked = Settings.Default.OverrideNest;
			this.trackBarTransparency.Value = Settings.Default.OverrideTransparency;
			this.textBoxTransparency.Text = this.trackBarTransparency.Value.ToString();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000A5FC File Offset: 0x000087FC
		private void buttonSave_Click(object sender, EventArgs e)
		{
			Settings.Default.OverrideHalftone = this.checkBoxHalftone.Checked;
			Settings.Default.OverrideLine = this.checkBoxLine.Checked;
			Settings.Default.OverrideSurface = this.checkBoxSurface.Checked;
			Settings.Default.OverrideCut = this.checkBoxCut.Checked;
			Settings.Default.OverrideNest = this.checkBoxNest.Checked;
			Settings.Default.OverrideTransparency = this.trackBarTransparency.Value * 10;
			base.Close();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000A690 File Offset: 0x00008890
		private void buttonDefault_Click(object sender, EventArgs e)
		{
			Settings.Default.ONESLogsOnOff = true;
			Settings.Default.OverrideHalftone = true;
			Settings.Default.OverrideLine = true;
			Settings.Default.OverrideSurface = true;
			Settings.Default.OverrideCut = true;
			Settings.Default.OverrideNest = true;
			Settings.Default.OverrideTransparency = 0;
			Settings.Default.Language = "Default";
			this.FormUpdate();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000023A6 File Offset: 0x000005A6
		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000A700 File Offset: 0x00008900
		private void trackBarTransparency_Scroll(object sender, EventArgs e)
		{
			this.textBoxTransparency.Text = (this.trackBarTransparency.Value * 10).ToString();
		}

		// Token: 0x04000045 RID: 69
		private UIDocument uidoc;

		// Token: 0x04000046 RID: 70
		private Document doc;
	}
}

