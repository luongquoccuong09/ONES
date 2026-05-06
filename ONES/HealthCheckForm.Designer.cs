namespace ONES
{
	// Token: 0x0200008F RID: 143
	public partial class HealthCheckForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600036E RID: 878 RVA: 0x0003553C File Offset: 0x0003373C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0003555C File Offset: 0x0003375C
		private void InitializeComponent()
		{
			this.labelDevelopment = new global::System.Windows.Forms.Label();
			this.labelPerAdvisor = new global::System.Windows.Forms.Label();
			this.labelCountFilters = new global::System.Windows.Forms.Label();
			this.labelCountTotalViews = new global::System.Windows.Forms.Label();
			this.labelCountFileSize = new global::System.Windows.Forms.Label();
			this.labelCountCAD = new global::System.Windows.Forms.Label();
			this.labelCountPerAdvisor = new global::System.Windows.Forms.Label();
			this.labelCountInPlace = new global::System.Windows.Forms.Label();
			this.labelFilters = new global::System.Windows.Forms.Label();
			this.labelTotalViews = new global::System.Windows.Forms.Label();
			this.labelFileSize = new global::System.Windows.Forms.Label();
			this.labelCAD = new global::System.Windows.Forms.Label();
			this.labelInPlace = new global::System.Windows.Forms.Label();
			this.pictureBoxPerAdvisor = new global::System.Windows.Forms.PictureBox();
			this.labelCountWarningElements = new global::System.Windows.Forms.Label();
			this.labelCountWarnings = new global::System.Windows.Forms.Label();
			this.pictureBoxFilters = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxTotalViews = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxFileSize = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxCAD = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxInPlace = new global::System.Windows.Forms.PictureBox();
			this.labelWarningElements = new global::System.Windows.Forms.Label();
			this.labelWarnings = new global::System.Windows.Forms.Label();
			this.pictureBoxWarningElements = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxWarnings = new global::System.Windows.Forms.PictureBox();
			this.groupBoxPerformance = new global::System.Windows.Forms.GroupBox();
			this.groupBoxSize = new global::System.Windows.Forms.GroupBox();
			this.labelFamilyPurge = new global::System.Windows.Forms.Label();
			this.labelFamily = new global::System.Windows.Forms.Label();
			this.groupBoxLink = new global::System.Windows.Forms.GroupBox();
			this.groupBoxDev = new global::System.Windows.Forms.GroupBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPerAdvisor).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxFilters).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxTotalViews).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxFileSize).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCAD).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInPlace).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarningElements).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarnings).BeginInit();
			this.groupBoxPerformance.SuspendLayout();
			this.groupBoxSize.SuspendLayout();
			this.groupBoxLink.SuspendLayout();
			this.groupBoxDev.SuspendLayout();
			base.SuspendLayout();
			this.labelDevelopment.AutoSize = true;
			this.labelDevelopment.ForeColor = global::System.Drawing.Color.Red;
			this.labelDevelopment.Location = new global::System.Drawing.Point(649, 636);
			this.labelDevelopment.Name = "labelDevelopment";
			this.labelDevelopment.Size = new global::System.Drawing.Size(105, 12);
			this.labelDevelopment.TabIndex = 8;
			this.labelDevelopment.Text = "Under Development";
			this.labelPerAdvisor.AutoSize = true;
			this.labelPerAdvisor.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelPerAdvisor.Location = new global::System.Drawing.Point(38, 76);
			this.labelPerAdvisor.Name = "labelPerAdvisor";
			this.labelPerAdvisor.Size = new global::System.Drawing.Size(17, 16);
			this.labelPerAdvisor.TabIndex = 1;
			this.labelPerAdvisor.Text = "0";
			this.labelCountFilters.AutoSize = true;
			this.labelCountFilters.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountFilters.Location = new global::System.Drawing.Point(38, 76);
			this.labelCountFilters.Name = "labelCountFilters";
			this.labelCountFilters.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountFilters.TabIndex = 1;
			this.labelCountFilters.Text = "0";
			this.labelCountTotalViews.AutoSize = true;
			this.labelCountTotalViews.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountTotalViews.Location = new global::System.Drawing.Point(170, 76);
			this.labelCountTotalViews.Name = "labelCountTotalViews";
			this.labelCountTotalViews.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountTotalViews.TabIndex = 1;
			this.labelCountTotalViews.Text = "0";
			this.labelCountFileSize.AutoSize = true;
			this.labelCountFileSize.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountFileSize.Location = new global::System.Drawing.Point(298, 76);
			this.labelCountFileSize.Name = "labelCountFileSize";
			this.labelCountFileSize.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountFileSize.TabIndex = 1;
			this.labelCountFileSize.Text = "0";
			this.labelCountCAD.AutoSize = true;
			this.labelCountCAD.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountCAD.Location = new global::System.Drawing.Point(38, 76);
			this.labelCountCAD.Name = "labelCountCAD";
			this.labelCountCAD.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountCAD.TabIndex = 1;
			this.labelCountCAD.Text = "0";
			this.labelCountPerAdvisor.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountPerAdvisor.Location = new global::System.Drawing.Point(3, 117);
			this.labelCountPerAdvisor.Name = "labelCountPerAdvisor";
			this.labelCountPerAdvisor.Size = new global::System.Drawing.Size(118, 37);
			this.labelCountPerAdvisor.TabIndex = 1;
			this.labelCountPerAdvisor.Text = "Performance Advisor";
			this.labelCountPerAdvisor.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelCountInPlace.AutoSize = true;
			this.labelCountInPlace.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountInPlace.Location = new global::System.Drawing.Point(303, 76);
			this.labelCountInPlace.Name = "labelCountInPlace";
			this.labelCountInPlace.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountInPlace.TabIndex = 1;
			this.labelCountInPlace.Text = "0";
			this.labelFilters.AutoSize = true;
			this.labelFilters.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelFilters.Location = new global::System.Drawing.Point(3, 117);
			this.labelFilters.Name = "labelFilters";
			this.labelFilters.Size = new global::System.Drawing.Size(118, 16);
			this.labelFilters.TabIndex = 1;
			this.labelFilters.Text = "Unused Filters";
			this.labelFilters.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelTotalViews.AutoSize = true;
			this.labelTotalViews.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelTotalViews.Location = new global::System.Drawing.Point(149, 117);
			this.labelTotalViews.Name = "labelTotalViews";
			this.labelTotalViews.Size = new global::System.Drawing.Size(96, 16);
			this.labelTotalViews.TabIndex = 1;
			this.labelTotalViews.Text = "Total Views";
			this.labelTotalViews.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelFileSize.AutoSize = true;
			this.labelFileSize.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelFileSize.Location = new global::System.Drawing.Point(277, 117);
			this.labelFileSize.Name = "labelFileSize";
			this.labelFileSize.Size = new global::System.Drawing.Size(73, 16);
			this.labelFileSize.TabIndex = 1;
			this.labelFileSize.Text = "File Size";
			this.labelFileSize.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelCAD.AutoSize = true;
			this.labelCAD.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCAD.Location = new global::System.Drawing.Point(6, 117);
			this.labelCAD.Name = "labelCAD";
			this.labelCAD.Size = new global::System.Drawing.Size(106, 16);
			this.labelCAD.TabIndex = 1;
			this.labelCAD.Text = "CAD Imports";
			this.labelCAD.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelInPlace.AutoSize = true;
			this.labelInPlace.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelInPlace.Location = new global::System.Drawing.Point(282, 117);
			this.labelInPlace.Name = "labelInPlace";
			this.labelInPlace.Size = new global::System.Drawing.Size(73, 16);
			this.labelInPlace.TabIndex = 1;
			this.labelInPlace.Text = "In-Place";
			this.labelInPlace.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pictureBoxPerAdvisor.Location = new global::System.Drawing.Point(11, 18);
			this.pictureBoxPerAdvisor.Name = "pictureBoxPerAdvisor";
			this.pictureBoxPerAdvisor.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxPerAdvisor.TabIndex = 0;
			this.pictureBoxPerAdvisor.TabStop = false;
			this.labelCountWarningElements.AutoSize = true;
			this.labelCountWarningElements.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountWarningElements.Location = new global::System.Drawing.Point(175, 76);
			this.labelCountWarningElements.Name = "labelCountWarningElements";
			this.labelCountWarningElements.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountWarningElements.TabIndex = 1;
			this.labelCountWarningElements.Text = "0";
			this.labelCountWarnings.AutoSize = true;
			this.labelCountWarnings.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountWarnings.Location = new global::System.Drawing.Point(43, 76);
			this.labelCountWarnings.Name = "labelCountWarnings";
			this.labelCountWarnings.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountWarnings.TabIndex = 1;
			this.labelCountWarnings.Text = "0";
			this.pictureBoxFilters.Location = new global::System.Drawing.Point(11, 18);
			this.pictureBoxFilters.Name = "pictureBoxFilters";
			this.pictureBoxFilters.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxFilters.TabIndex = 0;
			this.pictureBoxFilters.TabStop = false;
			this.pictureBoxTotalViews.Location = new global::System.Drawing.Point(138, 18);
			this.pictureBoxTotalViews.Name = "pictureBoxTotalViews";
			this.pictureBoxTotalViews.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxTotalViews.TabIndex = 0;
			this.pictureBoxTotalViews.TabStop = false;
			this.pictureBoxFileSize.Location = new global::System.Drawing.Point(266, 18);
			this.pictureBoxFileSize.Name = "pictureBoxFileSize";
			this.pictureBoxFileSize.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxFileSize.TabIndex = 0;
			this.pictureBoxFileSize.TabStop = false;
			this.pictureBoxCAD.Location = new global::System.Drawing.Point(11, 18);
			this.pictureBoxCAD.Name = "pictureBoxCAD";
			this.pictureBoxCAD.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxCAD.TabIndex = 0;
			this.pictureBoxCAD.TabStop = false;
			this.pictureBoxInPlace.Location = new global::System.Drawing.Point(271, 18);
			this.pictureBoxInPlace.Name = "pictureBoxInPlace";
			this.pictureBoxInPlace.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxInPlace.TabIndex = 0;
			this.pictureBoxInPlace.TabStop = false;
			this.labelWarningElements.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelWarningElements.Location = new global::System.Drawing.Point(154, 117);
			this.labelWarningElements.Name = "labelWarningElements";
			this.labelWarningElements.Size = new global::System.Drawing.Size(75, 37);
			this.labelWarningElements.TabIndex = 1;
			this.labelWarningElements.Text = "Warning Elements";
			this.labelWarningElements.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelWarnings.AutoSize = true;
			this.labelWarnings.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelWarnings.Location = new global::System.Drawing.Point(22, 117);
			this.labelWarnings.Name = "labelWarnings";
			this.labelWarnings.Size = new global::System.Drawing.Size(75, 16);
			this.labelWarnings.TabIndex = 1;
			this.labelWarnings.Text = "Warnings";
			this.labelWarnings.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pictureBoxWarningElements.Location = new global::System.Drawing.Point(143, 18);
			this.pictureBoxWarningElements.Name = "pictureBoxWarningElements";
			this.pictureBoxWarningElements.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxWarningElements.TabIndex = 0;
			this.pictureBoxWarningElements.TabStop = false;
			this.pictureBoxWarnings.Location = new global::System.Drawing.Point(11, 18);
			this.pictureBoxWarnings.Name = "pictureBoxWarnings";
			this.pictureBoxWarnings.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxWarnings.TabIndex = 0;
			this.pictureBoxWarnings.TabStop = false;
			this.groupBoxPerformance.Controls.Add(this.labelWarnings);
			this.groupBoxPerformance.Controls.Add(this.labelWarningElements);
			this.groupBoxPerformance.Controls.Add(this.labelCountWarnings);
			this.groupBoxPerformance.Controls.Add(this.labelCountWarningElements);
			this.groupBoxPerformance.Controls.Add(this.labelCountInPlace);
			this.groupBoxPerformance.Controls.Add(this.labelInPlace);
			this.groupBoxPerformance.Controls.Add(this.pictureBoxWarnings);
			this.groupBoxPerformance.Controls.Add(this.pictureBoxWarningElements);
			this.groupBoxPerformance.Controls.Add(this.pictureBoxInPlace);
			this.groupBoxPerformance.Location = new global::System.Drawing.Point(12, 12);
			this.groupBoxPerformance.Name = "groupBoxPerformance";
			this.groupBoxPerformance.Size = new global::System.Drawing.Size(380, 167);
			this.groupBoxPerformance.TabIndex = 2;
			this.groupBoxPerformance.TabStop = false;
			this.groupBoxPerformance.Text = "Performance";
			this.groupBoxSize.Controls.Add(this.labelCountFilters);
			this.groupBoxSize.Controls.Add(this.labelFamilyPurge);
			this.groupBoxSize.Controls.Add(this.labelFamily);
			this.groupBoxSize.Controls.Add(this.labelFileSize);
			this.groupBoxSize.Controls.Add(this.labelCountTotalViews);
			this.groupBoxSize.Controls.Add(this.labelTotalViews);
			this.groupBoxSize.Controls.Add(this.labelCountFileSize);
			this.groupBoxSize.Controls.Add(this.labelFilters);
			this.groupBoxSize.Controls.Add(this.pictureBoxFilters);
			this.groupBoxSize.Controls.Add(this.pictureBoxFileSize);
			this.groupBoxSize.Controls.Add(this.pictureBoxTotalViews);
			this.groupBoxSize.Location = new global::System.Drawing.Point(12, 189);
			this.groupBoxSize.Name = "groupBoxSize";
			this.groupBoxSize.Size = new global::System.Drawing.Size(756, 145);
			this.groupBoxSize.TabIndex = 3;
			this.groupBoxSize.TabStop = false;
			this.groupBoxSize.Text = "Model Size";
			this.labelFamilyPurge.AutoSize = true;
			this.labelFamilyPurge.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelFamilyPurge.Location = new global::System.Drawing.Point(505, 117);
			this.labelFamilyPurge.Name = "labelFamilyPurge";
			this.labelFamilyPurge.Size = new global::System.Drawing.Size(129, 16);
			this.labelFamilyPurge.TabIndex = 1;
			this.labelFamilyPurge.Text = "Purgable Family";
			this.labelFamilyPurge.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelFamily.AutoSize = true;
			this.labelFamily.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelFamily.Location = new global::System.Drawing.Point(390, 117);
			this.labelFamily.Name = "labelFamily";
			this.labelFamily.Size = new global::System.Drawing.Size(109, 16);
			this.labelFamily.TabIndex = 1;
			this.labelFamily.Text = "Family Count";
			this.labelFamily.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.groupBoxLink.Controls.Add(this.labelCAD);
			this.groupBoxLink.Controls.Add(this.labelCountCAD);
			this.groupBoxLink.Controls.Add(this.pictureBoxCAD);
			this.groupBoxLink.Location = new global::System.Drawing.Point(12, 351);
			this.groupBoxLink.Name = "groupBoxLink";
			this.groupBoxLink.Size = new global::System.Drawing.Size(266, 148);
			this.groupBoxLink.TabIndex = 4;
			this.groupBoxLink.TabStop = false;
			this.groupBoxLink.Text = "Link and Imports";
			this.groupBoxDev.Controls.Add(this.labelCountPerAdvisor);
			this.groupBoxDev.Controls.Add(this.labelPerAdvisor);
			this.groupBoxDev.Controls.Add(this.pictureBoxPerAdvisor);
			this.groupBoxDev.Location = new global::System.Drawing.Point(12, 505);
			this.groupBoxDev.Name = "groupBoxDev";
			this.groupBoxDev.Size = new global::System.Drawing.Size(301, 161);
			this.groupBoxDev.TabIndex = 9;
			this.groupBoxDev.TabStop = false;
			this.groupBoxDev.Text = "Development";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(799, 678);
			base.Controls.Add(this.groupBoxDev);
			base.Controls.Add(this.groupBoxLink);
			base.Controls.Add(this.groupBoxSize);
			base.Controls.Add(this.labelDevelopment);
			base.Controls.Add(this.groupBoxPerformance);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "HealthCheckForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Health Check";
			base.Load += new global::System.EventHandler(this.HealthCheckForm_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPerAdvisor).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxFilters).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxTotalViews).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxFileSize).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCAD).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInPlace).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarningElements).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarnings).EndInit();
			this.groupBoxPerformance.ResumeLayout(false);
			this.groupBoxPerformance.PerformLayout();
			this.groupBoxSize.ResumeLayout(false);
			this.groupBoxSize.PerformLayout();
			this.groupBoxLink.ResumeLayout(false);
			this.groupBoxLink.PerformLayout();
			this.groupBoxDev.ResumeLayout(false);
			this.groupBoxDev.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400026A RID: 618
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.Label labelDevelopment;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.PictureBox pictureBoxWarnings;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.Label labelWarnings;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.Label labelCountWarnings;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.Label labelCountTotalViews;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.Label labelCountFileSize;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.Label labelCountCAD;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.Label labelCountInPlace;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.Label labelTotalViews;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.Label labelFileSize;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.Label labelCAD;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.Label labelInPlace;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.PictureBox pictureBoxTotalViews;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.PictureBox pictureBoxFileSize;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.PictureBox pictureBoxCAD;

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.PictureBox pictureBoxInPlace;

		// Token: 0x0400027B RID: 635
		private global::System.Windows.Forms.Label labelCountFilters;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.Label labelFilters;

		// Token: 0x0400027D RID: 637
		private global::System.Windows.Forms.PictureBox pictureBoxFilters;

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Label labelPerAdvisor;

		// Token: 0x0400027F RID: 639
		private global::System.Windows.Forms.Label labelCountPerAdvisor;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.PictureBox pictureBoxPerAdvisor;

		// Token: 0x04000281 RID: 641
		private global::System.Windows.Forms.Label labelCountWarningElements;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.Label labelWarningElements;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.PictureBox pictureBoxWarningElements;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.GroupBox groupBoxPerformance;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.GroupBox groupBoxSize;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.GroupBox groupBoxLink;

		// Token: 0x04000287 RID: 647
		private global::System.Windows.Forms.GroupBox groupBoxDev;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.Label labelFamilyPurge;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.Label labelFamily;
	}
}
