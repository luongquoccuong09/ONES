namespace ONES
{
	// Token: 0x0200003A RID: 58
	public partial class SelectFilterForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060001CC RID: 460 RVA: 0x0001FC0A File Offset: 0x0001DE0A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0001FC2C File Offset: 0x0001DE2C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ONES.SelectFilterForm));
			this.treeViewElements = new global::System.Windows.Forms.TreeView();
			this.labelCount = new global::System.Windows.Forms.Label();
			this.groupBoxSelection = new global::System.Windows.Forms.GroupBox();
			this.rButtonAllProject = new global::System.Windows.Forms.RadioButton();
			this.rButtonCurrentSel = new global::System.Windows.Forms.RadioButton();
			this.rButtonCurrentView = new global::System.Windows.Forms.RadioButton();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			this.buttonCheck = new global::System.Windows.Forms.Button();
			this.buttonUncheck = new global::System.Windows.Forms.Button();
			this.buttonExpand = new global::System.Windows.Forms.Button();
			this.buttonCollapse = new global::System.Windows.Forms.Button();
			this.groupBoxCondition = new global::System.Windows.Forms.GroupBox();
			this.checkBoxJoined = new global::System.Windows.Forms.CheckBox();
			this.checkBoxHostFamily = new global::System.Windows.Forms.CheckBox();
			this.checkBoxIsHost = new global::System.Windows.Forms.CheckBox();
			this.checkBoxNestedFamily = new global::System.Windows.Forms.CheckBox();
			this.checkBoxHostOf = new global::System.Windows.Forms.CheckBox();
			this.checkBoxWorkset = new global::System.Windows.Forms.CheckBox();
			this.checkBoxFamily = new global::System.Windows.Forms.CheckBox();
			this.checkBoxType = new global::System.Windows.Forms.CheckBox();
			this.checkBoxCategory = new global::System.Windows.Forms.CheckBox();
			this.buttonDeselect = new global::System.Windows.Forms.Button();
			this.groupBoxExtended = new global::System.Windows.Forms.GroupBox();
			this.buttonExtend = new global::System.Windows.Forms.Button();
			this.groupBoxSelMethod = new global::System.Windows.Forms.GroupBox();
			this.rBNewSel = new global::System.Windows.Forms.RadioButton();
			this.rBExtendSel = new global::System.Windows.Forms.RadioButton();
			this.groupBoxSelectionRange = new global::System.Windows.Forms.GroupBox();
			this.rBAllProjectE = new global::System.Windows.Forms.RadioButton();
			this.rBCurrentViewE = new global::System.Windows.Forms.RadioButton();
			this.groupBoxListingOption = new global::System.Windows.Forms.GroupBox();
			this.rBWarnings = new global::System.Windows.Forms.RadioButton();
			this.rBListChanged = new global::System.Windows.Forms.RadioButton();
			this.rBListOwner = new global::System.Windows.Forms.RadioButton();
			this.rBListInplace = new global::System.Windows.Forms.RadioButton();
			this.rBListLevel = new global::System.Windows.Forms.RadioButton();
			this.rBListType = new global::System.Windows.Forms.RadioButton();
			this.rBListCreated = new global::System.Windows.Forms.RadioButton();
			this.rBListWorkset = new global::System.Windows.Forms.RadioButton();
			this.groupBoxSearch = new global::System.Windows.Forms.GroupBox();
			this.rBFamilyName = new global::System.Windows.Forms.RadioButton();
			this.rBTypeName = new global::System.Windows.Forms.RadioButton();
			this.comboBoxSearch = new global::System.Windows.Forms.ComboBox();
			this.buttonReset = new global::System.Windows.Forms.Button();
			this.buttonSearch = new global::System.Windows.Forms.Button();
			this.textBoxSearch = new global::System.Windows.Forms.TextBox();
			this.groupBoxExport = new global::System.Windows.Forms.GroupBox();
			this.buttonExcel = new global::System.Windows.Forms.Button();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.groupBoxSelection.SuspendLayout();
			this.groupBoxCondition.SuspendLayout();
			this.groupBoxExtended.SuspendLayout();
			this.groupBoxSelMethod.SuspendLayout();
			this.groupBoxSelectionRange.SuspendLayout();
			this.groupBoxListingOption.SuspendLayout();
			this.groupBoxSearch.SuspendLayout();
			this.groupBoxExport.SuspendLayout();
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
			this.labelCount.Location = new global::System.Drawing.Point(427, 562);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new global::System.Drawing.Size(112, 16);
			this.labelCount.TabIndex = 1;
			this.labelCount.Text = "Total Selection:";
			this.groupBoxSelection.Controls.Add(this.rButtonAllProject);
			this.groupBoxSelection.Controls.Add(this.rButtonCurrentSel);
			this.groupBoxSelection.Controls.Add(this.rButtonCurrentView);
			this.groupBoxSelection.Location = new global::System.Drawing.Point(418, 52);
			this.groupBoxSelection.Name = "groupBoxSelection";
			this.groupBoxSelection.Size = new global::System.Drawing.Size(194, 90);
			this.groupBoxSelection.TabIndex = 2;
			this.groupBoxSelection.TabStop = false;
			this.groupBoxSelection.Text = "Selection Option";
			this.groupBoxSelection.Enter += new global::System.EventHandler(this.groupBoxSelection_Enter);
			this.rButtonAllProject.AutoSize = true;
			this.rButtonAllProject.Location = new global::System.Drawing.Point(6, 62);
			this.rButtonAllProject.Name = "rButtonAllProject";
			this.rButtonAllProject.Size = new global::System.Drawing.Size(77, 16);
			this.rButtonAllProject.TabIndex = 3;
			this.rButtonAllProject.TabStop = true;
			this.rButtonAllProject.Text = "All Project";
			this.rButtonAllProject.UseVisualStyleBackColor = true;
			this.rButtonAllProject.CheckedChanged += new global::System.EventHandler(this.radioButtonAllProject_CheckedChanged);
			this.rButtonCurrentSel.AutoSize = true;
			this.rButtonCurrentSel.Location = new global::System.Drawing.Point(7, 18);
			this.rButtonCurrentSel.Name = "rButtonCurrentSel";
			this.rButtonCurrentSel.Size = new global::System.Drawing.Size(112, 16);
			this.rButtonCurrentSel.TabIndex = 3;
			this.rButtonCurrentSel.TabStop = true;
			this.rButtonCurrentSel.Text = "Current Selection";
			this.rButtonCurrentSel.UseVisualStyleBackColor = true;
			this.rButtonCurrentSel.CheckedChanged += new global::System.EventHandler(this.radioButtonCurrentSel_CheckedChanged);
			this.rButtonCurrentView.AutoSize = true;
			this.rButtonCurrentView.Location = new global::System.Drawing.Point(6, 40);
			this.rButtonCurrentView.Name = "rButtonCurrentView";
			this.rButtonCurrentView.Size = new global::System.Drawing.Size(90, 16);
			this.rButtonCurrentView.TabIndex = 3;
			this.rButtonCurrentView.TabStop = true;
			this.rButtonCurrentView.Text = "Current View";
			this.rButtonCurrentView.UseVisualStyleBackColor = true;
			this.rButtonCurrentView.CheckedChanged += new global::System.EventHandler(this.radioButtonCurrentView_CheckedChanged);
			this.buttonSelect.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonSelect.Location = new global::System.Drawing.Point(430, 581);
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
			this.groupBoxCondition.Controls.Add(this.checkBoxJoined);
			this.groupBoxCondition.Controls.Add(this.checkBoxHostFamily);
			this.groupBoxCondition.Controls.Add(this.checkBoxIsHost);
			this.groupBoxCondition.Controls.Add(this.checkBoxNestedFamily);
			this.groupBoxCondition.Controls.Add(this.checkBoxHostOf);
			this.groupBoxCondition.Controls.Add(this.checkBoxWorkset);
			this.groupBoxCondition.Controls.Add(this.checkBoxFamily);
			this.groupBoxCondition.Controls.Add(this.checkBoxType);
			this.groupBoxCondition.Controls.Add(this.checkBoxCategory);
			this.groupBoxCondition.Location = new global::System.Drawing.Point(9, 18);
			this.groupBoxCondition.Name = "groupBoxCondition";
			this.groupBoxCondition.Size = new global::System.Drawing.Size(172, 216);
			this.groupBoxCondition.TabIndex = 4;
			this.groupBoxCondition.TabStop = false;
			this.groupBoxCondition.Text = "Selection Condition";
			this.checkBoxJoined.AutoSize = true;
			this.checkBoxJoined.Location = new global::System.Drawing.Point(8, 194);
			this.checkBoxJoined.Name = "checkBoxJoined";
			this.checkBoxJoined.Size = new global::System.Drawing.Size(109, 16);
			this.checkBoxJoined.TabIndex = 0;
			this.checkBoxJoined.Text = "Joined Elements";
			this.checkBoxJoined.UseVisualStyleBackColor = true;
			this.checkBoxHostFamily.AutoSize = true;
			this.checkBoxHostFamily.Location = new global::System.Drawing.Point(8, 172);
			this.checkBoxHostFamily.Name = "checkBoxHostFamily";
			this.checkBoxHostFamily.Size = new global::System.Drawing.Size(86, 16);
			this.checkBoxHostFamily.TabIndex = 0;
			this.checkBoxHostFamily.Text = "Host Family";
			this.checkBoxHostFamily.UseVisualStyleBackColor = true;
			this.checkBoxIsHost.AutoSize = true;
			this.checkBoxIsHost.Location = new global::System.Drawing.Point(8, 128);
			this.checkBoxIsHost.Name = "checkBoxIsHost";
			this.checkBoxIsHost.Size = new global::System.Drawing.Size(154, 16);
			this.checkBoxIsHost.TabIndex = 0;
			this.checkBoxIsHost.Text = "Selected Element is Host";
			this.checkBoxIsHost.UseVisualStyleBackColor = true;
			this.checkBoxNestedFamily.AutoSize = true;
			this.checkBoxNestedFamily.Location = new global::System.Drawing.Point(8, 150);
			this.checkBoxNestedFamily.Name = "checkBoxNestedFamily";
			this.checkBoxNestedFamily.Size = new global::System.Drawing.Size(98, 16);
			this.checkBoxNestedFamily.TabIndex = 0;
			this.checkBoxNestedFamily.Text = "Nested Family";
			this.checkBoxNestedFamily.UseVisualStyleBackColor = true;
			this.checkBoxHostOf.AutoSize = true;
			this.checkBoxHostOf.Location = new global::System.Drawing.Point(8, 106);
			this.checkBoxHostOf.Name = "checkBoxHostOf";
			this.checkBoxHostOf.Size = new global::System.Drawing.Size(155, 16);
			this.checkBoxHostOf.TabIndex = 0;
			this.checkBoxHostOf.Text = "Host of Selected Element";
			this.checkBoxHostOf.UseVisualStyleBackColor = true;
			this.checkBoxWorkset.AutoSize = true;
			this.checkBoxWorkset.Location = new global::System.Drawing.Point(8, 84);
			this.checkBoxWorkset.Name = "checkBoxWorkset";
			this.checkBoxWorkset.Size = new global::System.Drawing.Size(97, 16);
			this.checkBoxWorkset.TabIndex = 0;
			this.checkBoxWorkset.Text = "Same Workset";
			this.checkBoxWorkset.UseVisualStyleBackColor = true;
			this.checkBoxFamily.AutoSize = true;
			this.checkBoxFamily.Location = new global::System.Drawing.Point(8, 40);
			this.checkBoxFamily.Name = "checkBoxFamily";
			this.checkBoxFamily.Size = new global::System.Drawing.Size(90, 16);
			this.checkBoxFamily.TabIndex = 0;
			this.checkBoxFamily.Text = "Same Family";
			this.checkBoxFamily.UseVisualStyleBackColor = true;
			this.checkBoxType.AutoSize = true;
			this.checkBoxType.Location = new global::System.Drawing.Point(8, 62);
			this.checkBoxType.Name = "checkBoxType";
			this.checkBoxType.Size = new global::System.Drawing.Size(81, 16);
			this.checkBoxType.TabIndex = 0;
			this.checkBoxType.Text = "Same Type";
			this.checkBoxType.UseVisualStyleBackColor = true;
			this.checkBoxCategory.AutoSize = true;
			this.checkBoxCategory.Location = new global::System.Drawing.Point(7, 18);
			this.checkBoxCategory.Name = "checkBoxCategory";
			this.checkBoxCategory.Size = new global::System.Drawing.Size(102, 16);
			this.checkBoxCategory.TabIndex = 0;
			this.checkBoxCategory.Text = "Same Category";
			this.checkBoxCategory.UseVisualStyleBackColor = true;
			this.buttonDeselect.BackColor = global::System.Drawing.Color.IndianRed;
			this.buttonDeselect.Location = new global::System.Drawing.Point(430, 617);
			this.buttonDeselect.Name = "buttonDeselect";
			this.buttonDeselect.Size = new global::System.Drawing.Size(75, 30);
			this.buttonDeselect.TabIndex = 6;
			this.buttonDeselect.Text = "Deselect";
			this.buttonDeselect.UseVisualStyleBackColor = false;
			this.buttonDeselect.Click += new global::System.EventHandler(this.buttonDeselect_Click);
			this.groupBoxExtended.Controls.Add(this.buttonExtend);
			this.groupBoxExtended.Controls.Add(this.groupBoxSelMethod);
			this.groupBoxExtended.Controls.Add(this.groupBoxSelectionRange);
			this.groupBoxExtended.Controls.Add(this.groupBoxCondition);
			this.groupBoxExtended.Location = new global::System.Drawing.Point(631, 12);
			this.groupBoxExtended.Name = "groupBoxExtended";
			this.groupBoxExtended.Size = new global::System.Drawing.Size(191, 411);
			this.groupBoxExtended.TabIndex = 7;
			this.groupBoxExtended.TabStop = false;
			this.groupBoxExtended.Text = "Extended Selection";
			this.buttonExtend.Location = new global::System.Drawing.Point(37, 377);
			this.buttonExtend.Name = "buttonExtend";
			this.buttonExtend.Size = new global::System.Drawing.Size(100, 30);
			this.buttonExtend.TabIndex = 7;
			this.buttonExtend.Text = "Extend Selection";
			this.buttonExtend.UseVisualStyleBackColor = true;
			this.buttonExtend.Click += new global::System.EventHandler(this.buttonExtend_Click);
			this.groupBoxSelMethod.Controls.Add(this.rBNewSel);
			this.groupBoxSelMethod.Controls.Add(this.rBExtendSel);
			this.groupBoxSelMethod.Location = new global::System.Drawing.Point(5, 309);
			this.groupBoxSelMethod.Name = "groupBoxSelMethod";
			this.groupBoxSelMethod.Size = new global::System.Drawing.Size(176, 62);
			this.groupBoxSelMethod.TabIndex = 6;
			this.groupBoxSelMethod.TabStop = false;
			this.groupBoxSelMethod.Text = "Selection Method";
			this.rBNewSel.AutoSize = true;
			this.rBNewSel.Location = new global::System.Drawing.Point(11, 40);
			this.rBNewSel.Name = "rBNewSel";
			this.rBNewSel.Size = new global::System.Drawing.Size(96, 16);
			this.rBNewSel.TabIndex = 0;
			this.rBNewSel.TabStop = true;
			this.rBNewSel.Text = "New Selection";
			this.rBNewSel.UseVisualStyleBackColor = true;
			this.rBExtendSel.AutoSize = true;
			this.rBExtendSel.Location = new global::System.Drawing.Point(11, 18);
			this.rBExtendSel.Name = "rBExtendSel";
			this.rBExtendSel.Size = new global::System.Drawing.Size(151, 16);
			this.rBExtendSel.TabIndex = 0;
			this.rBExtendSel.TabStop = true;
			this.rBExtendSel.Text = "Extend Current Selection";
			this.rBExtendSel.UseVisualStyleBackColor = true;
			this.groupBoxSelectionRange.Controls.Add(this.rBAllProjectE);
			this.groupBoxSelectionRange.Controls.Add(this.rBCurrentViewE);
			this.groupBoxSelectionRange.Location = new global::System.Drawing.Point(9, 240);
			this.groupBoxSelectionRange.Name = "groupBoxSelectionRange";
			this.groupBoxSelectionRange.Size = new global::System.Drawing.Size(172, 63);
			this.groupBoxSelectionRange.TabIndex = 5;
			this.groupBoxSelectionRange.TabStop = false;
			this.groupBoxSelectionRange.Text = "Selection Range";
			this.rBAllProjectE.AutoSize = true;
			this.rBAllProjectE.Location = new global::System.Drawing.Point(8, 40);
			this.rBAllProjectE.Name = "rBAllProjectE";
			this.rBAllProjectE.Size = new global::System.Drawing.Size(77, 16);
			this.rBAllProjectE.TabIndex = 0;
			this.rBAllProjectE.TabStop = true;
			this.rBAllProjectE.Text = "All Project";
			this.rBAllProjectE.UseVisualStyleBackColor = true;
			this.rBCurrentViewE.AutoSize = true;
			this.rBCurrentViewE.Location = new global::System.Drawing.Point(8, 18);
			this.rBCurrentViewE.Name = "rBCurrentViewE";
			this.rBCurrentViewE.Size = new global::System.Drawing.Size(90, 16);
			this.rBCurrentViewE.TabIndex = 0;
			this.rBCurrentViewE.TabStop = true;
			this.rBCurrentViewE.Text = "Current View";
			this.rBCurrentViewE.UseVisualStyleBackColor = true;
			this.groupBoxListingOption.Controls.Add(this.rBWarnings);
			this.groupBoxListingOption.Controls.Add(this.rBListChanged);
			this.groupBoxListingOption.Controls.Add(this.rBListOwner);
			this.groupBoxListingOption.Controls.Add(this.rBListInplace);
			this.groupBoxListingOption.Controls.Add(this.rBListLevel);
			this.groupBoxListingOption.Controls.Add(this.rBListType);
			this.groupBoxListingOption.Controls.Add(this.rBListCreated);
			this.groupBoxListingOption.Controls.Add(this.rBListWorkset);
			this.groupBoxListingOption.Location = new global::System.Drawing.Point(418, 158);
			this.groupBoxListingOption.Name = "groupBoxListingOption";
			this.groupBoxListingOption.Size = new global::System.Drawing.Size(194, 197);
			this.groupBoxListingOption.TabIndex = 9;
			this.groupBoxListingOption.TabStop = false;
			this.groupBoxListingOption.Text = "Grouping Option";
			this.rBWarnings.AutoSize = true;
			this.rBWarnings.Location = new global::System.Drawing.Point(12, 172);
			this.rBWarnings.Name = "rBWarnings";
			this.rBWarnings.Size = new global::System.Drawing.Size(93, 16);
			this.rBWarnings.TabIndex = 15;
			this.rBWarnings.TabStop = true;
			this.rBWarnings.Text = "Has Warnings";
			this.rBWarnings.UseVisualStyleBackColor = true;
			this.rBWarnings.CheckedChanged += new global::System.EventHandler(this.radioButtonWarning_CheckedChanged);
			this.rBListChanged.AutoSize = true;
			this.rBListChanged.Location = new global::System.Drawing.Point(12, 128);
			this.rBListChanged.Name = "rBListChanged";
			this.rBListChanged.Size = new global::System.Drawing.Size(109, 16);
			this.rBListChanged.TabIndex = 14;
			this.rBListChanged.TabStop = true;
			this.rBListChanged.Text = "Last Changed by";
			this.rBListChanged.UseVisualStyleBackColor = true;
			this.rBListChanged.CheckedChanged += new global::System.EventHandler(this.rButtonListChanged_CheckedChanged);
			this.rBListOwner.AutoSize = true;
			this.rBListOwner.Location = new global::System.Drawing.Point(12, 106);
			this.rBListOwner.Name = "rBListOwner";
			this.rBListOwner.Size = new global::System.Drawing.Size(97, 16);
			this.rBListOwner.TabIndex = 13;
			this.rBListOwner.TabStop = true;
			this.rBListOwner.Text = "Current Owner";
			this.rBListOwner.UseVisualStyleBackColor = true;
			this.rBListOwner.CheckedChanged += new global::System.EventHandler(this.rButtonListOwner_CheckedChanged);
			this.rBListInplace.AutoSize = true;
			this.rBListInplace.Location = new global::System.Drawing.Point(12, 150);
			this.rBListInplace.Name = "rBListInplace";
			this.rBListInplace.Size = new global::System.Drawing.Size(93, 16);
			this.rBListInplace.TabIndex = 12;
			this.rBListInplace.TabStop = true;
			this.rBListInplace.Text = "In-Place Only";
			this.rBListInplace.UseVisualStyleBackColor = true;
			this.rBListInplace.CheckedChanged += new global::System.EventHandler(this.radioButtonInplace_CheckedChanged);
			this.rBListLevel.AutoSize = true;
			this.rBListLevel.Location = new global::System.Drawing.Point(12, 62);
			this.rBListLevel.Name = "rBListLevel";
			this.rBListLevel.Size = new global::System.Drawing.Size(50, 16);
			this.rBListLevel.TabIndex = 11;
			this.rBListLevel.TabStop = true;
			this.rBListLevel.Text = "Level";
			this.rBListLevel.UseVisualStyleBackColor = true;
			this.rBListLevel.CheckedChanged += new global::System.EventHandler(this.radioButtonListLevel_CheckedChanged);
			this.rBListType.AutoSize = true;
			this.rBListType.Location = new global::System.Drawing.Point(12, 18);
			this.rBListType.Name = "rBListType";
			this.rBListType.Size = new global::System.Drawing.Size(48, 16);
			this.rBListType.TabIndex = 10;
			this.rBListType.TabStop = true;
			this.rBListType.Text = "Type";
			this.rBListType.UseVisualStyleBackColor = true;
			this.rBListType.CheckedChanged += new global::System.EventHandler(this.radioButtonFamilyType_CheckedChanged);
			this.rBListCreated.AutoSize = true;
			this.rBListCreated.Location = new global::System.Drawing.Point(12, 84);
			this.rBListCreated.Name = "rBListCreated";
			this.rBListCreated.Size = new global::System.Drawing.Size(79, 16);
			this.rBListCreated.TabIndex = 10;
			this.rBListCreated.TabStop = true;
			this.rBListCreated.Text = "Created by";
			this.rBListCreated.UseVisualStyleBackColor = true;
			this.rBListCreated.CheckedChanged += new global::System.EventHandler(this.radioButtonUser_CheckedChanged);
			this.rBListWorkset.AutoSize = true;
			this.rBListWorkset.Location = new global::System.Drawing.Point(12, 40);
			this.rBListWorkset.Name = "rBListWorkset";
			this.rBListWorkset.Size = new global::System.Drawing.Size(64, 16);
			this.rBListWorkset.TabIndex = 10;
			this.rBListWorkset.TabStop = true;
			this.rBListWorkset.Text = "Workset";
			this.rBListWorkset.UseVisualStyleBackColor = true;
			this.rBListWorkset.CheckedChanged += new global::System.EventHandler(this.radioButtonWorkset_CheckedChanged);
			this.groupBoxSearch.Controls.Add(this.rBFamilyName);
			this.groupBoxSearch.Controls.Add(this.rBTypeName);
			this.groupBoxSearch.Controls.Add(this.comboBoxSearch);
			this.groupBoxSearch.Controls.Add(this.buttonReset);
			this.groupBoxSearch.Controls.Add(this.buttonSearch);
			this.groupBoxSearch.Controls.Add(this.textBoxSearch);
			this.groupBoxSearch.Location = new global::System.Drawing.Point(418, 389);
			this.groupBoxSearch.Name = "groupBoxSearch";
			this.groupBoxSearch.Size = new global::System.Drawing.Size(194, 146);
			this.groupBoxSearch.TabIndex = 12;
			this.groupBoxSearch.TabStop = false;
			this.groupBoxSearch.Text = "Search";
			this.rBFamilyName.AutoSize = true;
			this.rBFamilyName.Location = new global::System.Drawing.Point(98, 78);
			this.rBFamilyName.Name = "rBFamilyName";
			this.rBFamilyName.Size = new global::System.Drawing.Size(90, 16);
			this.rBFamilyName.TabIndex = 3;
			this.rBFamilyName.TabStop = true;
			this.rBFamilyName.Text = "Family Name";
			this.rBFamilyName.UseVisualStyleBackColor = true;
			this.rBTypeName.AutoSize = true;
			this.rBTypeName.Location = new global::System.Drawing.Point(11, 79);
			this.rBTypeName.Name = "rBTypeName";
			this.rBTypeName.Size = new global::System.Drawing.Size(81, 16);
			this.rBTypeName.TabIndex = 3;
			this.rBTypeName.TabStop = true;
			this.rBTypeName.Text = "Type Name";
			this.rBTypeName.UseVisualStyleBackColor = true;
			this.comboBoxSearch.FormattingEnabled = true;
			this.comboBoxSearch.Location = new global::System.Drawing.Point(12, 43);
			this.comboBoxSearch.Name = "comboBoxSearch";
			this.comboBoxSearch.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxSearch.TabIndex = 2;
			this.buttonReset.Location = new global::System.Drawing.Point(113, 110);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new global::System.Drawing.Size(75, 30);
			this.buttonReset.TabIndex = 1;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new global::System.EventHandler(this.buttonReset_Click);
			this.buttonSearch.Location = new global::System.Drawing.Point(6, 110);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new global::System.Drawing.Size(75, 30);
			this.buttonSearch.TabIndex = 1;
			this.buttonSearch.Text = "Search";
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new global::System.EventHandler(this.buttonSearch_Click);
			this.textBoxSearch.Location = new global::System.Drawing.Point(12, 18);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new global::System.Drawing.Size(159, 19);
			this.textBoxSearch.TabIndex = 0;
			this.groupBoxExport.Controls.Add(this.buttonExcel);
			this.groupBoxExport.Location = new global::System.Drawing.Point(631, 439);
			this.groupBoxExport.Name = "groupBoxExport";
			this.groupBoxExport.Size = new global::System.Drawing.Size(191, 58);
			this.groupBoxExport.TabIndex = 13;
			this.groupBoxExport.TabStop = false;
			this.groupBoxExport.Text = "Export to Excel";
			this.buttonExcel.Location = new global::System.Drawing.Point(6, 18);
			this.buttonExcel.Name = "buttonExcel";
			this.buttonExcel.Size = new global::System.Drawing.Size(75, 30);
			this.buttonExcel.TabIndex = 0;
			this.buttonExcel.Text = "Excel";
			this.buttonExcel.UseVisualStyleBackColor = true;
			this.buttonExcel.Click += new global::System.EventHandler(this.buttonExcel_Click);
			this.buttonClose.Location = new global::System.Drawing.Point(537, 617);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(75, 30);
			this.buttonClose.TabIndex = 14;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(634, 661);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.groupBoxExport);
			base.Controls.Add(this.groupBoxSearch);
			base.Controls.Add(this.groupBoxListingOption);
			base.Controls.Add(this.groupBoxExtended);
			base.Controls.Add(this.buttonDeselect);
			base.Controls.Add(this.buttonCollapse);
			base.Controls.Add(this.buttonExpand);
			base.Controls.Add(this.buttonUncheck);
			base.Controls.Add(this.buttonCheck);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.groupBoxSelection);
			base.Controls.Add(this.labelCount);
			base.Controls.Add(this.treeViewElements);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "SelectFilterForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Filter";
			base.Load += new global::System.EventHandler(this.SelectFilterForm_Load);
			this.groupBoxSelection.ResumeLayout(false);
			this.groupBoxSelection.PerformLayout();
			this.groupBoxCondition.ResumeLayout(false);
			this.groupBoxCondition.PerformLayout();
			this.groupBoxExtended.ResumeLayout(false);
			this.groupBoxSelMethod.ResumeLayout(false);
			this.groupBoxSelMethod.PerformLayout();
			this.groupBoxSelectionRange.ResumeLayout(false);
			this.groupBoxSelectionRange.PerformLayout();
			this.groupBoxListingOption.ResumeLayout(false);
			this.groupBoxListingOption.PerformLayout();
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			this.groupBoxExport.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000154 RID: 340
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.TreeView treeViewElements;

		// Token: 0x04000156 RID: 342
		private global::System.Windows.Forms.Label labelCount;

		// Token: 0x04000157 RID: 343
		private global::System.Windows.Forms.GroupBox groupBoxSelection;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.RadioButton rButtonAllProject;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.RadioButton rButtonCurrentSel;

		// Token: 0x0400015A RID: 346
		private global::System.Windows.Forms.RadioButton rButtonCurrentView;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.Button buttonSelect;

		// Token: 0x0400015C RID: 348
		private global::System.Windows.Forms.Button buttonCheck;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.Button buttonUncheck;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.Button buttonExpand;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.Button buttonCollapse;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.GroupBox groupBoxCondition;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.CheckBox checkBoxWorkset;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.CheckBox checkBoxFamily;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.CheckBox checkBoxType;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.CheckBox checkBoxCategory;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.Button buttonDeselect;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.CheckBox checkBoxJoined;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.CheckBox checkBoxHostFamily;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.CheckBox checkBoxIsHost;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.CheckBox checkBoxNestedFamily;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.CheckBox checkBoxHostOf;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.GroupBox groupBoxExtended;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.Button buttonExtend;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.GroupBox groupBoxSelMethod;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.RadioButton rBNewSel;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.RadioButton rBExtendSel;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.GroupBox groupBoxSelectionRange;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.RadioButton rBAllProjectE;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.RadioButton rBCurrentViewE;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.GroupBox groupBoxListingOption;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.RadioButton rBListType;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.RadioButton rBListCreated;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.RadioButton rBListWorkset;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.RadioButton rBListLevel;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.RadioButton rBListInplace;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.RadioButton rBListChanged;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.RadioButton rBListOwner;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.GroupBox groupBoxSearch;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.ComboBox comboBoxSearch;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.Button buttonReset;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.Button buttonSearch;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.TextBox textBoxSearch;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.RadioButton rBFamilyName;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.RadioButton rBTypeName;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.GroupBox groupBoxExport;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.Button buttonExcel;

		// Token: 0x04000184 RID: 388
		private global::System.Windows.Forms.Button buttonClose;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.RadioButton rBWarnings;
	}
}
