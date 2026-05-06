namespace ONES
{
	// Token: 0x02000084 RID: 132
	public partial class CopyFiltersForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x0002D3D3 File Offset: 0x0002B5D3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0002D3F4 File Offset: 0x0002B5F4
		private void InitializeComponent()
		{
			this.checkedListBoxFilters = new global::System.Windows.Forms.CheckedListBox();
			this.checkedListBoxViews = new global::System.Windows.Forms.CheckedListBox();
			this.labelFilters = new global::System.Windows.Forms.Label();
			this.labelViews = new global::System.Windows.Forms.Label();
			this.buttonCopy = new global::System.Windows.Forms.Button();
			this.buttonFiltersSA = new global::System.Windows.Forms.Button();
			this.buttonFiltersSN = new global::System.Windows.Forms.Button();
			this.buttonViewsSN = new global::System.Windows.Forms.Button();
			this.buttonViewsSA = new global::System.Windows.Forms.Button();
			this.radioButtonActive = new global::System.Windows.Forms.RadioButton();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.radioButtonAll = new global::System.Windows.Forms.RadioButton();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.checkedListBoxFilters.CheckOnClick = true;
			this.checkedListBoxFilters.FormattingEnabled = true;
			this.checkedListBoxFilters.Location = new global::System.Drawing.Point(12, 43);
			this.checkedListBoxFilters.Name = "checkedListBoxFilters";
			this.checkedListBoxFilters.Size = new global::System.Drawing.Size(260, 326);
			this.checkedListBoxFilters.TabIndex = 0;
			this.checkedListBoxFilters.SelectedIndexChanged += new global::System.EventHandler(this.checkedListBoxFilters_SelectedIndexChanged);
			this.checkedListBoxViews.CheckOnClick = true;
			this.checkedListBoxViews.FormattingEnabled = true;
			this.checkedListBoxViews.Location = new global::System.Drawing.Point(314, 43);
			this.checkedListBoxViews.Name = "checkedListBoxViews";
			this.checkedListBoxViews.Size = new global::System.Drawing.Size(260, 326);
			this.checkedListBoxViews.TabIndex = 1;
			this.labelFilters.AutoSize = true;
			this.labelFilters.Location = new global::System.Drawing.Point(84, 28);
			this.labelFilters.Name = "labelFilters";
			this.labelFilters.Size = new global::System.Drawing.Size(118, 12);
			this.labelFilters.TabIndex = 2;
			this.labelFilters.Text = "Select Filters to Copy";
			this.labelViews.AutoSize = true;
			this.labelViews.Location = new global::System.Drawing.Point(367, 28);
			this.labelViews.Name = "labelViews";
			this.labelViews.Size = new global::System.Drawing.Size(165, 12);
			this.labelViews.TabIndex = 3;
			this.labelViews.Text = "Copy Filters to Selected Views";
			this.buttonCopy.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonCopy.Font = new global::System.Drawing.Font("MS UI Gothic", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.buttonCopy.Location = new global::System.Drawing.Point(252, 423);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new global::System.Drawing.Size(79, 31);
			this.buttonCopy.TabIndex = 4;
			this.buttonCopy.Text = "Copy";
			this.buttonCopy.UseVisualStyleBackColor = false;
			this.buttonCopy.Click += new global::System.EventHandler(this.buttonCopy_Click);
			this.buttonFiltersSA.Location = new global::System.Drawing.Point(12, 428);
			this.buttonFiltersSA.Name = "buttonFiltersSA";
			this.buttonFiltersSA.Size = new global::System.Drawing.Size(93, 23);
			this.buttonFiltersSA.TabIndex = 5;
			this.buttonFiltersSA.Text = "Check All";
			this.buttonFiltersSA.UseVisualStyleBackColor = true;
			this.buttonFiltersSA.Click += new global::System.EventHandler(this.buttonFiltersSA_Click);
			this.buttonFiltersSN.Location = new global::System.Drawing.Point(111, 428);
			this.buttonFiltersSN.Name = "buttonFiltersSN";
			this.buttonFiltersSN.Size = new global::System.Drawing.Size(93, 23);
			this.buttonFiltersSN.TabIndex = 6;
			this.buttonFiltersSN.Text = "Uncheck All";
			this.buttonFiltersSN.UseVisualStyleBackColor = true;
			this.buttonFiltersSN.Click += new global::System.EventHandler(this.buttonFiltersSN_Click);
			this.buttonViewsSN.Location = new global::System.Drawing.Point(481, 428);
			this.buttonViewsSN.Name = "buttonViewsSN";
			this.buttonViewsSN.Size = new global::System.Drawing.Size(93, 23);
			this.buttonViewsSN.TabIndex = 8;
			this.buttonViewsSN.Text = "Uncheck All";
			this.buttonViewsSN.UseVisualStyleBackColor = true;
			this.buttonViewsSN.Click += new global::System.EventHandler(this.buttonViewsSN_Click);
			this.buttonViewsSA.Location = new global::System.Drawing.Point(382, 428);
			this.buttonViewsSA.Name = "buttonViewsSA";
			this.buttonViewsSA.Size = new global::System.Drawing.Size(93, 23);
			this.buttonViewsSA.TabIndex = 7;
			this.buttonViewsSA.Text = "Check All";
			this.buttonViewsSA.UseVisualStyleBackColor = true;
			this.buttonViewsSA.Click += new global::System.EventHandler(this.buttonViewsSA_Click);
			this.radioButtonActive.AutoSize = true;
			this.radioButtonActive.Location = new global::System.Drawing.Point(6, 18);
			this.radioButtonActive.Name = "radioButtonActive";
			this.radioButtonActive.Size = new global::System.Drawing.Size(91, 16);
			this.radioButtonActive.TabIndex = 9;
			this.radioButtonActive.TabStop = true;
			this.radioButtonActive.Text = "Active Views";
			this.radioButtonActive.UseVisualStyleBackColor = true;
			this.radioButtonActive.CheckedChanged += new global::System.EventHandler(this.radioButtonActive_CheckedChanged);
			this.groupBox1.Controls.Add(this.radioButtonAll);
			this.groupBox1.Controls.Add(this.radioButtonActive);
			this.groupBox1.Location = new global::System.Drawing.Point(394, 375);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(180, 47);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Views";
			this.radioButtonAll.AutoSize = true;
			this.radioButtonAll.Location = new global::System.Drawing.Point(103, 20);
			this.radioButtonAll.Name = "radioButtonAll";
			this.radioButtonAll.Size = new global::System.Drawing.Size(72, 16);
			this.radioButtonAll.TabIndex = 10;
			this.radioButtonAll.TabStop = true;
			this.radioButtonAll.Text = "All Views";
			this.radioButtonAll.UseVisualStyleBackColor = true;
			this.radioButtonAll.CheckedChanged += new global::System.EventHandler(this.radioButtonAll_CheckedChanged);
			this.buttonClose.Location = new global::System.Drawing.Point(256, 395);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 11;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(587, 463);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.buttonViewsSN);
			base.Controls.Add(this.buttonViewsSA);
			base.Controls.Add(this.buttonFiltersSN);
			base.Controls.Add(this.buttonFiltersSA);
			base.Controls.Add(this.buttonCopy);
			base.Controls.Add(this.labelViews);
			base.Controls.Add(this.labelFilters);
			base.Controls.Add(this.checkedListBoxViews);
			base.Controls.Add(this.checkedListBoxFilters);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "CopyFiltersForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Copy Filters";
			base.Load += new global::System.EventHandler(this.CopyFIltersForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400021F RID: 543
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.CheckedListBox checkedListBoxFilters;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.CheckedListBox checkedListBoxViews;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.Label labelFilters;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.Label labelViews;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.Button buttonCopy;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.Button buttonFiltersSA;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.Button buttonFiltersSN;

		// Token: 0x04000227 RID: 551
		private global::System.Windows.Forms.Button buttonViewsSN;

		// Token: 0x04000228 RID: 552
		private global::System.Windows.Forms.Button buttonViewsSA;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.RadioButton radioButtonActive;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.RadioButton radioButtonAll;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.Button buttonClose;
	}
}
