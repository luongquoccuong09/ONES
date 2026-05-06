using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
	// Token: 0x02000078 RID: 120
	public partial class SettingsForm : System.Windows.Forms.Form
	{
		// Token: 0x060002A8 RID: 680 RVA: 0x00028EF3 File Offset: 0x000270F3
		public SettingsForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			this.JapaneseUI();
			base.CancelButton = this.buttonClose;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00028F2B File Offset: 0x0002712B
		private void SettingsForm_Load(object sender, EventArgs e)
		{
			this.textBoxLog.Text = Settings.Default.LogsFile;
			this.textBoxONES.Text = Settings.Default.folderONES;
			this.FormUpdate();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00028F60 File Offset: 0x00027160
		private void JapaneseUI()
		{
			this.Text = "設定";
			this.groupBoxLogs.Text = "ログファイル";
			this.groupBoxLogToggle.Text = "ログ";
			this.checkBoxONESLog.Text = "ONESのログ";
			this.groupBoxLanguage.Text = "言語";
			this.RBLanguageRevit.Text = "Revitの言語";
			this.RBLanguageEn.Text = "英語";
			this.RBLanguageJp.Text = "日本語";
			this.buttonSave.Text = "保存する";
			this.buttonClose.Text = "閉じる";
			this.buttonDefault.Text = "既定";
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00029018 File Offset: 0x00027218
		private void buttonSave_Click(object sender, EventArgs e)
		{
			Settings.Default.LogsFile = this.textBoxLog.Text;
			Settings.Default.folderONES = this.textBoxONES.Text;
			Settings.Default.ONESLogsOnOff = this.checkBoxONESLog.Checked;
			if (this.RBLanguageEn.Checked)
			{
				Settings.Default.Language = "English";
			}
			else if (this.RBLanguageJp.Checked)
			{
				Settings.Default.Language = "Japanese";
			}
			else
			{
				Settings.Default.Language = "Default";
			}
			base.Close();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000290B8 File Offset: 0x000272B8
		private void buttonDefault_Click(object sender, EventArgs e)
		{
			this.textBoxLog.Text = Settings.Default.LogsFileDefault;
			this.textBoxONES.Text = Settings.Default.folderONESDefault;
			Settings.Default.ONESLogsOnOff = true;
			Settings.Default.Language = "Default";
			this.FormUpdate();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00029110 File Offset: 0x00027310
		private void buttonBrowseLog_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.ShowDialog();
			if (openFileDialog.CheckFileExists)
			{
				this.textBoxLog.Text = openFileDialog.FileName;
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00029144 File Offset: 0x00027344
		private void buttonONES_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.ShowDialog();
			if (openFileDialog.CheckFileExists)
			{
				this.textBoxONES.Text = openFileDialog.FileName;
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00029178 File Offset: 0x00027378
		private void FormUpdate()
		{
			this.checkBoxONESLog.Checked = Settings.Default.ONESLogsOnOff;
			if (Settings.Default.Language == "Default")
			{
				this.RBLanguageRevit.Checked = true;
				return;
			}
			if (Settings.Default.Language == "Japanese")
			{
				this.RBLanguageJp.Checked = true;
				return;
			}
			this.RBLanguageEn.Checked = true;
		}

		// Token: 0x040001D3 RID: 467
		private UIDocument uidoc;

		// Token: 0x040001D4 RID: 468
		private Document doc;
	}
}

