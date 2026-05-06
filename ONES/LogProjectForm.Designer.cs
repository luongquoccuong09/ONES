namespace ONES
{
	// Token: 0x0200007A RID: 122
	public partial class LogProjectForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060002C2 RID: 706 RVA: 0x0002A4DC File Offset: 0x000286DC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0002A4FC File Offset: 0x000286FC
		private void InitializeComponent()
		{
			this.listViewLogs = new global::System.Windows.Forms.ListView();
			this.cHName = new global::System.Windows.Forms.ColumnHeader();
			this.cHUser = new global::System.Windows.Forms.ColumnHeader();
			this.cHDate = new global::System.Windows.Forms.ColumnHeader();
			this.cHST = new global::System.Windows.Forms.ColumnHeader();
			this.cHET = new global::System.Windows.Forms.ColumnHeader();
			this.cHSpan = new global::System.Windows.Forms.ColumnHeader();
			this.cHModifySpan = new global::System.Windows.Forms.ColumnHeader();
			this.labelLogs = new global::System.Windows.Forms.Label();
			this.listViewTotal = new global::System.Windows.Forms.ListView();
			this.cHTotalName = new global::System.Windows.Forms.ColumnHeader();
			this.cHTotalSpan = new global::System.Windows.Forms.ColumnHeader();
			this.cHTotalModifyTime = new global::System.Windows.Forms.ColumnHeader();
			this.labelTotal = new global::System.Windows.Forms.Label();
			this.buttonExport = new global::System.Windows.Forms.Button();
			this.groupBoxAdmin = new global::System.Windows.Forms.GroupBox();
			this.radioButtonAdmin = new global::System.Windows.Forms.RadioButton();
			this.radioButtonCurrent = new global::System.Windows.Forms.RadioButton();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.groupBoxAdmin.SuspendLayout();
			base.SuspendLayout();
			this.listViewLogs.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.cHName,
				this.cHUser,
				this.cHDate,
				this.cHST,
				this.cHET,
				this.cHSpan,
				this.cHModifySpan
			});
			this.listViewLogs.HideSelection = false;
			this.listViewLogs.Location = new global::System.Drawing.Point(12, 28);
			this.listViewLogs.Name = "listViewLogs";
			this.listViewLogs.Size = new global::System.Drawing.Size(830, 330);
			this.listViewLogs.TabIndex = 0;
			this.listViewLogs.UseCompatibleStateImageBehavior = false;
			this.listViewLogs.View = global::System.Windows.Forms.View.Details;
			this.cHName.Text = "Name";
			this.cHName.Width = 300;
			this.cHUser.Text = "User";
			this.cHUser.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.cHUser.Width = 110;
			this.cHDate.Text = "Date";
			this.cHDate.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.cHDate.Width = 80;
			this.cHST.Text = "Start Time";
			this.cHST.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.cHST.Width = 80;
			this.cHET.Text = "End Time";
			this.cHET.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.cHET.Width = 80;
			this.cHSpan.Text = "Time";
			this.cHSpan.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.cHSpan.Width = 80;
			this.cHModifySpan.Text = "Modify Time";
			this.cHModifySpan.Width = 80;
			this.labelLogs.AutoSize = true;
			this.labelLogs.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelLogs.Location = new global::System.Drawing.Point(385, 9);
			this.labelLogs.Name = "labelLogs";
			this.labelLogs.Size = new global::System.Drawing.Size(43, 16);
			this.labelLogs.TabIndex = 2;
			this.labelLogs.Text = "Logs";
			this.labelLogs.Click += new global::System.EventHandler(this.labelLogs_Click);
			this.listViewTotal.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.cHTotalName,
				this.cHTotalSpan,
				this.cHTotalModifyTime
			});
			this.listViewTotal.HideSelection = false;
			this.listViewTotal.Location = new global::System.Drawing.Point(12, 387);
			this.listViewTotal.Name = "listViewTotal";
			this.listViewTotal.Size = new global::System.Drawing.Size(830, 330);
			this.listViewTotal.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.listViewTotal.TabIndex = 3;
			this.listViewTotal.UseCompatibleStateImageBehavior = false;
			this.listViewTotal.View = global::System.Windows.Forms.View.Details;
			this.cHTotalName.Text = "Name";
			this.cHTotalName.Width = 400;
			this.cHTotalSpan.Text = "Time";
			this.cHTotalSpan.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.cHTotalSpan.Width = 120;
			this.cHTotalModifyTime.Text = "Modify Time";
			this.cHTotalModifyTime.Width = 120;
			this.labelTotal.AutoSize = true;
			this.labelTotal.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelTotal.Location = new global::System.Drawing.Point(356, 368);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new global::System.Drawing.Size(61, 16);
			this.labelTotal.TabIndex = 4;
			this.labelTotal.Text = "TOTAL";
			this.labelTotal.Click += new global::System.EventHandler(this.labelTotal_Click);
			this.buttonExport.Location = new global::System.Drawing.Point(743, 723);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new global::System.Drawing.Size(99, 34);
			this.buttonExport.TabIndex = 5;
			this.buttonExport.Text = "Export to Excel";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new global::System.EventHandler(this.buttonExport_Click);
			this.groupBoxAdmin.Controls.Add(this.radioButtonAdmin);
			this.groupBoxAdmin.Controls.Add(this.radioButtonCurrent);
			this.groupBoxAdmin.Location = new global::System.Drawing.Point(12, 723);
			this.groupBoxAdmin.Name = "groupBoxAdmin";
			this.groupBoxAdmin.Size = new global::System.Drawing.Size(221, 36);
			this.groupBoxAdmin.TabIndex = 6;
			this.groupBoxAdmin.TabStop = false;
			this.groupBoxAdmin.Text = "Admin";
			this.radioButtonAdmin.AutoSize = true;
			this.radioButtonAdmin.Location = new global::System.Drawing.Point(121, 18);
			this.radioButtonAdmin.Name = "radioButtonAdmin";
			this.radioButtonAdmin.Size = new global::System.Drawing.Size(71, 16);
			this.radioButtonAdmin.TabIndex = 0;
			this.radioButtonAdmin.TabStop = true;
			this.radioButtonAdmin.Text = "All Users";
			this.radioButtonAdmin.UseVisualStyleBackColor = true;
			this.radioButtonCurrent.AutoSize = true;
			this.radioButtonCurrent.Location = new global::System.Drawing.Point(6, 18);
			this.radioButtonCurrent.Name = "radioButtonCurrent";
			this.radioButtonCurrent.Size = new global::System.Drawing.Size(89, 16);
			this.radioButtonCurrent.TabIndex = 0;
			this.radioButtonCurrent.TabStop = true;
			this.radioButtonCurrent.Text = "Current User";
			this.radioButtonCurrent.UseVisualStyleBackColor = true;
			this.radioButtonCurrent.CheckedChanged += new global::System.EventHandler(this.radioButtonCurrent_CheckedChanged);
			this.buttonCancel.Location = new global::System.Drawing.Point(633, 723);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 34);
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(858, 771);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.groupBoxAdmin);
			base.Controls.Add(this.buttonExport);
			base.Controls.Add(this.labelTotal);
			base.Controls.Add(this.listViewTotal);
			base.Controls.Add(this.labelLogs);
			base.Controls.Add(this.listViewLogs);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "LogProjectForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Log Report";
			base.Load += new global::System.EventHandler(this.LogReportForm_Load);
			this.groupBoxAdmin.ResumeLayout(false);
			this.groupBoxAdmin.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001F4 RID: 500
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.ListView listViewLogs;

		// Token: 0x040001F6 RID: 502
		private global::System.Windows.Forms.ColumnHeader cHName;

		// Token: 0x040001F7 RID: 503
		private global::System.Windows.Forms.ColumnHeader cHDate;

		// Token: 0x040001F8 RID: 504
		private global::System.Windows.Forms.ColumnHeader cHST;

		// Token: 0x040001F9 RID: 505
		private global::System.Windows.Forms.ColumnHeader cHET;

		// Token: 0x040001FA RID: 506
		private global::System.Windows.Forms.ColumnHeader cHSpan;

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.ColumnHeader cHUser;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.Label labelLogs;

		// Token: 0x040001FD RID: 509
		private global::System.Windows.Forms.ListView listViewTotal;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.ColumnHeader cHTotalName;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.ColumnHeader cHTotalSpan;

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.Label labelTotal;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.ColumnHeader cHModifySpan;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.ColumnHeader cHTotalModifyTime;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.Button buttonExport;

		// Token: 0x04000204 RID: 516
		private global::System.Windows.Forms.GroupBox groupBoxAdmin;

		// Token: 0x04000205 RID: 517
		private global::System.Windows.Forms.RadioButton radioButtonAdmin;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.RadioButton radioButtonCurrent;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.Button buttonCancel;
	}
}
