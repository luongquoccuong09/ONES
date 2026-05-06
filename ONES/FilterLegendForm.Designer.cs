namespace ONES
{
	// Token: 0x02000027 RID: 39
	public partial class FilterLegendForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x0001386C File Offset: 0x00011A6C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0001388C File Offset: 0x00011A8C
		private void InitializeComponent()
		{
			this.groupBoxView = new global::System.Windows.Forms.GroupBox();
			this.comboBoxView = new global::System.Windows.Forms.ComboBox();
			this.groupBoxSize = new global::System.Windows.Forms.GroupBox();
			this.textBoxHeight = new global::System.Windows.Forms.TextBox();
			this.textBoxWidth = new global::System.Windows.Forms.TextBox();
			this.labelHeight = new global::System.Windows.Forms.Label();
			this.labelWidth = new global::System.Windows.Forms.Label();
			this.groupBoxText = new global::System.Windows.Forms.GroupBox();
			this.comboBoxText = new global::System.Windows.Forms.ComboBox();
			this.groupBoxFilter = new global::System.Windows.Forms.GroupBox();
			this.checkedListBoxFilters = new global::System.Windows.Forms.CheckedListBox();
			this.buttonOK = new global::System.Windows.Forms.Button();
			this.buttonCheck = new global::System.Windows.Forms.Button();
			this.buttonUncheck = new global::System.Windows.Forms.Button();
			this.buttonUp = new global::System.Windows.Forms.Button();
			this.buttonDown = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.checkBoxCutBackground = new global::System.Windows.Forms.CheckBox();
			this.checkBoxBackground = new global::System.Windows.Forms.CheckBox();
			this.checkBoxCutForeground = new global::System.Windows.Forms.CheckBox();
			this.checkBoxForeground = new global::System.Windows.Forms.CheckBox();
			this.groupBoxView.SuspendLayout();
			this.groupBoxSize.SuspendLayout();
			this.groupBoxText.SuspendLayout();
			this.groupBoxFilter.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBoxView.Controls.Add(this.comboBoxView);
			this.groupBoxView.Location = new global::System.Drawing.Point(597, 12);
			this.groupBoxView.Name = "groupBoxView";
			this.groupBoxView.Size = new global::System.Drawing.Size(200, 52);
			this.groupBoxView.TabIndex = 0;
			this.groupBoxView.TabStop = false;
			this.groupBoxView.Text = "Legend View";
			this.comboBoxView.FormattingEnabled = true;
			this.comboBoxView.Location = new global::System.Drawing.Point(6, 18);
			this.comboBoxView.Name = "comboBoxView";
			this.comboBoxView.Size = new global::System.Drawing.Size(177, 20);
			this.comboBoxView.TabIndex = 1;
			this.groupBoxSize.Controls.Add(this.textBoxHeight);
			this.groupBoxSize.Controls.Add(this.textBoxWidth);
			this.groupBoxSize.Controls.Add(this.labelHeight);
			this.groupBoxSize.Controls.Add(this.labelWidth);
			this.groupBoxSize.Location = new global::System.Drawing.Point(331, 12);
			this.groupBoxSize.Name = "groupBoxSize";
			this.groupBoxSize.Size = new global::System.Drawing.Size(200, 84);
			this.groupBoxSize.TabIndex = 1;
			this.groupBoxSize.TabStop = false;
			this.groupBoxSize.Text = "Legend Size";
			this.textBoxHeight.Location = new global::System.Drawing.Point(50, 52);
			this.textBoxHeight.Name = "textBoxHeight";
			this.textBoxHeight.Size = new global::System.Drawing.Size(71, 19);
			this.textBoxHeight.TabIndex = 2;
			this.textBoxWidth.Location = new global::System.Drawing.Point(50, 27);
			this.textBoxWidth.Name = "textBoxWidth";
			this.textBoxWidth.Size = new global::System.Drawing.Size(71, 19);
			this.textBoxWidth.TabIndex = 2;
			this.labelHeight.AutoSize = true;
			this.labelHeight.Location = new global::System.Drawing.Point(6, 55);
			this.labelHeight.Name = "labelHeight";
			this.labelHeight.Size = new global::System.Drawing.Size(38, 12);
			this.labelHeight.TabIndex = 2;
			this.labelHeight.Text = "Height";
			this.labelWidth.AutoSize = true;
			this.labelWidth.Location = new global::System.Drawing.Point(6, 30);
			this.labelWidth.Name = "labelWidth";
			this.labelWidth.Size = new global::System.Drawing.Size(33, 12);
			this.labelWidth.TabIndex = 2;
			this.labelWidth.Text = "Width";
			this.groupBoxText.Controls.Add(this.comboBoxText);
			this.groupBoxText.Location = new global::System.Drawing.Point(331, 102);
			this.groupBoxText.Name = "groupBoxText";
			this.groupBoxText.Size = new global::System.Drawing.Size(200, 61);
			this.groupBoxText.TabIndex = 1;
			this.groupBoxText.TabStop = false;
			this.groupBoxText.Text = "Text Type";
			this.comboBoxText.FormattingEnabled = true;
			this.comboBoxText.Location = new global::System.Drawing.Point(6, 18);
			this.comboBoxText.Name = "comboBoxText";
			this.comboBoxText.Size = new global::System.Drawing.Size(177, 20);
			this.comboBoxText.TabIndex = 2;
			this.groupBoxFilter.Controls.Add(this.checkedListBoxFilters);
			this.groupBoxFilter.Location = new global::System.Drawing.Point(12, 12);
			this.groupBoxFilter.Name = "groupBoxFilter";
			this.groupBoxFilter.Size = new global::System.Drawing.Size(303, 270);
			this.groupBoxFilter.TabIndex = 1;
			this.groupBoxFilter.TabStop = false;
			this.groupBoxFilter.Text = "Filters";
			this.checkedListBoxFilters.FormattingEnabled = true;
			this.checkedListBoxFilters.Location = new global::System.Drawing.Point(6, 18);
			this.checkedListBoxFilters.Name = "checkedListBoxFilters";
			this.checkedListBoxFilters.Size = new global::System.Drawing.Size(280, 242);
			this.checkedListBoxFilters.TabIndex = 2;
			this.buttonOK.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonOK.Location = new global::System.Drawing.Point(705, 298);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new global::System.Drawing.Size(75, 25);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new global::System.EventHandler(this.buttonOK_Click);
			this.buttonCheck.Location = new global::System.Drawing.Point(18, 288);
			this.buttonCheck.Name = "buttonCheck";
			this.buttonCheck.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCheck.TabIndex = 3;
			this.buttonCheck.Text = "Check All";
			this.buttonCheck.UseVisualStyleBackColor = true;
			this.buttonCheck.Click += new global::System.EventHandler(this.buttonCheck_Click);
			this.buttonUncheck.Location = new global::System.Drawing.Point(99, 288);
			this.buttonUncheck.Name = "buttonUncheck";
			this.buttonUncheck.Size = new global::System.Drawing.Size(75, 23);
			this.buttonUncheck.TabIndex = 3;
			this.buttonUncheck.Text = "Uncheck All";
			this.buttonUncheck.UseVisualStyleBackColor = true;
			this.buttonUncheck.Click += new global::System.EventHandler(this.buttonUncheck_Click);
			this.buttonUp.Location = new global::System.Drawing.Point(192, 288);
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.Size = new global::System.Drawing.Size(50, 23);
			this.buttonUp.TabIndex = 4;
			this.buttonUp.Text = "▲";
			this.buttonUp.UseVisualStyleBackColor = true;
			this.buttonUp.Visible = false;
			this.buttonUp.Click += new global::System.EventHandler(this.buttonUp_Click);
			this.buttonDown.Location = new global::System.Drawing.Point(248, 288);
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.Size = new global::System.Drawing.Size(50, 23);
			this.buttonDown.TabIndex = 4;
			this.buttonDown.Text = "▼";
			this.buttonDown.UseVisualStyleBackColor = true;
			this.buttonDown.Visible = false;
			this.buttonDown.Click += new global::System.EventHandler(this.buttonDown_Click);
			this.buttonCancel.Location = new global::System.Drawing.Point(626, 298);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(73, 25);
			this.buttonCancel.TabIndex = 18;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.groupBox1.Controls.Add(this.checkBoxCutBackground);
			this.groupBox1.Controls.Add(this.checkBoxBackground);
			this.groupBox1.Controls.Add(this.checkBoxCutForeground);
			this.groupBox1.Controls.Add(this.checkBoxForeground);
			this.groupBox1.Location = new global::System.Drawing.Point(331, 172);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(200, 110);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			this.checkBoxCutBackground.AutoSize = true;
			this.checkBoxCutBackground.Location = new global::System.Drawing.Point(6, 84);
			this.checkBoxCutBackground.Name = "checkBoxCutBackground";
			this.checkBoxCutBackground.Size = new global::System.Drawing.Size(106, 16);
			this.checkBoxCutBackground.TabIndex = 20;
			this.checkBoxCutBackground.Text = "Cut Background";
			this.checkBoxCutBackground.UseVisualStyleBackColor = true;
			this.checkBoxBackground.AutoSize = true;
			this.checkBoxBackground.Location = new global::System.Drawing.Point(6, 40);
			this.checkBoxBackground.Name = "checkBoxBackground";
			this.checkBoxBackground.Size = new global::System.Drawing.Size(84, 16);
			this.checkBoxBackground.TabIndex = 20;
			this.checkBoxBackground.Text = "Background";
			this.checkBoxBackground.UseVisualStyleBackColor = true;
			this.checkBoxCutForeground.AutoSize = true;
			this.checkBoxCutForeground.Location = new global::System.Drawing.Point(6, 62);
			this.checkBoxCutForeground.Name = "checkBoxCutForeground";
			this.checkBoxCutForeground.Size = new global::System.Drawing.Size(103, 16);
			this.checkBoxCutForeground.TabIndex = 20;
			this.checkBoxCutForeground.Text = "Cut Foreground";
			this.checkBoxCutForeground.UseVisualStyleBackColor = true;
			this.checkBoxForeground.AutoSize = true;
			this.checkBoxForeground.Location = new global::System.Drawing.Point(6, 18);
			this.checkBoxForeground.Name = "checkBoxForeground";
			this.checkBoxForeground.Size = new global::System.Drawing.Size(81, 16);
			this.checkBoxForeground.TabIndex = 20;
			this.checkBoxForeground.Text = "Foreground";
			this.checkBoxForeground.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(836, 335);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonDown);
			base.Controls.Add(this.buttonUp);
			base.Controls.Add(this.buttonUncheck);
			base.Controls.Add(this.buttonCheck);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBoxFilter);
			base.Controls.Add(this.groupBoxText);
			base.Controls.Add(this.groupBoxSize);
			base.Controls.Add(this.groupBoxView);
			base.Name = "FilterLegendForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Filter Legend";
			base.Load += new global::System.EventHandler(this.FilterLegendForm_Load);
			this.groupBoxView.ResumeLayout(false);
			this.groupBoxSize.ResumeLayout(false);
			this.groupBoxSize.PerformLayout();
			this.groupBoxText.ResumeLayout(false);
			this.groupBoxFilter.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000BC RID: 188
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.GroupBox groupBoxView;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.ComboBox comboBoxView;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.GroupBox groupBoxSize;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.TextBox textBoxHeight;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.TextBox textBoxWidth;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Label labelHeight;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Label labelWidth;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.GroupBox groupBoxText;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.ComboBox comboBoxText;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.GroupBox groupBoxFilter;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.CheckedListBox checkedListBoxFilters;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Button buttonOK;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Button buttonCheck;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Button buttonUncheck;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Button buttonUp;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Button buttonDown;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Button buttonCancel;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.CheckBox checkBoxCutBackground;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.CheckBox checkBoxBackground;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.CheckBox checkBoxCutForeground;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.CheckBox checkBoxForeground;
	}
}
