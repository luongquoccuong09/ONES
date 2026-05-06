namespace ONES
{
	// Token: 0x02000034 RID: 52
	public partial class SelectFilterForm2 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00017D9E File Offset: 0x00015F9E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00017DC0 File Offset: 0x00015FC0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ONES.SelectFilterForm2));
			this.treeViewElements1 = new global::System.Windows.Forms.TreeView();
			this.labelCount1 = new global::System.Windows.Forms.Label();
			this.groupBoxSelection = new global::System.Windows.Forms.GroupBox();
			this.radioButtonAllProject = new global::System.Windows.Forms.RadioButton();
			this.radioButtonCurrentSel = new global::System.Windows.Forms.RadioButton();
			this.radioButtonCurrentView = new global::System.Windows.Forms.RadioButton();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			this.buttonCheck = new global::System.Windows.Forms.Button();
			this.buttonUncheck = new global::System.Windows.Forms.Button();
			this.buttonExpand = new global::System.Windows.Forms.Button();
			this.buttonCollapse = new global::System.Windows.Forms.Button();
			this.buttonDeselect = new global::System.Windows.Forms.Button();
			this.groupBoxListingOption = new global::System.Windows.Forms.GroupBox();
			this.radioButtonListLevel = new global::System.Windows.Forms.RadioButton();
			this.radioButtonListType = new global::System.Windows.Forms.RadioButton();
			this.radioButtonListUser = new global::System.Windows.Forms.RadioButton();
			this.radioButtonListWorkset = new global::System.Windows.Forms.RadioButton();
			this.treeViewElements2 = new global::System.Windows.Forms.TreeView();
			this.labelCount2 = new global::System.Windows.Forms.Label();
			this.groupBoxElements1 = new global::System.Windows.Forms.GroupBox();
			this.groupBoxElements2 = new global::System.Windows.Forms.GroupBox();
			this.buttonCheck2 = new global::System.Windows.Forms.Button();
			this.buttonUncheck2 = new global::System.Windows.Forms.Button();
			this.buttonExpand2 = new global::System.Windows.Forms.Button();
			this.buttonCollapse2 = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.groupBoxSelection.SuspendLayout();
			this.groupBoxListingOption.SuspendLayout();
			this.groupBoxElements1.SuspendLayout();
			this.groupBoxElements2.SuspendLayout();
			base.SuspendLayout();
			this.treeViewElements1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.treeViewElements1.CheckBoxes = true;
			this.treeViewElements1.Location = new global::System.Drawing.Point(6, 18);
			this.treeViewElements1.Name = "treeViewElements1";
			this.treeViewElements1.Size = new global::System.Drawing.Size(275, 579);
			this.treeViewElements1.TabIndex = 0;
			this.treeViewElements1.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
			this.treeViewElements1.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.labelCount1.AutoSize = true;
			this.labelCount1.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCount1.Location = new global::System.Drawing.Point(619, 528);
			this.labelCount1.Name = "labelCount1";
			this.labelCount1.Size = new global::System.Drawing.Size(125, 16);
			this.labelCount1.TabIndex = 1;
			this.labelCount1.Text = "Total Selection 1:";
			this.groupBoxSelection.Controls.Add(this.radioButtonAllProject);
			this.groupBoxSelection.Controls.Add(this.radioButtonCurrentSel);
			this.groupBoxSelection.Controls.Add(this.radioButtonCurrentView);
			this.groupBoxSelection.Location = new global::System.Drawing.Point(607, 12);
			this.groupBoxSelection.Name = "groupBoxSelection";
			this.groupBoxSelection.Size = new global::System.Drawing.Size(150, 90);
			this.groupBoxSelection.TabIndex = 2;
			this.groupBoxSelection.TabStop = false;
			this.groupBoxSelection.Text = "Selection Option";
			this.groupBoxSelection.Enter += new global::System.EventHandler(this.groupBoxSelection_Enter);
			this.radioButtonAllProject.AutoSize = true;
			this.radioButtonAllProject.Location = new global::System.Drawing.Point(6, 62);
			this.radioButtonAllProject.Name = "radioButtonAllProject";
			this.radioButtonAllProject.Size = new global::System.Drawing.Size(77, 16);
			this.radioButtonAllProject.TabIndex = 3;
			this.radioButtonAllProject.TabStop = true;
			this.radioButtonAllProject.Text = "All Project";
			this.radioButtonAllProject.UseVisualStyleBackColor = true;
			this.radioButtonAllProject.CheckedChanged += new global::System.EventHandler(this.radioButtonAllProject_CheckedChanged);
			this.radioButtonCurrentSel.AutoSize = true;
			this.radioButtonCurrentSel.Location = new global::System.Drawing.Point(7, 18);
			this.radioButtonCurrentSel.Name = "radioButtonCurrentSel";
			this.radioButtonCurrentSel.Size = new global::System.Drawing.Size(112, 16);
			this.radioButtonCurrentSel.TabIndex = 3;
			this.radioButtonCurrentSel.TabStop = true;
			this.radioButtonCurrentSel.Text = "Current Selection";
			this.radioButtonCurrentSel.UseVisualStyleBackColor = true;
			this.radioButtonCurrentSel.CheckedChanged += new global::System.EventHandler(this.radioButtonCurrentSel_CheckedChanged);
			this.radioButtonCurrentView.AutoSize = true;
			this.radioButtonCurrentView.Location = new global::System.Drawing.Point(6, 40);
			this.radioButtonCurrentView.Name = "radioButtonCurrentView";
			this.radioButtonCurrentView.Size = new global::System.Drawing.Size(90, 16);
			this.radioButtonCurrentView.TabIndex = 3;
			this.radioButtonCurrentView.TabStop = true;
			this.radioButtonCurrentView.Text = "Current View";
			this.radioButtonCurrentView.UseVisualStyleBackColor = true;
			this.radioButtonCurrentView.CheckedChanged += new global::System.EventHandler(this.radioButtonCurrentView_CheckedChanged);
			this.buttonSelect.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonSelect.Location = new global::System.Drawing.Point(703, 586);
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
			this.buttonCheck.Location = new global::System.Drawing.Point(84, 606);
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
			this.buttonUncheck.Location = new global::System.Drawing.Point(113, 606);
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
			this.buttonExpand.Location = new global::System.Drawing.Point(147, 606);
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
			this.buttonCollapse.Location = new global::System.Drawing.Point(174, 606);
			this.buttonCollapse.Name = "buttonCollapse";
			this.buttonCollapse.Size = new global::System.Drawing.Size(23, 23);
			this.buttonCollapse.TabIndex = 0;
			this.buttonCollapse.UseVisualStyleBackColor = false;
			this.buttonCollapse.Click += new global::System.EventHandler(this.buttonCollapse_Click);
			this.buttonDeselect.BackColor = global::System.Drawing.Color.IndianRed;
			this.buttonDeselect.Location = new global::System.Drawing.Point(619, 586);
			this.buttonDeselect.Name = "buttonDeselect";
			this.buttonDeselect.Size = new global::System.Drawing.Size(75, 30);
			this.buttonDeselect.TabIndex = 6;
			this.buttonDeselect.Text = "Deselect";
			this.buttonDeselect.UseVisualStyleBackColor = false;
			this.buttonDeselect.Click += new global::System.EventHandler(this.buttonDeselect_Click);
			this.groupBoxListingOption.Controls.Add(this.radioButtonListLevel);
			this.groupBoxListingOption.Controls.Add(this.radioButtonListType);
			this.groupBoxListingOption.Controls.Add(this.radioButtonListUser);
			this.groupBoxListingOption.Controls.Add(this.radioButtonListWorkset);
			this.groupBoxListingOption.Location = new global::System.Drawing.Point(607, 118);
			this.groupBoxListingOption.Name = "groupBoxListingOption";
			this.groupBoxListingOption.Size = new global::System.Drawing.Size(150, 107);
			this.groupBoxListingOption.TabIndex = 9;
			this.groupBoxListingOption.TabStop = false;
			this.groupBoxListingOption.Text = "Listing Option";
			this.radioButtonListLevel.AutoSize = true;
			this.radioButtonListLevel.Location = new global::System.Drawing.Point(12, 84);
			this.radioButtonListLevel.Name = "radioButtonListLevel";
			this.radioButtonListLevel.Size = new global::System.Drawing.Size(50, 16);
			this.radioButtonListLevel.TabIndex = 11;
			this.radioButtonListLevel.TabStop = true;
			this.radioButtonListLevel.Text = "Level";
			this.radioButtonListLevel.UseVisualStyleBackColor = true;
			this.radioButtonListLevel.CheckedChanged += new global::System.EventHandler(this.radioButtonListLevel_CheckedChanged);
			this.radioButtonListType.AutoSize = true;
			this.radioButtonListType.Location = new global::System.Drawing.Point(12, 18);
			this.radioButtonListType.Name = "radioButtonListType";
			this.radioButtonListType.Size = new global::System.Drawing.Size(48, 16);
			this.radioButtonListType.TabIndex = 10;
			this.radioButtonListType.TabStop = true;
			this.radioButtonListType.Text = "Type";
			this.radioButtonListType.UseVisualStyleBackColor = true;
			this.radioButtonListType.CheckedChanged += new global::System.EventHandler(this.radioButtonFamilyType_CheckedChanged);
			this.radioButtonListUser.AutoSize = true;
			this.radioButtonListUser.Location = new global::System.Drawing.Point(12, 62);
			this.radioButtonListUser.Name = "radioButtonListUser";
			this.radioButtonListUser.Size = new global::System.Drawing.Size(47, 16);
			this.radioButtonListUser.TabIndex = 10;
			this.radioButtonListUser.TabStop = true;
			this.radioButtonListUser.Text = "User";
			this.radioButtonListUser.UseVisualStyleBackColor = true;
			this.radioButtonListUser.CheckedChanged += new global::System.EventHandler(this.radioButtonUser_CheckedChanged);
			this.radioButtonListWorkset.AutoSize = true;
			this.radioButtonListWorkset.Location = new global::System.Drawing.Point(12, 40);
			this.radioButtonListWorkset.Name = "radioButtonListWorkset";
			this.radioButtonListWorkset.Size = new global::System.Drawing.Size(64, 16);
			this.radioButtonListWorkset.TabIndex = 10;
			this.radioButtonListWorkset.TabStop = true;
			this.radioButtonListWorkset.Text = "Workset";
			this.radioButtonListWorkset.UseVisualStyleBackColor = true;
			this.radioButtonListWorkset.CheckedChanged += new global::System.EventHandler(this.radioButtonWorkset_CheckedChanged);
			this.treeViewElements2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.treeViewElements2.CheckBoxes = true;
			this.treeViewElements2.Location = new global::System.Drawing.Point(6, 18);
			this.treeViewElements2.Name = "treeViewElements2";
			this.treeViewElements2.Size = new global::System.Drawing.Size(275, 579);
			this.treeViewElements2.TabIndex = 10;
			this.treeViewElements2.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.treeViewElements2_AfterCheck);
			this.labelCount2.AutoSize = true;
			this.labelCount2.Font = new global::System.Drawing.Font("MS UI Gothic", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCount2.Location = new global::System.Drawing.Point(619, 557);
			this.labelCount2.Name = "labelCount2";
			this.labelCount2.Size = new global::System.Drawing.Size(125, 16);
			this.labelCount2.TabIndex = 1;
			this.labelCount2.Text = "Total Selection 2:";
			this.groupBoxElements1.Controls.Add(this.treeViewElements1);
			this.groupBoxElements1.Controls.Add(this.buttonCheck);
			this.groupBoxElements1.Controls.Add(this.buttonUncheck);
			this.groupBoxElements1.Controls.Add(this.buttonExpand);
			this.groupBoxElements1.Controls.Add(this.buttonCollapse);
			this.groupBoxElements1.Location = new global::System.Drawing.Point(12, 12);
			this.groupBoxElements1.Name = "groupBoxElements1";
			this.groupBoxElements1.Size = new global::System.Drawing.Size(290, 637);
			this.groupBoxElements1.TabIndex = 15;
			this.groupBoxElements1.TabStop = false;
			this.groupBoxElements1.Text = "Elements: 1";
			this.groupBoxElements2.Controls.Add(this.buttonCheck2);
			this.groupBoxElements2.Controls.Add(this.treeViewElements2);
			this.groupBoxElements2.Controls.Add(this.buttonUncheck2);
			this.groupBoxElements2.Controls.Add(this.buttonExpand2);
			this.groupBoxElements2.Controls.Add(this.buttonCollapse2);
			this.groupBoxElements2.Location = new global::System.Drawing.Point(311, 12);
			this.groupBoxElements2.Name = "groupBoxElements2";
			this.groupBoxElements2.Size = new global::System.Drawing.Size(290, 637);
			this.groupBoxElements2.TabIndex = 16;
			this.groupBoxElements2.TabStop = false;
			this.groupBoxElements2.Text = "Elements: 2";
			this.buttonCheck2.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonCheck2.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonCheck2.FlatAppearance.BorderSize = 0;
			this.buttonCheck2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonCheck2.Image = global::ONES.Properties.Resources.checkall16;
			this.buttonCheck2.Location = new global::System.Drawing.Point(79, 606);
			this.buttonCheck2.Name = "buttonCheck2";
			this.buttonCheck2.Size = new global::System.Drawing.Size(23, 23);
			this.buttonCheck2.TabIndex = 17;
			this.buttonCheck2.UseVisualStyleBackColor = false;
			this.buttonCheck2.Click += new global::System.EventHandler(this.buttonCheck2_Click);
			this.buttonUncheck2.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonUncheck2.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonUncheck2.FlatAppearance.BorderSize = 0;
			this.buttonUncheck2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonUncheck2.Image = global::ONES.Properties.Resources.uncheckall16;
			this.buttonUncheck2.Location = new global::System.Drawing.Point(108, 606);
			this.buttonUncheck2.Name = "buttonUncheck2";
			this.buttonUncheck2.Size = new global::System.Drawing.Size(23, 23);
			this.buttonUncheck2.TabIndex = 18;
			this.buttonUncheck2.UseVisualStyleBackColor = false;
			this.buttonUncheck2.Click += new global::System.EventHandler(this.buttonUncheck2_Click);
			this.buttonExpand2.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonExpand2.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonExpand2.FlatAppearance.BorderSize = 0;
			this.buttonExpand2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonExpand2.Image = global::ONES.Properties.Resources.expand16;
			this.buttonExpand2.Location = new global::System.Drawing.Point(142, 606);
			this.buttonExpand2.Name = "buttonExpand2";
			this.buttonExpand2.Size = new global::System.Drawing.Size(23, 23);
			this.buttonExpand2.TabIndex = 19;
			this.buttonExpand2.UseVisualStyleBackColor = false;
			this.buttonExpand2.Click += new global::System.EventHandler(this.buttonExpand2_Click);
			this.buttonCollapse2.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonCollapse2.FlatAppearance.BorderColor = global::System.Drawing.Color.White;
			this.buttonCollapse2.FlatAppearance.BorderSize = 0;
			this.buttonCollapse2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonCollapse2.Image = global::ONES.Properties.Resources.collapse16;
			this.buttonCollapse2.Location = new global::System.Drawing.Point(169, 606);
			this.buttonCollapse2.Name = "buttonCollapse2";
			this.buttonCollapse2.Size = new global::System.Drawing.Size(23, 23);
			this.buttonCollapse2.TabIndex = 20;
			this.buttonCollapse2.UseVisualStyleBackColor = false;
			this.buttonCollapse2.Click += new global::System.EventHandler(this.buttonCollapse2_Click);
			this.buttonCancel.Location = new global::System.Drawing.Point(619, 622);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(70, 27);
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(794, 661);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.groupBoxElements2);
			base.Controls.Add(this.groupBoxElements1);
			base.Controls.Add(this.groupBoxListingOption);
			base.Controls.Add(this.buttonDeselect);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.groupBoxSelection);
			base.Controls.Add(this.labelCount2);
			base.Controls.Add(this.labelCount1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "SelectFilterForm2";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Filter";
			base.Load += new global::System.EventHandler(this.ClashDetectForm_Load);
			this.groupBoxSelection.ResumeLayout(false);
			this.groupBoxSelection.PerformLayout();
			this.groupBoxListingOption.ResumeLayout(false);
			this.groupBoxListingOption.PerformLayout();
			this.groupBoxElements1.ResumeLayout(false);
			this.groupBoxElements2.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000FB RID: 251
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.TreeView treeViewElements1;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.Label labelCount1;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.GroupBox groupBoxSelection;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.RadioButton radioButtonAllProject;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.RadioButton radioButtonCurrentSel;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.RadioButton radioButtonCurrentView;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.Button buttonSelect;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.Button buttonCheck;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.Button buttonUncheck;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.Button buttonExpand;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.Button buttonCollapse;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.Button buttonDeselect;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.GroupBox groupBoxListingOption;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.RadioButton radioButtonListType;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.RadioButton radioButtonListUser;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.RadioButton radioButtonListWorkset;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.RadioButton radioButtonListLevel;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.TreeView treeViewElements2;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.Label labelCount2;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.GroupBox groupBoxElements1;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.GroupBox groupBoxElements2;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Button buttonCheck2;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.Button buttonUncheck2;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Button buttonExpand2;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.Button buttonCollapse2;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.Button buttonCancel;
	}
}
