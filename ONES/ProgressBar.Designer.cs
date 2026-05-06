namespace ONES
{
	// Token: 0x02000072 RID: 114
	public partial class ProgressBar : global::System.Windows.Forms.Form
	{
		// Token: 0x06000276 RID: 630 RVA: 0x00028348 File Offset: 0x00026548
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00028368 File Offset: 0x00026568
		private void InitializeComponent()
		{
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.progressBar1.Location = new global::System.Drawing.Point(12, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(126, 23);
			this.progressBar1.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("MS UI Gothic", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(60, 15);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(34, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "%00";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Window;
			base.ClientSize = new global::System.Drawing.Size(150, 50);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ProgressBar";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Progress";
			base.Load += new global::System.EventHandler(this.ProgressBar_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001C6 RID: 454
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.ProgressBar progressBar1;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.Label label1;
	}
}
