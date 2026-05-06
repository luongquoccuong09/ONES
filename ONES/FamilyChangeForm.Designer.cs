namespace ONES
{
	// Token: 0x02000050 RID: 80
	public partial class FamilyChangeForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000220 RID: 544 RVA: 0x000237AD File Offset: 0x000219AD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000237CC File Offset: 0x000219CC
		private void InitializeComponent()
		{
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.buttonChange = new global::System.Windows.Forms.Button();
			this.comboBoxFamily = new global::System.Windows.Forms.ComboBox();
			this.labelFamily = new global::System.Windows.Forms.Label();
			this.groupBoxCategory = new global::System.Windows.Forms.GroupBox();
			this.radioButtonAll = new global::System.Windows.Forms.RadioButton();
			this.radioButtonSame = new global::System.Windows.Forms.RadioButton();
			this.groupBoxCategory.SuspendLayout();
			base.SuspendLayout();
			this.buttonCancel.Location = new global::System.Drawing.Point(105, 174);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 30);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonChange.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonChange.Location = new global::System.Drawing.Point(105, 135);
			this.buttonChange.Name = "buttonChange";
			this.buttonChange.Size = new global::System.Drawing.Size(75, 30);
			this.buttonChange.TabIndex = 6;
			this.buttonChange.Text = "Change";
			this.buttonChange.UseVisualStyleBackColor = false;
			this.buttonChange.Click += new global::System.EventHandler(this.buttonChange_Click);
			this.comboBoxFamily.FormattingEnabled = true;
			this.comboBoxFamily.Location = new global::System.Drawing.Point(12, 36);
			this.comboBoxFamily.Name = "comboBoxFamily";
			this.comboBoxFamily.Size = new global::System.Drawing.Size(260, 20);
			this.comboBoxFamily.TabIndex = 5;
			this.labelFamily.AutoSize = true;
			this.labelFamily.Location = new global::System.Drawing.Point(102, 9);
			this.labelFamily.Name = "labelFamily";
			this.labelFamily.Size = new global::System.Drawing.Size(72, 12);
			this.labelFamily.TabIndex = 4;
			this.labelFamily.Text = "Family Name";
			this.groupBoxCategory.Controls.Add(this.radioButtonAll);
			this.groupBoxCategory.Controls.Add(this.radioButtonSame);
			this.groupBoxCategory.Location = new global::System.Drawing.Point(12, 74);
			this.groupBoxCategory.Name = "groupBoxCategory";
			this.groupBoxCategory.Size = new global::System.Drawing.Size(260, 46);
			this.groupBoxCategory.TabIndex = 8;
			this.groupBoxCategory.TabStop = false;
			this.groupBoxCategory.Text = "Category";
			this.radioButtonAll.AutoSize = true;
			this.radioButtonAll.Location = new global::System.Drawing.Point(133, 18);
			this.radioButtonAll.Name = "radioButtonAll";
			this.radioButtonAll.Size = new global::System.Drawing.Size(96, 16);
			this.radioButtonAll.TabIndex = 0;
			this.radioButtonAll.TabStop = true;
			this.radioButtonAll.Text = "All Categories";
			this.radioButtonAll.UseVisualStyleBackColor = true;
			this.radioButtonAll.CheckedChanged += new global::System.EventHandler(this.radioButtonAll_CheckedChanged);
			this.radioButtonSame.AutoSize = true;
			this.radioButtonSame.Location = new global::System.Drawing.Point(6, 18);
			this.radioButtonSame.Name = "radioButtonSame";
			this.radioButtonSame.Size = new global::System.Drawing.Size(101, 16);
			this.radioButtonSame.TabIndex = 0;
			this.radioButtonSame.TabStop = true;
			this.radioButtonSame.Text = "Same Category";
			this.radioButtonSame.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 211);
			base.Controls.Add(this.groupBoxCategory);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonChange);
			base.Controls.Add(this.comboBoxFamily);
			base.Controls.Add(this.labelFamily);
			base.Name = "FamilyChangeForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Family ";
			base.Load += new global::System.EventHandler(this.FamilyChangeForm_Load);
			this.groupBoxCategory.ResumeLayout(false);
			this.groupBoxCategory.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400019C RID: 412
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.Button buttonCancel;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.Button buttonChange;

		// Token: 0x0400019F RID: 415
		private global::System.Windows.Forms.ComboBox comboBoxFamily;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.Label labelFamily;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.GroupBox groupBoxCategory;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.RadioButton radioButtonAll;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.RadioButton radioButtonSame;
	}
}
