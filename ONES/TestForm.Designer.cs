namespace ONES
{
	// Token: 0x02000074 RID: 116
	public partial class TestForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600027D RID: 637 RVA: 0x000287F0 File Offset: 0x000269F0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00028810 File Offset: 0x00026A10
		private void InitializeComponent()
		{
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.button1 = new global::System.Windows.Forms.Button();
			this.listBox1 = new global::System.Windows.Forms.ListBox();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.listView2 = new global::System.Windows.Forms.ListView();
			this.columnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			base.SuspendLayout();
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1
			});
			this.listView1.HideSelection = false;
			this.listView1.Location = new global::System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(394, 437);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.button1.Location = new global::System.Drawing.Point(22, 455);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(73, 30);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new global::System.Drawing.Point(842, 13);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new global::System.Drawing.Size(317, 436);
			this.listBox1.TabIndex = 2;
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 356;
			this.listView2.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader2
			});
			this.listView2.HideSelection = false;
			this.listView2.Location = new global::System.Drawing.Point(412, 12);
			this.listView2.Name = "listView2";
			this.listView2.Size = new global::System.Drawing.Size(424, 437);
			this.listView2.TabIndex = 3;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = global::System.Windows.Forms.View.Details;
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 389;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1171, 488);
			base.Controls.Add(this.listView2);
			base.Controls.Add(this.listBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.listView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "TestForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Test Form";
			base.Load += new global::System.EventHandler(this.TestForm_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040001CB RID: 459
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.ListBox listBox1;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.ListView listView2;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.ColumnHeader columnHeader2;
	}
}
