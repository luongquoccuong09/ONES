namespace ONES
{
	// Token: 0x02000023 RID: 35
	public partial class ClashDetectListviewForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x00012A28 File Offset: 0x00010C28
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00012A48 File Offset: 0x00010C48
		private void InitializeComponent()
		{
			this.listViewClash = new global::System.Windows.Forms.ListView();
			this.cH1 = new global::System.Windows.Forms.ColumnHeader();
			this.cH2 = new global::System.Windows.Forms.ColumnHeader();
			this.cH3 = new global::System.Windows.Forms.ColumnHeader();
			this.cH4 = new global::System.Windows.Forms.ColumnHeader();
			this.buttonExport = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.listViewClash.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.cH1,
				this.cH2,
				this.cH3,
				this.cH4
			});
			this.listViewClash.Font = new global::System.Drawing.Font("MS UI Gothic", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.listViewClash.HideSelection = false;
			this.listViewClash.Location = new global::System.Drawing.Point(12, 12);
			this.listViewClash.Name = "listViewClash";
			this.listViewClash.Size = new global::System.Drawing.Size(760, 492);
			this.listViewClash.TabIndex = 0;
			this.listViewClash.UseCompatibleStateImageBehavior = false;
			this.listViewClash.View = global::System.Windows.Forms.View.Details;
			this.cH1.Text = "STATE";
			this.cH1.Width = 200;
			this.cH2.Text = "CATEGORY";
			this.cH2.Width = 200;
			this.cH3.Text = "NAME";
			this.cH3.Width = 200;
			this.cH4.Text = "ID";
			this.cH4.Width = 140;
			this.buttonExport.Font = new global::System.Drawing.Font("MS UI Gothic", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.buttonExport.Location = new global::System.Drawing.Point(337, 510);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new global::System.Drawing.Size(115, 39);
			this.buttonExport.TabIndex = 1;
			this.buttonExport.Text = "Export to Excel";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new global::System.EventHandler(this.buttonExport_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(784, 561);
			base.Controls.Add(this.buttonExport);
			base.Controls.Add(this.listViewClash);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "ClashDetectionForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clash Detection";
			base.Load += new global::System.EventHandler(this.ClashDetectionForm_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040000B1 RID: 177
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.ListView listViewClash;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.Button buttonExport;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.ColumnHeader cH1;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.ColumnHeader cH2;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.ColumnHeader cH3;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.ColumnHeader cH4;
	}
}
