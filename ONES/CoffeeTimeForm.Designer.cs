namespace ONES
{
	// Token: 0x02000079 RID: 121
	public partial class CoffeeTimeForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060002B6 RID: 694 RVA: 0x00029BAC File Offset: 0x00027DAC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00029BCC File Offset: 0x00027DCC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ONES.CoffeeTimeForm));
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.buttonDrink = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.textBox1.BackColor = global::System.Drawing.Color.White;
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox1.Enabled = false;
			this.textBox1.Font = new global::System.Drawing.Font("MS UI Gothic", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.textBox1.Location = new global::System.Drawing.Point(12, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(276, 78);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.pictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(102, 96);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(100, 79);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.buttonDrink.Location = new global::System.Drawing.Point(115, 181);
			this.buttonDrink.Name = "buttonDrink";
			this.buttonDrink.Size = new global::System.Drawing.Size(73, 24);
			this.buttonDrink.TabIndex = 3;
			this.buttonDrink.Text = "Drink";
			this.buttonDrink.UseVisualStyleBackColor = true;
			this.buttonDrink.Click += new global::System.EventHandler(this.buttonDrink_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(300, 210);
			base.Controls.Add(this.buttonDrink);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.textBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "CoffeeTimeForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Coffee Time";
			base.Load += new global::System.EventHandler(this.CoffeeTimeForm_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001E6 RID: 486
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.Button buttonDrink;
	}
}
