namespace ONES
{
	// Token: 0x02000078 RID: 120
	public partial class SettingsForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x000291EC File Offset: 0x000273EC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0002920C File Offset: 0x0002740C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ONES.SettingsForm));
			this.buttonBrowseLog = new global::System.Windows.Forms.Button();
			this.textBoxLog = new global::System.Windows.Forms.TextBox();
			this.buttonSave = new global::System.Windows.Forms.Button();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.buttonDefault = new global::System.Windows.Forms.Button();
			this.groupBoxLogs = new global::System.Windows.Forms.GroupBox();
			this.groupBoxLogToggle = new global::System.Windows.Forms.GroupBox();
			this.checkBoxONESLog = new global::System.Windows.Forms.CheckBox();
			this.groupBoxONES = new global::System.Windows.Forms.GroupBox();
			this.buttonONES = new global::System.Windows.Forms.Button();
			this.textBoxONES = new global::System.Windows.Forms.TextBox();
			this.groupBoxLanguage = new global::System.Windows.Forms.GroupBox();
			this.RBLanguageJp = new global::System.Windows.Forms.RadioButton();
			this.RBLanguageEn = new global::System.Windows.Forms.RadioButton();
			this.RBLanguageRevit = new global::System.Windows.Forms.RadioButton();
			this.groupBoxLogs.SuspendLayout();
			this.groupBoxLogToggle.SuspendLayout();
			this.groupBoxONES.SuspendLayout();
			this.groupBoxLanguage.SuspendLayout();
			base.SuspendLayout();
			this.buttonBrowseLog.Location = new global::System.Drawing.Point(6, 16);
			this.buttonBrowseLog.Name = "buttonBrowseLog";
			this.buttonBrowseLog.Size = new global::System.Drawing.Size(62, 27);
			this.buttonBrowseLog.TabIndex = 0;
			this.buttonBrowseLog.Text = "Browse";
			this.buttonBrowseLog.UseVisualStyleBackColor = true;
			this.buttonBrowseLog.Click += new global::System.EventHandler(this.buttonBrowseLog_Click);
			this.textBoxLog.Location = new global::System.Drawing.Point(74, 20);
			this.textBoxLog.Name = "textBoxLog";
			this.textBoxLog.Size = new global::System.Drawing.Size(358, 19);
			this.textBoxLog.TabIndex = 1;
			this.buttonSave.Location = new global::System.Drawing.Point(314, 347);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new global::System.Drawing.Size(65, 27);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new global::System.EventHandler(this.buttonSave_Click);
			this.buttonClose.Location = new global::System.Drawing.Point(385, 347);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(65, 27);
			this.buttonClose.TabIndex = 4;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.buttonDefault.Location = new global::System.Drawing.Point(12, 347);
			this.buttonDefault.Name = "buttonDefault";
			this.buttonDefault.Size = new global::System.Drawing.Size(70, 27);
			this.buttonDefault.TabIndex = 5;
			this.buttonDefault.Text = "Default";
			this.buttonDefault.UseVisualStyleBackColor = true;
			this.buttonDefault.Click += new global::System.EventHandler(this.buttonDefault_Click);
			this.groupBoxLogs.Controls.Add(this.buttonBrowseLog);
			this.groupBoxLogs.Controls.Add(this.textBoxLog);
			this.groupBoxLogs.Location = new global::System.Drawing.Point(12, 12);
			this.groupBoxLogs.Name = "groupBoxLogs";
			this.groupBoxLogs.Size = new global::System.Drawing.Size(438, 49);
			this.groupBoxLogs.TabIndex = 6;
			this.groupBoxLogs.TabStop = false;
			this.groupBoxLogs.Text = "Logs";
			this.groupBoxLogToggle.Controls.Add(this.checkBoxONESLog);
			this.groupBoxLogToggle.Location = new global::System.Drawing.Point(147, 122);
			this.groupBoxLogToggle.Name = "groupBoxLogToggle";
			this.groupBoxLogToggle.Size = new global::System.Drawing.Size(129, 47);
			this.groupBoxLogToggle.TabIndex = 12;
			this.groupBoxLogToggle.TabStop = false;
			this.groupBoxLogToggle.Text = "Logs";
			this.checkBoxONESLog.AutoSize = true;
			this.checkBoxONESLog.Location = new global::System.Drawing.Point(6, 18);
			this.checkBoxONESLog.Name = "checkBoxONESLog";
			this.checkBoxONESLog.Size = new global::System.Drawing.Size(76, 16);
			this.checkBoxONESLog.TabIndex = 16;
			this.checkBoxONESLog.Text = "ONES Log";
			this.checkBoxONESLog.UseVisualStyleBackColor = true;
			this.groupBoxONES.Controls.Add(this.buttonONES);
			this.groupBoxONES.Controls.Add(this.textBoxONES);
			this.groupBoxONES.Location = new global::System.Drawing.Point(12, 67);
			this.groupBoxONES.Name = "groupBoxONES";
			this.groupBoxONES.Size = new global::System.Drawing.Size(438, 49);
			this.groupBoxONES.TabIndex = 14;
			this.groupBoxONES.TabStop = false;
			this.groupBoxONES.Text = "ONES Folder";
			this.buttonONES.Location = new global::System.Drawing.Point(6, 16);
			this.buttonONES.Name = "buttonONES";
			this.buttonONES.Size = new global::System.Drawing.Size(62, 27);
			this.buttonONES.TabIndex = 0;
			this.buttonONES.Text = "Browse";
			this.buttonONES.UseVisualStyleBackColor = true;
			this.buttonONES.Click += new global::System.EventHandler(this.buttonONES_Click);
			this.textBoxONES.Location = new global::System.Drawing.Point(74, 20);
			this.textBoxONES.Name = "textBoxONES";
			this.textBoxONES.Size = new global::System.Drawing.Size(358, 19);
			this.textBoxONES.TabIndex = 1;
			this.groupBoxLanguage.Controls.Add(this.RBLanguageJp);
			this.groupBoxLanguage.Controls.Add(this.RBLanguageEn);
			this.groupBoxLanguage.Controls.Add(this.RBLanguageRevit);
			this.groupBoxLanguage.Location = new global::System.Drawing.Point(12, 122);
			this.groupBoxLanguage.Name = "groupBoxLanguage";
			this.groupBoxLanguage.Size = new global::System.Drawing.Size(129, 89);
			this.groupBoxLanguage.TabIndex = 16;
			this.groupBoxLanguage.TabStop = false;
			this.groupBoxLanguage.Text = "Language";
			this.RBLanguageJp.AutoSize = true;
			this.RBLanguageJp.Location = new global::System.Drawing.Point(5, 66);
			this.RBLanguageJp.Name = "RBLanguageJp";
			this.RBLanguageJp.Size = new global::System.Drawing.Size(72, 16);
			this.RBLanguageJp.TabIndex = 0;
			this.RBLanguageJp.TabStop = true;
			this.RBLanguageJp.Text = "Japanese";
			this.RBLanguageJp.UseVisualStyleBackColor = true;
			this.RBLanguageEn.AutoSize = true;
			this.RBLanguageEn.Location = new global::System.Drawing.Point(6, 44);
			this.RBLanguageEn.Name = "RBLanguageEn";
			this.RBLanguageEn.Size = new global::System.Drawing.Size(60, 16);
			this.RBLanguageEn.TabIndex = 0;
			this.RBLanguageEn.TabStop = true;
			this.RBLanguageEn.Text = "English";
			this.RBLanguageEn.UseVisualStyleBackColor = true;
			this.RBLanguageRevit.AutoSize = true;
			this.RBLanguageRevit.Location = new global::System.Drawing.Point(6, 22);
			this.RBLanguageRevit.Name = "RBLanguageRevit";
			this.RBLanguageRevit.Size = new global::System.Drawing.Size(102, 16);
			this.RBLanguageRevit.TabIndex = 0;
			this.RBLanguageRevit.TabStop = true;
			this.RBLanguageRevit.Text = "Revit Language";
			this.RBLanguageRevit.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(461, 386);
			base.Controls.Add(this.groupBoxLanguage);
			base.Controls.Add(this.groupBoxONES);
			base.Controls.Add(this.groupBoxLogToggle);
			base.Controls.Add(this.groupBoxLogs);
			base.Controls.Add(this.buttonDefault);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.buttonSave);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "SettingsForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			base.Load += new global::System.EventHandler(this.SettingsForm_Load);
			this.groupBoxLogs.ResumeLayout(false);
			this.groupBoxLogs.PerformLayout();
			this.groupBoxLogToggle.ResumeLayout(false);
			this.groupBoxLogToggle.PerformLayout();
			this.groupBoxONES.ResumeLayout(false);
			this.groupBoxONES.PerformLayout();
			this.groupBoxLanguage.ResumeLayout(false);
			this.groupBoxLanguage.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040001D5 RID: 469
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.Button buttonBrowseLog;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.TextBox textBoxLog;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.Button buttonSave;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.Button buttonClose;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.Button buttonDefault;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.GroupBox groupBoxLogs;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.GroupBox groupBoxLogToggle;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.GroupBox groupBoxONES;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.Button buttonONES;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.TextBox textBoxONES;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.CheckBox checkBoxONESLog;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.GroupBox groupBoxLanguage;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.RadioButton RBLanguageJp;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.RadioButton RBLanguageEn;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.RadioButton RBLanguageRevit;
	}
}
