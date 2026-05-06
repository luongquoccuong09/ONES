using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ONES
{
	// Token: 0x02000072 RID: 114
	public partial class ProgressBar : Form
	{
		// Token: 0x06000272 RID: 626 RVA: 0x000282C5 File Offset: 0x000264C5
		public ProgressBar()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000282D4 File Offset: 0x000264D4
		public void SetProgress(int progress)
		{
			if (progress >= 100)
			{
				base.Close();
			}
			this.progressBar1.Minimum = 0;
			this.progressBar1.Maximum = 100;
			this.progressBar1.Value = progress;
			this.label1.Text = "%" + progress.ToString();
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0002832D File Offset: 0x0002652D
		private void ProgressBar_Load(object sender, EventArgs e)
		{
			Application.DoEvents();
			base.WindowState = FormWindowState.Minimized;
			base.Show();
			base.WindowState = FormWindowState.Normal;
		}
	}
}
