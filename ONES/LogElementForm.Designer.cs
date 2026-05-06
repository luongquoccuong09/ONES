namespace ONES
{
	// Token: 0x0200002A RID: 42
	public partial class LogElementForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x00015818 File Offset: 0x00013A18
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00015838 File Offset: 0x00013A38
		private void InitializeComponent()
		{
			this.treeViewLog = new global::System.Windows.Forms.TreeView();
			base.SuspendLayout();
			this.treeViewLog.Location = new global::System.Drawing.Point(12, 12);
			this.treeViewLog.Name = "treeViewLog";
			this.treeViewLog.Size = new global::System.Drawing.Size(590, 1050);
			this.treeViewLog.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(636, 1089);
			base.Controls.Add(this.treeViewLog);
			base.Name = "LogElementForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Element Log";
			base.Load += new global::System.EventHandler(this.LogElementForm_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040000E7 RID: 231
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.TreeView treeViewLog;
	}
}
