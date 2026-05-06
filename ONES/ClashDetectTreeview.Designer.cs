namespace ONES
{
	// Token: 0x02000028 RID: 40
	public partial class ClashDetectTreeview : global::System.Windows.Forms.Form
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00014A48 File Offset: 0x00012C48
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00014A68 File Offset: 0x00012C68
		private void InitializeComponent()
		{
			this.labelClash = new global::System.Windows.Forms.Label();
			this.treeViewClash = new global::System.Windows.Forms.TreeView();
			this.checkBoxDirectShape = new global::System.Windows.Forms.CheckBox();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			this.buttonClear = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.labelClash.AutoSize = true;
			this.labelClash.Location = new global::System.Drawing.Point(112, 13);
			this.labelClash.Name = "labelClash";
			this.labelClash.Size = new global::System.Drawing.Size(97, 12);
			this.labelClash.TabIndex = 15;
			this.labelClash.Text = "Clashed Elements";
			this.treeViewClash.CheckBoxes = true;
			this.treeViewClash.Location = new global::System.Drawing.Point(12, 28);
			this.treeViewClash.Name = "treeViewClash";
			this.treeViewClash.Size = new global::System.Drawing.Size(275, 593);
			this.treeViewClash.TabIndex = 14;
			this.checkBoxDirectShape.AutoSize = true;
			this.checkBoxDirectShape.Location = new global::System.Drawing.Point(307, 42);
			this.checkBoxDirectShape.Name = "checkBoxDirectShape";
			this.checkBoxDirectShape.Size = new global::System.Drawing.Size(133, 16);
			this.checkBoxDirectShape.TabIndex = 16;
			this.checkBoxDirectShape.Text = "Solid of Clashed Part";
			this.checkBoxDirectShape.UseVisualStyleBackColor = true;
			this.buttonSelect.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonSelect.Location = new global::System.Drawing.Point(335, 64);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new global::System.Drawing.Size(75, 30);
			this.buttonSelect.TabIndex = 17;
			this.buttonSelect.Text = "Check";
			this.buttonSelect.UseVisualStyleBackColor = false;
			this.buttonSelect.Click += new global::System.EventHandler(this.buttonSelect_Click);
			this.buttonClear.Location = new global::System.Drawing.Point(324, 591);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new global::System.Drawing.Size(75, 30);
			this.buttonClear.TabIndex = 18;
			this.buttonClear.Text = "Clear";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new global::System.EventHandler(this.buttonClear_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(487, 633);
			base.Controls.Add(this.buttonClear);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.checkBoxDirectShape);
			base.Controls.Add(this.labelClash);
			base.Controls.Add(this.treeViewClash);
			base.Name = "ClashDetectTreeview";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clash Detect";
			base.Load += new global::System.EventHandler(this.ClashDetectTreeview_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000D9 RID: 217
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.Label labelClash;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.TreeView treeViewClash;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.CheckBox checkBoxDirectShape;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Button buttonSelect;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Button buttonClear;
	}
}
