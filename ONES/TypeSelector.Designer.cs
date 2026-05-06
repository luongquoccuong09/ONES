namespace ONES
{
	// Token: 0x0200003C RID: 60
	public partial class TypeSelector : global::System.Windows.Forms.Form
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x00022126 File Offset: 0x00020326
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00022148 File Offset: 0x00020348
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ONES.TypeSelector));
			this.labelName = new global::System.Windows.Forms.Label();
			this.comboBoxTypes = new global::System.Windows.Forms.ComboBox();
			this.buttonOk = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.labelName.AutoSize = true;
			this.labelName.Location = new global::System.Drawing.Point(130, 9);
			this.labelName.Name = "labelName";
			this.labelName.Size = new global::System.Drawing.Size(34, 12);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			this.comboBoxTypes.FormattingEnabled = true;
			this.comboBoxTypes.Location = new global::System.Drawing.Point(12, 33);
			this.comboBoxTypes.Name = "comboBoxTypes";
			this.comboBoxTypes.Size = new global::System.Drawing.Size(260, 20);
			this.comboBoxTypes.TabIndex = 1;
			this.buttonOk.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonOk.Location = new global::System.Drawing.Point(105, 133);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new global::System.Drawing.Size(75, 30);
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = false;
			this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
			this.buttonCancel.Location = new global::System.Drawing.Point(105, 169);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 30);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 211);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOk);
			base.Controls.Add(this.comboBoxTypes);
			base.Controls.Add(this.labelName);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "TypeSelector";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Type";
			base.Load += new global::System.EventHandler(this.TypeSelector_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000189 RID: 393
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.Label labelName;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.ComboBox comboBoxTypes;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.Button buttonOk;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.Button buttonCancel;
	}
}
