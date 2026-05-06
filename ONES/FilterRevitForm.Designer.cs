namespace ONES
{
	// Token: 0x0200006C RID: 108
	public partial class FilterRevitForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000261 RID: 609 RVA: 0x00026EB4 File Offset: 0x000250B4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00026ED4 File Offset: 0x000250D4
		private void InitializeComponent()
		{
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1
			});
			this.listView1.HideSelection = false;
			this.listView1.Location = new global::System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(379, 501);
			this.listView1.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 350;
			this.buttonClose.Location = new global::System.Drawing.Point(319, 519);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(73, 30);
			this.buttonClose.TabIndex = 15;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonSelect.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonSelect.Location = new global::System.Drawing.Point(12, 519);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new global::System.Drawing.Size(75, 30);
			this.buttonSelect.TabIndex = 16;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = false;
			this.buttonSelect.Click += new global::System.EventHandler(this.buttonSelect_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(404, 561);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.listView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "FilterRevitForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Filters";
			base.Load += new global::System.EventHandler(this.SelectFilterForm_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040001AD RID: 429
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.Button buttonClose;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.Button buttonSelect;
	}
}
