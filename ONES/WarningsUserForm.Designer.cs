namespace ONES
{
	// Token: 0x02000068 RID: 104
	public partial class WarningsUserForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000255 RID: 597 RVA: 0x00026458 File Offset: 0x00024658
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00026478 File Offset: 0x00024678
		private void InitializeComponent()
		{
			this.labelUsers = new global::System.Windows.Forms.Label();
			this.comboBoxUsers = new global::System.Windows.Forms.ComboBox();
			this.buttonIsolate = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.labelUsers.AutoSize = true;
			this.labelUsers.Location = new global::System.Drawing.Point(81, 9);
			this.labelUsers.Name = "labelUsers";
			this.labelUsers.Size = new global::System.Drawing.Size(35, 12);
			this.labelUsers.TabIndex = 0;
			this.labelUsers.Text = "Users";
			this.comboBoxUsers.FormattingEnabled = true;
			this.comboBoxUsers.Location = new global::System.Drawing.Point(12, 37);
			this.comboBoxUsers.Name = "comboBoxUsers";
			this.comboBoxUsers.Size = new global::System.Drawing.Size(176, 20);
			this.comboBoxUsers.TabIndex = 1;
			this.buttonIsolate.Location = new global::System.Drawing.Point(69, 76);
			this.buttonIsolate.Name = "buttonIsolate";
			this.buttonIsolate.Size = new global::System.Drawing.Size(69, 28);
			this.buttonIsolate.TabIndex = 2;
			this.buttonIsolate.Text = "Isolate";
			this.buttonIsolate.UseVisualStyleBackColor = true;
			this.buttonIsolate.Click += new global::System.EventHandler(this.button1_Click);
			this.buttonCancel.Location = new global::System.Drawing.Point(69, 110);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(69, 28);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.button2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(200, 150);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonIsolate);
			base.Controls.Add(this.comboBoxUsers);
			base.Controls.Add(this.labelUsers);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "WarningsUserForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Warnings";
			base.Load += new global::System.EventHandler(this.WarningsUserForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001A6 RID: 422
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.Label labelUsers;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.ComboBox comboBoxUsers;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.Button buttonIsolate;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.Button buttonCancel;
	}
}
