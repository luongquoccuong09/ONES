namespace ONES
{
	// Token: 0x02000018 RID: 24
	public partial class WarningManagerForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000079 RID: 121 RVA: 0x0000C3CC File Offset: 0x0000A5CC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000C3EC File Offset: 0x0000A5EC
		private void InitializeComponent()
		{
			this.treeViewWarnings = new global::System.Windows.Forms.TreeView();
			this.labelCount = new global::System.Windows.Forms.Label();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.treeViewWarnings.CheckBoxes = true;
			this.treeViewWarnings.Location = new global::System.Drawing.Point(12, 12);
			this.treeViewWarnings.Name = "treeViewWarnings";
			this.treeViewWarnings.Size = new global::System.Drawing.Size(651, 542);
			this.treeViewWarnings.TabIndex = 0;
			this.treeViewWarnings.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.treeViewWarnings_AfterCheck);
			this.treeViewWarnings.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.treeViewWarnings_AfterSelect);
			this.labelCount.AutoSize = true;
			this.labelCount.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCount.Location = new global::System.Drawing.Point(750, 494);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new global::System.Drawing.Size(112, 16);
			this.labelCount.TabIndex = 2;
			this.labelCount.Text = "Total Selection:";
			this.buttonSelect.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonSelect.Location = new global::System.Drawing.Point(831, 524);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new global::System.Drawing.Size(75, 30);
			this.buttonSelect.TabIndex = 4;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = false;
			this.buttonSelect.Click += new global::System.EventHandler(this.buttonSelect_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(918, 566);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.labelCount);
			base.Controls.Add(this.treeViewWarnings);
			base.Name = "WarningManagerForm";
			this.Text = "WarningManagerForm";
			base.Load += new global::System.EventHandler(this.WarningManagerForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000062 RID: 98
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.TreeView treeViewWarnings;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.Label labelCount;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.Button buttonSelect;
	}
}
