namespace ONES
{
	// Token: 0x02000029 RID: 41
	public partial class ParametersForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00014FCC File Offset: 0x000131CC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00014FEC File Offset: 0x000131EC
		private void InitializeComponent()
		{
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.Parameter = new global::System.Windows.Forms.ColumnHeader();
			this.buttonOk = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.Parameter
			});
			this.listView1.HideSelection = false;
			this.listView1.Location = new global::System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(308, 338);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.Parameter.Width = 201;
			this.buttonOk.Location = new global::System.Drawing.Point(396, 178);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new global::System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Controls.Add(this.buttonOk);
			base.Controls.Add(this.listView1);
			base.Name = "ParametersForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			base.Load += new global::System.EventHandler(this.ParametersForm_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040000E0 RID: 224
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.ColumnHeader Parameter;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.Button buttonOk;
	}
}
