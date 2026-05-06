namespace ONES
{
	// Token: 0x02000070 RID: 112
	public partial class JoinElementsForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600026E RID: 622 RVA: 0x00027AB4 File Offset: 0x00025CB4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00027AD4 File Offset: 0x00025CD4
		private void InitializeComponent()
		{
			this.labelTop = new global::System.Windows.Forms.Label();
			this.labelBottom = new global::System.Windows.Forms.Label();
			this.groupBoxElements = new global::System.Windows.Forms.GroupBox();
			this.radioButtonAView = new global::System.Windows.Forms.RadioButton();
			this.radioButtonAll = new global::System.Windows.Forms.RadioButton();
			this.buttonJoin = new global::System.Windows.Forms.Button();
			this.comboBoxTop = new global::System.Windows.Forms.ComboBox();
			this.comboBoxBottom = new global::System.Windows.Forms.ComboBox();
			this.groupBoxIntersection = new global::System.Windows.Forms.GroupBox();
			this.radioButtonBoundingBox = new global::System.Windows.Forms.RadioButton();
			this.radioButtonGeometry = new global::System.Windows.Forms.RadioButton();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.groupBoxElements.SuspendLayout();
			this.groupBoxIntersection.SuspendLayout();
			base.SuspendLayout();
			this.labelTop.AutoSize = true;
			this.labelTop.Font = new global::System.Drawing.Font("MS UI Gothic", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelTop.Location = new global::System.Drawing.Point(54, 11);
			this.labelTop.Name = "labelTop";
			this.labelTop.Size = new global::System.Drawing.Size(116, 13);
			this.labelTop.TabIndex = 1;
			this.labelTop.Text = "Category on Top";
			this.labelBottom.AutoSize = true;
			this.labelBottom.Font = new global::System.Drawing.Font("MS UI Gothic", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelBottom.Location = new global::System.Drawing.Point(42, 70);
			this.labelBottom.Name = "labelBottom";
			this.labelBottom.Size = new global::System.Drawing.Size(140, 13);
			this.labelBottom.TabIndex = 2;
			this.labelBottom.Text = "Category on Bottom";
			this.groupBoxElements.Controls.Add(this.radioButtonAView);
			this.groupBoxElements.Controls.Add(this.radioButtonAll);
			this.groupBoxElements.Location = new global::System.Drawing.Point(20, 125);
			this.groupBoxElements.Name = "groupBoxElements";
			this.groupBoxElements.Size = new global::System.Drawing.Size(202, 43);
			this.groupBoxElements.TabIndex = 4;
			this.groupBoxElements.TabStop = false;
			this.groupBoxElements.Text = "Elements to be Selected";
			this.radioButtonAView.AutoSize = true;
			this.radioButtonAView.Location = new global::System.Drawing.Point(12, 21);
			this.radioButtonAView.Name = "radioButtonAView";
			this.radioButtonAView.Size = new global::System.Drawing.Size(85, 16);
			this.radioButtonAView.TabIndex = 5;
			this.radioButtonAView.TabStop = true;
			this.radioButtonAView.Text = "Active View";
			this.radioButtonAView.UseVisualStyleBackColor = true;
			this.radioButtonAll.AutoSize = true;
			this.radioButtonAll.Location = new global::System.Drawing.Point(106, 18);
			this.radioButtonAll.Name = "radioButtonAll";
			this.radioButtonAll.Size = new global::System.Drawing.Size(77, 16);
			this.radioButtonAll.TabIndex = 0;
			this.radioButtonAll.TabStop = true;
			this.radioButtonAll.Text = "All Project";
			this.radioButtonAll.UseVisualStyleBackColor = true;
			this.buttonJoin.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonJoin.Location = new global::System.Drawing.Point(143, 223);
			this.buttonJoin.Name = "buttonJoin";
			this.buttonJoin.Size = new global::System.Drawing.Size(77, 26);
			this.buttonJoin.TabIndex = 5;
			this.buttonJoin.Text = "Join";
			this.buttonJoin.UseVisualStyleBackColor = false;
			this.buttonJoin.Click += new global::System.EventHandler(this.buttonJoin_Click);
			this.comboBoxTop.FormattingEnabled = true;
			this.comboBoxTop.Location = new global::System.Drawing.Point(35, 27);
			this.comboBoxTop.Name = "comboBoxTop";
			this.comboBoxTop.Size = new global::System.Drawing.Size(147, 20);
			this.comboBoxTop.TabIndex = 6;
			this.comboBoxBottom.FormattingEnabled = true;
			this.comboBoxBottom.Location = new global::System.Drawing.Point(35, 86);
			this.comboBoxBottom.Name = "comboBoxBottom";
			this.comboBoxBottom.Size = new global::System.Drawing.Size(147, 20);
			this.comboBoxBottom.TabIndex = 7;
			this.groupBoxIntersection.Controls.Add(this.radioButtonBoundingBox);
			this.groupBoxIntersection.Controls.Add(this.radioButtonGeometry);
			this.groupBoxIntersection.Location = new global::System.Drawing.Point(20, 174);
			this.groupBoxIntersection.Name = "groupBoxIntersection";
			this.groupBoxIntersection.Size = new global::System.Drawing.Size(202, 43);
			this.groupBoxIntersection.TabIndex = 4;
			this.groupBoxIntersection.TabStop = false;
			this.groupBoxIntersection.Text = "Intersection Type (Optional)";
			this.radioButtonBoundingBox.AutoSize = true;
			this.radioButtonBoundingBox.Location = new global::System.Drawing.Point(106, 20);
			this.radioButtonBoundingBox.Name = "radioButtonBoundingBox";
			this.radioButtonBoundingBox.Size = new global::System.Drawing.Size(94, 16);
			this.radioButtonBoundingBox.TabIndex = 5;
			this.radioButtonBoundingBox.TabStop = true;
			this.radioButtonBoundingBox.Text = "Bounding Box";
			this.radioButtonBoundingBox.UseVisualStyleBackColor = true;
			this.radioButtonGeometry.AutoSize = true;
			this.radioButtonGeometry.Location = new global::System.Drawing.Point(12, 20);
			this.radioButtonGeometry.Name = "radioButtonGeometry";
			this.radioButtonGeometry.Size = new global::System.Drawing.Size(72, 16);
			this.radioButtonGeometry.TabIndex = 0;
			this.radioButtonGeometry.TabStop = true;
			this.radioButtonGeometry.Text = "Geometry";
			this.radioButtonGeometry.UseVisualStyleBackColor = true;
			this.buttonClose.Location = new global::System.Drawing.Point(20, 223);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(70, 26);
			this.buttonClose.TabIndex = 25;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new global::System.EventHandler(this.buttonClose_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(234, 256);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.comboBoxBottom);
			base.Controls.Add(this.comboBoxTop);
			base.Controls.Add(this.buttonJoin);
			base.Controls.Add(this.groupBoxIntersection);
			base.Controls.Add(this.groupBoxElements);
			base.Controls.Add(this.labelBottom);
			base.Controls.Add(this.labelTop);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "JoinElementsForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Join Elements";
			base.Load += new global::System.EventHandler(this.JoinElementsForm_Load);
			this.groupBoxElements.ResumeLayout(false);
			this.groupBoxElements.PerformLayout();
			this.groupBoxIntersection.ResumeLayout(false);
			this.groupBoxIntersection.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001B9 RID: 441
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.Label labelTop;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.Label labelBottom;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.GroupBox groupBoxElements;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.RadioButton radioButtonAView;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.RadioButton radioButtonAll;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.Button buttonJoin;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.ComboBox comboBoxTop;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.ComboBox comboBoxBottom;

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.GroupBox groupBoxIntersection;

		// Token: 0x040001C3 RID: 451
		private global::System.Windows.Forms.RadioButton radioButtonBoundingBox;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.RadioButton radioButtonGeometry;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.Button buttonClose;
	}
}
