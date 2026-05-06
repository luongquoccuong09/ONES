namespace ONES
{
	// Token: 0x02000016 RID: 22
	public partial class TimelinerForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000067 RID: 103 RVA: 0x0000B745 File Offset: 0x00009945
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000B764 File Offset: 0x00009964
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.radioButtonElement = new global::System.Windows.Forms.RadioButton();
			this.radioButtonCategory = new global::System.Windows.Forms.RadioButton();
			this.buttonOk = new global::System.Windows.Forms.Button();
			this.checkBoxExport = new global::System.Windows.Forms.CheckBox();
			this.textBoxCategory = new global::System.Windows.Forms.TextBox();
			this.textBoxElement = new global::System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.textBoxElement);
			this.groupBox1.Controls.Add(this.textBoxCategory);
			this.groupBox1.Controls.Add(this.radioButtonElement);
			this.groupBox1.Controls.Add(this.radioButtonCategory);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(219, 77);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Animation Style";
			this.radioButtonElement.AutoSize = true;
			this.radioButtonElement.Location = new global::System.Drawing.Point(6, 55);
			this.radioButtonElement.Name = "radioButtonElement";
			this.radioButtonElement.Size = new global::System.Drawing.Size(64, 16);
			this.radioButtonElement.TabIndex = 1;
			this.radioButtonElement.TabStop = true;
			this.radioButtonElement.Text = "Element";
			this.radioButtonElement.UseVisualStyleBackColor = true;
			this.radioButtonCategory.AutoSize = true;
			this.radioButtonCategory.Location = new global::System.Drawing.Point(6, 21);
			this.radioButtonCategory.Name = "radioButtonCategory";
			this.radioButtonCategory.Size = new global::System.Drawing.Size(69, 16);
			this.radioButtonCategory.TabIndex = 1;
			this.radioButtonCategory.TabStop = true;
			this.radioButtonCategory.Text = "Category";
			this.radioButtonCategory.UseVisualStyleBackColor = true;
			this.buttonOk.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonOk.Location = new global::System.Drawing.Point(68, 174);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new global::System.Drawing.Size(77, 25);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = false;
			this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
			this.checkBoxExport.AutoSize = true;
			this.checkBoxExport.Location = new global::System.Drawing.Point(18, 95);
			this.checkBoxExport.Name = "checkBoxExport";
			this.checkBoxExport.Size = new global::System.Drawing.Size(57, 16);
			this.checkBoxExport.TabIndex = 2;
			this.checkBoxExport.Text = "Export";
			this.checkBoxExport.UseVisualStyleBackColor = true;
			this.textBoxCategory.Location = new global::System.Drawing.Point(118, 18);
			this.textBoxCategory.Name = "textBoxCategory";
			this.textBoxCategory.Size = new global::System.Drawing.Size(65, 19);
			this.textBoxCategory.TabIndex = 3;
			this.textBoxElement.Location = new global::System.Drawing.Point(118, 52);
			this.textBoxElement.Name = "textBoxElement";
			this.textBoxElement.Size = new global::System.Drawing.Size(65, 19);
			this.textBoxElement.TabIndex = 3;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(243, 211);
			base.Controls.Add(this.checkBoxExport);
			base.Controls.Add(this.buttonOk);
			base.Controls.Add(this.groupBox1);
			base.Name = "TimelinerForm";
			this.Text = "Form1";
			base.Load += new global::System.EventHandler(this.TimelinerForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000056 RID: 86
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.RadioButton radioButtonElement;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.RadioButton radioButtonCategory;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Button buttonOk;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.CheckBox checkBoxExport;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.TextBox textBoxElement;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.TextBox textBoxCategory;
	}
}
