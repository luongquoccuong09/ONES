namespace ONES
{
	// Token: 0x02000014 RID: 20
	public partial class OverrideSettingsForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005A RID: 90 RVA: 0x0000A72E File Offset: 0x0000892E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000A750 File Offset: 0x00008950
		private void InitializeComponent()
		{
			this.buttonSave = new global::System.Windows.Forms.Button();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.buttonDefault = new global::System.Windows.Forms.Button();
			this.groupBoxGraphic = new global::System.Windows.Forms.GroupBox();
			this.groupBoxTransparency = new global::System.Windows.Forms.GroupBox();
			this.textBoxTransparency = new global::System.Windows.Forms.TextBox();
			this.trackBarTransparency = new global::System.Windows.Forms.TrackBar();
			this.checkBoxCut = new global::System.Windows.Forms.CheckBox();
			this.checkBoxNest = new global::System.Windows.Forms.CheckBox();
			this.checkBoxSurface = new global::System.Windows.Forms.CheckBox();
			this.checkBoxHalftone = new global::System.Windows.Forms.CheckBox();
			this.checkBoxLine = new global::System.Windows.Forms.CheckBox();
			this.groupBoxGraphic.SuspendLayout();
			this.groupBoxTransparency.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarTransparency).BeginInit();
			base.SuspendLayout();
			this.buttonSave.Location = new global::System.Drawing.Point(235, 169);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new global::System.Drawing.Size(60, 27);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new global::System.EventHandler(this.buttonSave_Click);
			this.buttonClose.Location = new global::System.Drawing.Point(169, 169);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(60, 27);
			this.buttonClose.TabIndex = 4;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.buttonDefault.Location = new global::System.Drawing.Point(12, 169);
			this.buttonDefault.Name = "buttonDefault";
			this.buttonDefault.Size = new global::System.Drawing.Size(70, 27);
			this.buttonDefault.TabIndex = 5;
			this.buttonDefault.Text = "Default";
			this.buttonDefault.UseVisualStyleBackColor = true;
			this.buttonDefault.Click += new global::System.EventHandler(this.buttonDefault_Click);
			this.groupBoxGraphic.Controls.Add(this.groupBoxTransparency);
			this.groupBoxGraphic.Controls.Add(this.checkBoxCut);
			this.groupBoxGraphic.Controls.Add(this.checkBoxNest);
			this.groupBoxGraphic.Controls.Add(this.checkBoxSurface);
			this.groupBoxGraphic.Controls.Add(this.checkBoxHalftone);
			this.groupBoxGraphic.Controls.Add(this.checkBoxLine);
			this.groupBoxGraphic.Location = new global::System.Drawing.Point(12, 12);
			this.groupBoxGraphic.Name = "groupBoxGraphic";
			this.groupBoxGraphic.Size = new global::System.Drawing.Size(283, 142);
			this.groupBoxGraphic.TabIndex = 15;
			this.groupBoxGraphic.TabStop = false;
			this.groupBoxGraphic.Text = "Override Graphic";
			this.groupBoxGraphic.Enter += new global::System.EventHandler(this.groupBox1_Enter);
			this.groupBoxTransparency.Controls.Add(this.textBoxTransparency);
			this.groupBoxTransparency.Controls.Add(this.trackBarTransparency);
			this.groupBoxTransparency.Location = new global::System.Drawing.Point(5, 64);
			this.groupBoxTransparency.Name = "groupBoxTransparency";
			this.groupBoxTransparency.Size = new global::System.Drawing.Size(162, 63);
			this.groupBoxTransparency.TabIndex = 25;
			this.groupBoxTransparency.TabStop = false;
			this.groupBoxTransparency.Text = "Transparency";
			this.textBoxTransparency.Location = new global::System.Drawing.Point(119, 15);
			this.textBoxTransparency.Name = "textBoxTransparency";
			this.textBoxTransparency.Size = new global::System.Drawing.Size(35, 19);
			this.textBoxTransparency.TabIndex = 25;
			this.trackBarTransparency.Location = new global::System.Drawing.Point(9, 15);
			this.trackBarTransparency.Name = "trackBarTransparency";
			this.trackBarTransparency.Size = new global::System.Drawing.Size(104, 45);
			this.trackBarTransparency.TabIndex = 24;
			this.trackBarTransparency.Scroll += new global::System.EventHandler(this.trackBarTransparency_Scroll);
			this.checkBoxCut.AutoSize = true;
			this.checkBoxCut.Location = new global::System.Drawing.Point(98, 40);
			this.checkBoxCut.Name = "checkBoxCut";
			this.checkBoxCut.Size = new global::System.Drawing.Size(42, 16);
			this.checkBoxCut.TabIndex = 16;
			this.checkBoxCut.Text = "Cut";
			this.checkBoxCut.UseVisualStyleBackColor = true;
			this.checkBoxNest.AutoSize = true;
			this.checkBoxNest.Location = new global::System.Drawing.Point(167, 18);
			this.checkBoxNest.Name = "checkBoxNest";
			this.checkBoxNest.Size = new global::System.Drawing.Size(107, 16);
			this.checkBoxNest.TabIndex = 16;
			this.checkBoxNest.Text = "Nested Families";
			this.checkBoxNest.UseVisualStyleBackColor = true;
			this.checkBoxSurface.AutoSize = true;
			this.checkBoxSurface.Location = new global::System.Drawing.Point(98, 18);
			this.checkBoxSurface.Name = "checkBoxSurface";
			this.checkBoxSurface.Size = new global::System.Drawing.Size(63, 16);
			this.checkBoxSurface.TabIndex = 16;
			this.checkBoxSurface.Text = "Surface";
			this.checkBoxSurface.UseVisualStyleBackColor = true;
			this.checkBoxHalftone.AutoSize = true;
			this.checkBoxHalftone.Location = new global::System.Drawing.Point(6, 18);
			this.checkBoxHalftone.Name = "checkBoxHalftone";
			this.checkBoxHalftone.Size = new global::System.Drawing.Size(67, 16);
			this.checkBoxHalftone.TabIndex = 16;
			this.checkBoxHalftone.Text = "Halftone";
			this.checkBoxHalftone.UseVisualStyleBackColor = true;
			this.checkBoxLine.AutoSize = true;
			this.checkBoxLine.Location = new global::System.Drawing.Point(6, 40);
			this.checkBoxLine.Name = "checkBoxLine";
			this.checkBoxLine.Size = new global::System.Drawing.Size(45, 16);
			this.checkBoxLine.TabIndex = 16;
			this.checkBoxLine.Text = "Line";
			this.checkBoxLine.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(304, 211);
			base.Controls.Add(this.groupBoxGraphic);
			base.Controls.Add(this.buttonDefault);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.buttonSave);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "OverrideSettingsForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			base.Load += new global::System.EventHandler(this.SettingsForm_Load);
			this.groupBoxGraphic.ResumeLayout(false);
			this.groupBoxGraphic.PerformLayout();
			this.groupBoxTransparency.ResumeLayout(false);
			this.groupBoxTransparency.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarTransparency).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000047 RID: 71
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Button buttonSave;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.Button buttonClose;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Button buttonDefault;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.GroupBox groupBoxGraphic;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.CheckBox checkBoxNest;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.CheckBox checkBoxSurface;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.CheckBox checkBoxLine;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.CheckBox checkBoxHalftone;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.CheckBox checkBoxCut;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.GroupBox groupBoxTransparency;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.TextBox textBoxTransparency;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.TrackBar trackBarTransparency;
	}
}
