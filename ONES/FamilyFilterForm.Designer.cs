namespace ONES
{
	// Token: 0x02000035 RID: 53
	public partial class FamilyFilterForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000164 RID: 356 RVA: 0x00019FF2 File Offset: 0x000181F2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0001A014 File Offset: 0x00018214
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ONES.FamilyFilterForm));
			this.treeViewElements = new global::System.Windows.Forms.TreeView();
			this.labelCount = new global::System.Windows.Forms.Label();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			this.buttonCheck = new global::System.Windows.Forms.Button();
			this.buttonUncheck = new global::System.Windows.Forms.Button();
			this.buttonExpand = new global::System.Windows.Forms.Button();
			this.buttonCollapse = new global::System.Windows.Forms.Button();
			this.labelDevelopment = new global::System.Windows.Forms.Label();
			this.buttonDeselect = new global::System.Windows.Forms.Button();
			this.groupBoxListingOption = new global::System.Windows.Forms.GroupBox();
			this.rButtonListChanged = new global::System.Windows.Forms.RadioButton();
			this.rButtonListType = new global::System.Windows.Forms.RadioButton();
			this.rButtonListCreated = new global::System.Windows.Forms.RadioButton();
			this.groupBoxSearch = new global::System.Windows.Forms.GroupBox();
			this.comboBoxSearch = new global::System.Windows.Forms.ComboBox();
			this.buttonReset = new global::System.Windows.Forms.Button();
			this.buttonSearch = new global::System.Windows.Forms.Button();
			this.textBoxSearch = new global::System.Windows.Forms.TextBox();
			this.groupBoxListingOption.SuspendLayout();
			this.groupBoxSearch.SuspendLayout();
			base.SuspendLayout();
			this.treeViewElements.CheckBoxes = true;
			this.treeViewElements.Location = new global::System.Drawing.Point(12, 12);
			this.treeViewElements.Name = "treeViewElements";
			this.treeViewElements.Size = new global::System.Drawing.Size(400, 635);
			this.treeViewElements.TabIndex = 0;
			this.treeViewElements.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
			this.treeViewElements.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.labelCount.AutoSize = true;
			this.labelCount.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCount.Location = new global::System.Drawing.Point(432, 569);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new global::System.Drawing.Size(112, 16);
			this.labelCount.TabIndex = 1;
			this.labelCount.Text = "Total Selection:";
			this.buttonSelect.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonSelect.Location = new global::System.Drawing.Point(514, 599);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new global::System.Drawing.Size(75, 30);
			this.buttonSelect.TabIndex = 3;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = false;
			this.buttonSelect.Click += new global::System.EventHandler(this.buttonSelect_Click);
			this.buttonCheck.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonCheck.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonCheck.FlatAppearance.BorderSize = 0;
			this.buttonCheck.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonCheck.Image = global::ONES.Properties.Resources.checkall16;
			this.buttonCheck.Location = new global::System.Drawing.Point(424, 11);
			this.buttonCheck.Name = "buttonCheck";
			this.buttonCheck.Size = new global::System.Drawing.Size(23, 23);
			this.buttonCheck.TabIndex = 0;
			this.buttonCheck.UseVisualStyleBackColor = false;
			this.buttonCheck.Click += new global::System.EventHandler(this.buttonCheck_Click);
			this.buttonUncheck.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonUncheck.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonUncheck.FlatAppearance.BorderSize = 0;
			this.buttonUncheck.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonUncheck.Image = global::ONES.Properties.Resources.uncheckall16;
			this.buttonUncheck.Location = new global::System.Drawing.Point(453, 11);
			this.buttonUncheck.Name = "buttonUncheck";
			this.buttonUncheck.Size = new global::System.Drawing.Size(23, 23);
			this.buttonUncheck.TabIndex = 0;
			this.buttonUncheck.UseVisualStyleBackColor = false;
			this.buttonUncheck.Click += new global::System.EventHandler(this.buttonUncheck_Click);
			this.buttonExpand.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonExpand.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonExpand.FlatAppearance.BorderSize = 0;
			this.buttonExpand.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonExpand.Image = global::ONES.Properties.Resources.expand16;
			this.buttonExpand.Location = new global::System.Drawing.Point(487, 11);
			this.buttonExpand.Name = "buttonExpand";
			this.buttonExpand.Size = new global::System.Drawing.Size(23, 23);
			this.buttonExpand.TabIndex = 0;
			this.buttonExpand.UseVisualStyleBackColor = false;
			this.buttonExpand.Click += new global::System.EventHandler(this.buttonExpand_Click);
			this.buttonCollapse.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonCollapse.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonCollapse.FlatAppearance.BorderSize = 0;
			this.buttonCollapse.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonCollapse.Image = global::ONES.Properties.Resources.collapse16;
			this.buttonCollapse.Location = new global::System.Drawing.Point(514, 11);
			this.buttonCollapse.Name = "buttonCollapse";
			this.buttonCollapse.Size = new global::System.Drawing.Size(23, 23);
			this.buttonCollapse.TabIndex = 0;
			this.buttonCollapse.UseVisualStyleBackColor = false;
			this.buttonCollapse.Click += new global::System.EventHandler(this.buttonCollapse_Click);
			this.labelDevelopment.AutoSize = true;
			this.labelDevelopment.ForeColor = global::System.Drawing.Color.Red;
			this.labelDevelopment.Location = new global::System.Drawing.Point(428, 640);
			this.labelDevelopment.Name = "labelDevelopment";
			this.labelDevelopment.Size = new global::System.Drawing.Size(105, 12);
			this.labelDevelopment.TabIndex = 5;
			this.labelDevelopment.Text = "Under Development";
			this.labelDevelopment.Click += new global::System.EventHandler(this.labelDevelopment_Click);
			this.buttonDeselect.BackColor = global::System.Drawing.Color.IndianRed;
			this.buttonDeselect.Location = new global::System.Drawing.Point(430, 599);
			this.buttonDeselect.Name = "buttonDeselect";
			this.buttonDeselect.Size = new global::System.Drawing.Size(75, 30);
			this.buttonDeselect.TabIndex = 6;
			this.buttonDeselect.Text = "Deselect";
			this.buttonDeselect.UseVisualStyleBackColor = false;
			this.buttonDeselect.Click += new global::System.EventHandler(this.buttonDeselect_Click);
			this.groupBoxListingOption.Controls.Add(this.rButtonListChanged);
			this.groupBoxListingOption.Controls.Add(this.rButtonListType);
			this.groupBoxListingOption.Controls.Add(this.rButtonListCreated);
			this.groupBoxListingOption.Location = new global::System.Drawing.Point(418, 53);
			this.groupBoxListingOption.Name = "groupBoxListingOption";
			this.groupBoxListingOption.Size = new global::System.Drawing.Size(126, 90);
			this.groupBoxListingOption.TabIndex = 9;
			this.groupBoxListingOption.TabStop = false;
			this.groupBoxListingOption.Text = "Listing Option";
			this.rButtonListChanged.AutoSize = true;
			this.rButtonListChanged.Location = new global::System.Drawing.Point(12, 62);
			this.rButtonListChanged.Name = "rButtonListChanged";
			this.rButtonListChanged.Size = new global::System.Drawing.Size(109, 16);
			this.rButtonListChanged.TabIndex = 14;
			this.rButtonListChanged.TabStop = true;
			this.rButtonListChanged.Text = "Last Changed by";
			this.rButtonListChanged.UseVisualStyleBackColor = true;
			this.rButtonListChanged.CheckedChanged += new global::System.EventHandler(this.rButtonListChanged_CheckedChanged);
			this.rButtonListType.AutoSize = true;
			this.rButtonListType.Location = new global::System.Drawing.Point(12, 18);
			this.rButtonListType.Name = "rButtonListType";
			this.rButtonListType.Size = new global::System.Drawing.Size(48, 16);
			this.rButtonListType.TabIndex = 10;
			this.rButtonListType.TabStop = true;
			this.rButtonListType.Text = "Type";
			this.rButtonListType.UseVisualStyleBackColor = true;
			this.rButtonListType.CheckedChanged += new global::System.EventHandler(this.radioButtonFamilyType_CheckedChanged);
			this.rButtonListCreated.AutoSize = true;
			this.rButtonListCreated.Location = new global::System.Drawing.Point(12, 40);
			this.rButtonListCreated.Name = "rButtonListCreated";
			this.rButtonListCreated.Size = new global::System.Drawing.Size(79, 16);
			this.rButtonListCreated.TabIndex = 10;
			this.rButtonListCreated.TabStop = true;
			this.rButtonListCreated.Text = "Created by";
			this.rButtonListCreated.UseVisualStyleBackColor = true;
			this.rButtonListCreated.CheckedChanged += new global::System.EventHandler(this.radioButtonUser_CheckedChanged);
			this.groupBoxSearch.Controls.Add(this.comboBoxSearch);
			this.groupBoxSearch.Controls.Add(this.buttonReset);
			this.groupBoxSearch.Controls.Add(this.buttonSearch);
			this.groupBoxSearch.Controls.Add(this.textBoxSearch);
			this.groupBoxSearch.Location = new global::System.Drawing.Point(418, 158);
			this.groupBoxSearch.Name = "groupBoxSearch";
			this.groupBoxSearch.Size = new global::System.Drawing.Size(194, 114);
			this.groupBoxSearch.TabIndex = 10;
			this.groupBoxSearch.TabStop = false;
			this.groupBoxSearch.Text = "Search";
			this.comboBoxSearch.FormattingEnabled = true;
			this.comboBoxSearch.Location = new global::System.Drawing.Point(12, 43);
			this.comboBoxSearch.Name = "comboBoxSearch";
			this.comboBoxSearch.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxSearch.TabIndex = 2;
			this.buttonReset.Location = new global::System.Drawing.Point(96, 77);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new global::System.Drawing.Size(75, 23);
			this.buttonReset.TabIndex = 1;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new global::System.EventHandler(this.buttonReset_Click);
			this.buttonSearch.Location = new global::System.Drawing.Point(12, 77);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new global::System.Drawing.Size(75, 23);
			this.buttonSearch.TabIndex = 1;
			this.buttonSearch.Text = "Search";
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new global::System.EventHandler(this.buttonSearch_Click);
			this.textBoxSearch.Location = new global::System.Drawing.Point(12, 18);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new global::System.Drawing.Size(159, 19);
			this.textBoxSearch.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(624, 661);
			base.Controls.Add(this.groupBoxSearch);
			base.Controls.Add(this.groupBoxListingOption);
			base.Controls.Add(this.buttonDeselect);
			base.Controls.Add(this.labelDevelopment);
			base.Controls.Add(this.buttonCollapse);
			base.Controls.Add(this.buttonExpand);
			base.Controls.Add(this.buttonUncheck);
			base.Controls.Add(this.buttonCheck);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.labelCount);
			base.Controls.Add(this.treeViewElements);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "SelectFamilyForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Family Filter";
			base.Load += new global::System.EventHandler(this.FamilyFilterForm_Load);
			this.groupBoxListingOption.ResumeLayout(false);
			this.groupBoxListingOption.PerformLayout();
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400011C RID: 284
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.TreeView treeViewElements;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.Label labelCount;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.Button buttonSelect;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Button buttonCheck;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Button buttonUncheck;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Button buttonExpand;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Button buttonCollapse;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Label labelDevelopment;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Button buttonDeselect;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.GroupBox groupBoxListingOption;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.RadioButton rButtonListType;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.RadioButton rButtonListCreated;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.RadioButton rButtonListChanged;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.GroupBox groupBoxSearch;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.Button buttonReset;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.Button buttonSearch;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.TextBox textBoxSearch;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.ComboBox comboBoxSearch;
	}
}
