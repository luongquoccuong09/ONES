namespace ONES
{
	// Token: 0x02000033 RID: 51
	public partial class ExportSchedules : global::System.Windows.Forms.Form
	{
		// Token: 0x06000111 RID: 273 RVA: 0x00016403 File Offset: 0x00014603
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00016424 File Offset: 0x00014624
		private void InitializeComponent()
		{
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.columnHeaderScheduleName = new global::System.Windows.Forms.ColumnHeader();
			this.labelSchedules = new global::System.Windows.Forms.Label();
			this.buttonCheck = new global::System.Windows.Forms.Button();
			this.buttonUncheck = new global::System.Windows.Forms.Button();
			this.buttonExport = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeaderScheduleName
			});
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new global::System.Drawing.Point(12, 24);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(322, 371);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.columnHeaderScheduleName.Text = "Schedule Name";
			this.columnHeaderScheduleName.Width = 300;
			this.labelSchedules.AutoSize = true;
			this.labelSchedules.Location = new global::System.Drawing.Point(148, 9);
			this.labelSchedules.Name = "labelSchedules";
			this.labelSchedules.Size = new global::System.Drawing.Size(57, 12);
			this.labelSchedules.TabIndex = 1;
			this.labelSchedules.Text = "Schedules";
			this.buttonCheck.Location = new global::System.Drawing.Point(352, 24);
			this.buttonCheck.Name = "buttonCheck";
			this.buttonCheck.Size = new global::System.Drawing.Size(85, 30);
			this.buttonCheck.TabIndex = 2;
			this.buttonCheck.Text = "Check All";
			this.buttonCheck.UseVisualStyleBackColor = true;
			this.buttonCheck.Click += new global::System.EventHandler(this.buttonCheck_Click);
			this.buttonUncheck.Location = new global::System.Drawing.Point(352, 60);
			this.buttonUncheck.Name = "buttonUncheck";
			this.buttonUncheck.Size = new global::System.Drawing.Size(85, 30);
			this.buttonUncheck.TabIndex = 2;
			this.buttonUncheck.Text = "Uncheck All";
			this.buttonUncheck.UseVisualStyleBackColor = true;
			this.buttonUncheck.Click += new global::System.EventHandler(this.buttonUncheck_Click);
			this.buttonExport.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonExport.Location = new global::System.Drawing.Point(352, 365);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new global::System.Drawing.Size(85, 30);
			this.buttonExport.TabIndex = 2;
			this.buttonExport.Text = "Export";
			this.buttonExport.UseVisualStyleBackColor = false;
			this.buttonExport.Click += new global::System.EventHandler(this.buttonExport_Click);
			this.buttonCancel.Location = new global::System.Drawing.Point(357, 336);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(469, 415);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonExport);
			base.Controls.Add(this.buttonUncheck);
			base.Controls.Add(this.buttonCheck);
			base.Controls.Add(this.labelSchedules);
			base.Controls.Add(this.listView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "ExportSchedules";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Export Schedules";
			base.Load += new global::System.EventHandler(this.ExportSchedules_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000ED RID: 237
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Label labelSchedules;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.Button buttonCheck;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Button buttonUncheck;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.Button buttonExport;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.ColumnHeader columnHeaderScheduleName;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Button buttonCancel;
	}
}
