namespace ONES
{
	// Token: 0x0200000F RID: 15
	public partial class HealthCheckFormOld : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00008280 File Offset: 0x00006480
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000082A0 File Offset: 0x000064A0
		private void InitializeComponent()
		{
			this.listBoxCategories = new global::System.Windows.Forms.ListBox();
			this.labelCategory = new global::System.Windows.Forms.Label();
			this.labelReport = new global::System.Windows.Forms.Label();
			this.labelResult = new global::System.Windows.Forms.Label();
			this.buttonShow = new global::System.Windows.Forms.Button();
			this.listViewResults = new global::System.Windows.Forms.ListView();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new global::System.Windows.Forms.ColumnHeader();
			this.treeView1 = new global::System.Windows.Forms.TreeView();
			this.labelTreeView = new global::System.Windows.Forms.Label();
			this.labelDevelopment = new global::System.Windows.Forms.Label();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.pictureBoxWarnings = new global::System.Windows.Forms.PictureBox();
			this.labelWarnings = new global::System.Windows.Forms.Label();
			this.labelCountWarnings = new global::System.Windows.Forms.Label();
			this.pictureBoxInPlace = new global::System.Windows.Forms.PictureBox();
			this.labelInPlace = new global::System.Windows.Forms.Label();
			this.labelCountInPlace = new global::System.Windows.Forms.Label();
			this.pictureBoxCAD = new global::System.Windows.Forms.PictureBox();
			this.labelCAD = new global::System.Windows.Forms.Label();
			this.labelCountCAD = new global::System.Windows.Forms.Label();
			this.pictureBoxFileSize = new global::System.Windows.Forms.PictureBox();
			this.labelFileSize = new global::System.Windows.Forms.Label();
			this.labelCountFileSize = new global::System.Windows.Forms.Label();
			this.pictureBoxTotalViews = new global::System.Windows.Forms.PictureBox();
			this.labelTotalViews = new global::System.Windows.Forms.Label();
			this.labelCountTotalViews = new global::System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarnings).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInPlace).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCAD).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxFileSize).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxTotalViews).BeginInit();
			base.SuspendLayout();
			this.listBoxCategories.Font = new global::System.Drawing.Font("Arial Narrow", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBoxCategories.FormattingEnabled = true;
			this.listBoxCategories.ItemHeight = 20;
			this.listBoxCategories.Location = new global::System.Drawing.Point(6, 33);
			this.listBoxCategories.Name = "listBoxCategories";
			this.listBoxCategories.Size = new global::System.Drawing.Size(275, 544);
			this.listBoxCategories.TabIndex = 0;
			this.listBoxCategories.SelectedIndexChanged += new global::System.EventHandler(this.listBoxCategories_SelectedIndexChanged);
			this.labelCategory.AutoSize = true;
			this.labelCategory.Font = new global::System.Drawing.Font("Arial Narrow", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelCategory.Location = new global::System.Drawing.Point(108, 10);
			this.labelCategory.Name = "labelCategory";
			this.labelCategory.Size = new global::System.Drawing.Size(58, 20);
			this.labelCategory.TabIndex = 2;
			this.labelCategory.Text = "Category";
			this.labelCategory.Click += new global::System.EventHandler(this.label1_Click);
			this.labelReport.AutoSize = true;
			this.labelReport.Font = new global::System.Drawing.Font("Arial Narrow", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelReport.Location = new global::System.Drawing.Point(458, 10);
			this.labelReport.Name = "labelReport";
			this.labelReport.Size = new global::System.Drawing.Size(46, 20);
			this.labelReport.TabIndex = 3;
			this.labelReport.Text = "Report";
			this.labelResult.AutoSize = true;
			this.labelResult.Font = new global::System.Drawing.Font("Arial Narrow", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelResult.Location = new global::System.Drawing.Point(264, 623);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new global::System.Drawing.Size(70, 29);
			this.labelResult.TabIndex = 4;
			this.labelResult.Text = "% 100";
			this.labelResult.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelResult.Click += new global::System.EventHandler(this.labelResult_Click);
			this.buttonShow.Location = new global::System.Drawing.Point(355, 623);
			this.buttonShow.Name = "buttonShow";
			this.buttonShow.Size = new global::System.Drawing.Size(75, 26);
			this.buttonShow.TabIndex = 5;
			this.buttonShow.Text = "Show";
			this.buttonShow.UseVisualStyleBackColor = true;
			this.buttonShow.Click += new global::System.EventHandler(this.buttonShow_Click);
			this.listViewResults.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2,
				this.columnHeader3,
				this.columnHeader4
			});
			this.listViewResults.GridLines = true;
			this.listViewResults.HideSelection = false;
			this.listViewResults.Location = new global::System.Drawing.Point(301, 33);
			this.listViewResults.Name = "listViewResults";
			this.listViewResults.Size = new global::System.Drawing.Size(451, 543);
			this.listViewResults.TabIndex = 6;
			this.listViewResults.UseCompatibleStateImageBehavior = false;
			this.listViewResults.View = global::System.Windows.Forms.View.Details;
			this.listViewResults.SelectedIndexChanged += new global::System.EventHandler(this.listViewResults_SelectedIndexChanged);
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 120;
			this.columnHeader2.Text = "ID";
			this.columnHeader2.Width = 120;
			this.columnHeader3.Text = "View";
			this.columnHeader3.Width = 120;
			this.columnHeader4.Text = "CH1";
			this.columnHeader4.Width = 90;
			this.treeView1.Location = new global::System.Drawing.Point(6, 26);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new global::System.Drawing.Size(397, 545);
			this.treeView1.TabIndex = 7;
			this.labelTreeView.AutoSize = true;
			this.labelTreeView.Font = new global::System.Drawing.Font("Arial Narrow", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelTreeView.Location = new global::System.Drawing.Point(178, 3);
			this.labelTreeView.Name = "labelTreeView";
			this.labelTreeView.Size = new global::System.Drawing.Size(62, 20);
			this.labelTreeView.TabIndex = 3;
			this.labelTreeView.Text = "TreeView";
			this.labelDevelopment.AutoSize = true;
			this.labelDevelopment.ForeColor = global::System.Drawing.Color.Red;
			this.labelDevelopment.Location = new global::System.Drawing.Point(649, 636);
			this.labelDevelopment.Name = "labelDevelopment";
			this.labelDevelopment.Size = new global::System.Drawing.Size(105, 12);
			this.labelDevelopment.TabIndex = 8;
			this.labelDevelopment.Text = "Under Development";
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new global::System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(766, 608);
			this.tabControl1.TabIndex = 9;
			this.tabPage1.Controls.Add(this.listBoxCategories);
			this.tabPage1.Controls.Add(this.labelCategory);
			this.tabPage1.Controls.Add(this.labelReport);
			this.tabPage1.Controls.Add(this.listViewResults);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(758, 582);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.Controls.Add(this.treeView1);
			this.tabPage2.Controls.Add(this.labelTreeView);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(758, 582);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage3.Controls.Add(this.labelCountTotalViews);
			this.tabPage3.Controls.Add(this.labelCountFileSize);
			this.tabPage3.Controls.Add(this.labelCountCAD);
			this.tabPage3.Controls.Add(this.labelCountInPlace);
			this.tabPage3.Controls.Add(this.labelTotalViews);
			this.tabPage3.Controls.Add(this.labelFileSize);
			this.tabPage3.Controls.Add(this.labelCAD);
			this.tabPage3.Controls.Add(this.labelInPlace);
			this.tabPage3.Controls.Add(this.labelCountWarnings);
			this.tabPage3.Controls.Add(this.pictureBoxTotalViews);
			this.tabPage3.Controls.Add(this.pictureBoxFileSize);
			this.tabPage3.Controls.Add(this.pictureBoxCAD);
			this.tabPage3.Controls.Add(this.pictureBoxInPlace);
			this.tabPage3.Controls.Add(this.labelWarnings);
			this.tabPage3.Controls.Add(this.pictureBoxWarnings);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new global::System.Drawing.Size(758, 582);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.pictureBoxWarnings.Location = new global::System.Drawing.Point(25, 17);
			this.pictureBoxWarnings.Name = "pictureBoxWarnings";
			this.pictureBoxWarnings.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxWarnings.TabIndex = 0;
			this.pictureBoxWarnings.TabStop = false;
			this.labelWarnings.AutoSize = true;
			this.labelWarnings.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelWarnings.Location = new global::System.Drawing.Point(36, 116);
			this.labelWarnings.Name = "labelWarnings";
			this.labelWarnings.Size = new global::System.Drawing.Size(75, 16);
			this.labelWarnings.TabIndex = 1;
			this.labelWarnings.Text = "Warnings";
			this.labelCountWarnings.AutoSize = true;
			this.labelCountWarnings.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountWarnings.Location = new global::System.Drawing.Point(57, 75);
			this.labelCountWarnings.Name = "labelCountWarnings";
			this.labelCountWarnings.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountWarnings.TabIndex = 1;
			this.labelCountWarnings.Text = "0";
			this.pictureBoxInPlace.Location = new global::System.Drawing.Point(143, 17);
			this.pictureBoxInPlace.Name = "pictureBoxInPlace";
			this.pictureBoxInPlace.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxInPlace.TabIndex = 0;
			this.pictureBoxInPlace.TabStop = false;
			this.labelInPlace.AutoSize = true;
			this.labelInPlace.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelInPlace.Location = new global::System.Drawing.Point(154, 116);
			this.labelInPlace.Name = "labelInPlace";
			this.labelInPlace.Size = new global::System.Drawing.Size(73, 16);
			this.labelInPlace.TabIndex = 1;
			this.labelInPlace.Text = "In-Place";
			this.labelCountInPlace.AutoSize = true;
			this.labelCountInPlace.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountInPlace.Location = new global::System.Drawing.Point(175, 75);
			this.labelCountInPlace.Name = "labelCountInPlace";
			this.labelCountInPlace.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountInPlace.TabIndex = 1;
			this.labelCountInPlace.Text = "0";
			this.pictureBoxCAD.Location = new global::System.Drawing.Point(271, 17);
			this.pictureBoxCAD.Name = "pictureBoxCAD";
			this.pictureBoxCAD.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxCAD.TabIndex = 0;
			this.pictureBoxCAD.TabStop = false;
			this.labelCAD.AutoSize = true;
			this.labelCAD.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCAD.Location = new global::System.Drawing.Point(282, 116);
			this.labelCAD.Name = "labelCAD";
			this.labelCAD.Size = new global::System.Drawing.Size(106, 16);
			this.labelCAD.TabIndex = 1;
			this.labelCAD.Text = "CAD Imports";
			this.labelCountCAD.AutoSize = true;
			this.labelCountCAD.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountCAD.Location = new global::System.Drawing.Point(303, 75);
			this.labelCountCAD.Name = "labelCountCAD";
			this.labelCountCAD.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountCAD.TabIndex = 1;
			this.labelCountCAD.Text = "0";
			this.pictureBoxFileSize.Location = new global::System.Drawing.Point(406, 17);
			this.pictureBoxFileSize.Name = "pictureBoxFileSize";
			this.pictureBoxFileSize.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxFileSize.TabIndex = 0;
			this.pictureBoxFileSize.TabStop = false;
			this.labelFileSize.AutoSize = true;
			this.labelFileSize.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelFileSize.Location = new global::System.Drawing.Point(417, 116);
			this.labelFileSize.Name = "labelFileSize";
			this.labelFileSize.Size = new global::System.Drawing.Size(73, 16);
			this.labelFileSize.TabIndex = 1;
			this.labelFileSize.Text = "File Size";
			this.labelCountFileSize.AutoSize = true;
			this.labelCountFileSize.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountFileSize.Location = new global::System.Drawing.Point(438, 75);
			this.labelCountFileSize.Name = "labelCountFileSize";
			this.labelCountFileSize.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountFileSize.TabIndex = 1;
			this.labelCountFileSize.Text = "0";
			this.pictureBoxTotalViews.Location = new global::System.Drawing.Point(528, 17);
			this.pictureBoxTotalViews.Name = "pictureBoxTotalViews";
			this.pictureBoxTotalViews.Size = new global::System.Drawing.Size(96, 96);
			this.pictureBoxTotalViews.TabIndex = 0;
			this.pictureBoxTotalViews.TabStop = false;
			this.labelTotalViews.AutoSize = true;
			this.labelTotalViews.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelTotalViews.Location = new global::System.Drawing.Point(539, 116);
			this.labelTotalViews.Name = "labelTotalViews";
			this.labelTotalViews.Size = new global::System.Drawing.Size(75, 16);
			this.labelTotalViews.TabIndex = 1;
			this.labelTotalViews.Text = "Warnings";
			this.labelCountTotalViews.AutoSize = true;
			this.labelCountTotalViews.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCountTotalViews.Location = new global::System.Drawing.Point(560, 75);
			this.labelCountTotalViews.Name = "labelCountTotalViews";
			this.labelCountTotalViews.Size = new global::System.Drawing.Size(17, 16);
			this.labelCountTotalViews.TabIndex = 1;
			this.labelCountTotalViews.Text = "0";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(799, 661);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.labelDevelopment);
			base.Controls.Add(this.buttonShow);
			base.Controls.Add(this.labelResult);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "HealthCheckForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Health Check";
			base.Load += new global::System.EventHandler(this.HealthCheckForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarnings).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInPlace).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCAD).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxFileSize).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxTotalViews).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000022 RID: 34
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.ListBox listBoxCategories;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Label labelCategory;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Label labelReport;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label labelResult;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Button buttonShow;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.ListView listViewResults;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.ColumnHeader columnHeader2;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.ColumnHeader columnHeader3;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.ColumnHeader columnHeader4;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.TreeView treeView1;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Label labelTreeView;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.Label labelDevelopment;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.PictureBox pictureBoxWarnings;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label labelWarnings;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label labelCountWarnings;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Label labelCountTotalViews;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Label labelCountFileSize;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Label labelCountCAD;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Label labelCountInPlace;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.Label labelTotalViews;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Label labelFileSize;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Label labelCAD;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.Label labelInPlace;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.PictureBox pictureBoxTotalViews;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.PictureBox pictureBoxFileSize;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.PictureBox pictureBoxCAD;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.PictureBox pictureBoxInPlace;
	}
}
