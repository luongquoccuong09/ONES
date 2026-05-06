namespace ONES
{
	// Token: 0x02000085 RID: 133
	public partial class ColorFilterForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600031F RID: 799 RVA: 0x000305FC File Offset: 0x0002E7FC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0003061C File Offset: 0x0002E81C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.buttonFilter = new global::System.Windows.Forms.Button();
			this.listViewParameters = new global::System.Windows.Forms.ListView();
			this.columnHeaderPar = new global::System.Windows.Forms.ColumnHeader();
			this.listViewValues = new global::System.Windows.Forms.ListView();
			this.columnHeaderVal = new global::System.Windows.Forms.ColumnHeader();
			this.groupBoxElements = new global::System.Windows.Forms.GroupBox();
			this.RBAll = new global::System.Windows.Forms.RadioButton();
			this.RBAView = new global::System.Windows.Forms.RadioButton();
			this.buttonAll = new global::System.Windows.Forms.Button();
			this.buttonNone = new global::System.Windows.Forms.Button();
			this.buttonOverride = new global::System.Windows.Forms.Button();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			this.groupBoxParameterType = new global::System.Windows.Forms.GroupBox();
			this.RBType = new global::System.Windows.Forms.RadioButton();
			this.RBInstance = new global::System.Windows.Forms.RadioButton();
			this.columnHeaderCat = new global::System.Windows.Forms.ColumnHeader();
			this.listViewCategory = new global::System.Windows.Forms.ListView();
			this.checkBoxHalftone = new global::System.Windows.Forms.CheckBox();
			this.checkBoxTemplate = new global::System.Windows.Forms.CheckBox();
			this.groupBoxGraphic = new global::System.Windows.Forms.GroupBox();
			this.groupBoxTransparency = new global::System.Windows.Forms.GroupBox();
			this.textBoxTransparency = new global::System.Windows.Forms.TextBox();
			this.trackBarTransparency = new global::System.Windows.Forms.TrackBar();
			this.checkBoxCut = new global::System.Windows.Forms.CheckBox();
			this.checkBoxNest = new global::System.Windows.Forms.CheckBox();
			this.checkBoxSurface = new global::System.Windows.Forms.CheckBox();
			this.checkBoxLine = new global::System.Windows.Forms.CheckBox();
			this.groupBoxFilter = new global::System.Windows.Forms.GroupBox();
			this.textBoxCustomName = new global::System.Windows.Forms.TextBox();
			this.checkBoxCustomName = new global::System.Windows.Forms.CheckBox();
			this.groupBoxColor = new global::System.Windows.Forms.GroupBox();
			this.RBPalette3 = new global::System.Windows.Forms.RadioButton();
			this.RBPaletteRandom = new global::System.Windows.Forms.RadioButton();
			this.buttonRefresh = new global::System.Windows.Forms.Button();
			this.RBPalette2 = new global::System.Windows.Forms.RadioButton();
			this.RBPalette1 = new global::System.Windows.Forms.RadioButton();
			this.groupBoxParameterRange = new global::System.Windows.Forms.GroupBox();
			this.RBParamAll = new global::System.Windows.Forms.RadioButton();
			this.RBParamOrdered = new global::System.Windows.Forms.RadioButton();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.groupBoxOverride = new global::System.Windows.Forms.GroupBox();
			this.buttonResetOverride = new global::System.Windows.Forms.Button();
			this.groupBoxText = new global::System.Windows.Forms.GroupBox();
			this.RBTextWhite = new global::System.Windows.Forms.RadioButton();
			this.RBTextBlack = new global::System.Windows.Forms.RadioButton();
			this.toolTipFilter = new global::System.Windows.Forms.ToolTip(this.components);
			this.groupBoxElements.SuspendLayout();
			this.groupBoxParameterType.SuspendLayout();
			this.groupBoxGraphic.SuspendLayout();
			this.groupBoxTransparency.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarTransparency).BeginInit();
			this.groupBoxFilter.SuspendLayout();
			this.groupBoxColor.SuspendLayout();
			this.groupBoxParameterRange.SuspendLayout();
			this.groupBoxOverride.SuspendLayout();
			this.groupBoxText.SuspendLayout();
			base.SuspendLayout();
			this.buttonFilter.Location = new global::System.Drawing.Point(6, 67);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new global::System.Drawing.Size(80, 25);
			this.buttonFilter.TabIndex = 4;
			this.buttonFilter.Text = "Filter";
			this.buttonFilter.UseVisualStyleBackColor = true;
			this.buttonFilter.Click += new global::System.EventHandler(this.buttonFilter_Click);
			this.listViewParameters.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeaderPar
			});
			this.listViewParameters.HideSelection = false;
			this.listViewParameters.Location = new global::System.Drawing.Point(343, 53);
			this.listViewParameters.Name = "listViewParameters";
			this.listViewParameters.Size = new global::System.Drawing.Size(300, 559);
			this.listViewParameters.TabIndex = 9;
			this.listViewParameters.UseCompatibleStateImageBehavior = false;
			this.listViewParameters.View = global::System.Windows.Forms.View.Details;
			this.listViewParameters.SelectedIndexChanged += new global::System.EventHandler(this.listViewParameters_SelectedIndexChanged);
			this.columnHeaderPar.Text = "Parameter";
			this.columnHeaderPar.Width = 279;
			this.listViewValues.CheckBoxes = true;
			this.listViewValues.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeaderVal
			});
			this.listViewValues.HideSelection = false;
			this.listViewValues.Location = new global::System.Drawing.Point(658, 12);
			this.listViewValues.Name = "listViewValues";
			this.listViewValues.Size = new global::System.Drawing.Size(330, 460);
			this.listViewValues.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.listViewValues.TabIndex = 11;
			this.listViewValues.UseCompatibleStateImageBehavior = false;
			this.listViewValues.View = global::System.Windows.Forms.View.Details;
			this.listViewValues.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.listViewValues_ItemCheck);
			this.listViewValues.ItemChecked += new global::System.Windows.Forms.ItemCheckedEventHandler(this.listViewValues_ItemCheck);
			this.listViewValues.SelectedIndexChanged += new global::System.EventHandler(this.listViewValues_SelectedIndexChanged);
			this.columnHeaderVal.Text = "Value";
			this.columnHeaderVal.Width = 319;
			this.groupBoxElements.Controls.Add(this.RBAll);
			this.groupBoxElements.Controls.Add(this.RBAView);
			this.groupBoxElements.Location = new global::System.Drawing.Point(12, 12);
			this.groupBoxElements.Name = "groupBoxElements";
			this.groupBoxElements.Size = new global::System.Drawing.Size(325, 36);
			this.groupBoxElements.TabIndex = 12;
			this.groupBoxElements.TabStop = false;
			this.groupBoxElements.Text = "Elements to be Selected";
			this.groupBoxElements.Enter += new global::System.EventHandler(this.groupBox1_Enter);
			this.RBAll.AutoSize = true;
			this.RBAll.Location = new global::System.Drawing.Point(117, 14);
			this.RBAll.Name = "RBAll";
			this.RBAll.Size = new global::System.Drawing.Size(77, 16);
			this.RBAll.TabIndex = 14;
			this.RBAll.TabStop = true;
			this.RBAll.Text = "All Project";
			this.RBAll.UseVisualStyleBackColor = true;
			this.RBAll.CheckedChanged += new global::System.EventHandler(this.radioButtonAll_CheckedChanged);
			this.RBAView.AutoSize = true;
			this.RBAView.Location = new global::System.Drawing.Point(6, 16);
			this.RBAView.Name = "RBAView";
			this.RBAView.Size = new global::System.Drawing.Size(85, 16);
			this.RBAView.TabIndex = 13;
			this.RBAView.TabStop = true;
			this.RBAView.Text = "Active View";
			this.RBAView.UseVisualStyleBackColor = true;
			this.RBAView.CheckedChanged += new global::System.EventHandler(this.radioButtonAView_CheckedChanged);
			this.buttonAll.Location = new global::System.Drawing.Point(658, 477);
			this.buttonAll.Name = "buttonAll";
			this.buttonAll.Size = new global::System.Drawing.Size(90, 22);
			this.buttonAll.TabIndex = 13;
			this.buttonAll.Text = "Check All";
			this.buttonAll.UseVisualStyleBackColor = true;
			this.buttonAll.Click += new global::System.EventHandler(this.buttonAll_Click);
			this.buttonNone.Location = new global::System.Drawing.Point(754, 477);
			this.buttonNone.Name = "buttonNone";
			this.buttonNone.Size = new global::System.Drawing.Size(90, 22);
			this.buttonNone.TabIndex = 14;
			this.buttonNone.Text = "Uncheck All";
			this.buttonNone.UseVisualStyleBackColor = true;
			this.buttonNone.Click += new global::System.EventHandler(this.buttonNone_Click);
			this.buttonOverride.Location = new global::System.Drawing.Point(6, 67);
			this.buttonOverride.Name = "buttonOverride";
			this.buttonOverride.Size = new global::System.Drawing.Size(80, 25);
			this.buttonOverride.TabIndex = 15;
			this.buttonOverride.Text = "Override";
			this.buttonOverride.UseVisualStyleBackColor = true;
			this.buttonOverride.Click += new global::System.EventHandler(this.buttonOverride_Click);
			this.buttonSelect.Location = new global::System.Drawing.Point(1079, 556);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new global::System.Drawing.Size(80, 25);
			this.buttonSelect.TabIndex = 16;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new global::System.EventHandler(this.buttonShow_Click);
			this.groupBoxParameterType.Controls.Add(this.RBType);
			this.groupBoxParameterType.Controls.Add(this.RBInstance);
			this.groupBoxParameterType.Location = new global::System.Drawing.Point(12, 50);
			this.groupBoxParameterType.Name = "groupBoxParameterType";
			this.groupBoxParameterType.Size = new global::System.Drawing.Size(325, 36);
			this.groupBoxParameterType.TabIndex = 17;
			this.groupBoxParameterType.TabStop = false;
			this.groupBoxParameterType.Text = "Parameter Type";
			this.RBType.AutoSize = true;
			this.RBType.Location = new global::System.Drawing.Point(117, 14);
			this.RBType.Name = "RBType";
			this.RBType.Size = new global::System.Drawing.Size(48, 16);
			this.RBType.TabIndex = 14;
			this.RBType.TabStop = true;
			this.RBType.Text = "Type";
			this.RBType.UseVisualStyleBackColor = true;
			this.RBType.CheckedChanged += new global::System.EventHandler(this.radioButtonType_CheckedChanged);
			this.RBInstance.AutoSize = true;
			this.RBInstance.Location = new global::System.Drawing.Point(6, 16);
			this.RBInstance.Name = "RBInstance";
			this.RBInstance.Size = new global::System.Drawing.Size(66, 16);
			this.RBInstance.TabIndex = 13;
			this.RBInstance.TabStop = true;
			this.RBInstance.Text = "Instance";
			this.RBInstance.UseVisualStyleBackColor = true;
			this.RBInstance.CheckedChanged += new global::System.EventHandler(this.radioButtonInstance_CheckedChanged);
			this.columnHeaderCat.Text = "Category";
			this.columnHeaderCat.Width = 291;
			this.listViewCategory.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeaderCat
			});
			this.listViewCategory.HideSelection = false;
			this.listViewCategory.Location = new global::System.Drawing.Point(12, 92);
			this.listViewCategory.Name = "listViewCategory";
			this.listViewCategory.Size = new global::System.Drawing.Size(320, 520);
			this.listViewCategory.TabIndex = 8;
			this.listViewCategory.UseCompatibleStateImageBehavior = false;
			this.listViewCategory.View = global::System.Windows.Forms.View.Details;
			this.listViewCategory.SelectedIndexChanged += new global::System.EventHandler(this.listViewCategory_SelectedIndexChanged);
			this.checkBoxHalftone.AutoSize = true;
			this.checkBoxHalftone.Location = new global::System.Drawing.Point(6, 18);
			this.checkBoxHalftone.Name = "checkBoxHalftone";
			this.checkBoxHalftone.Size = new global::System.Drawing.Size(67, 16);
			this.checkBoxHalftone.TabIndex = 18;
			this.checkBoxHalftone.Text = "Halftone";
			this.checkBoxHalftone.UseVisualStyleBackColor = true;
			this.checkBoxHalftone.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.checkBoxTemplate.AutoSize = true;
			this.checkBoxTemplate.Location = new global::System.Drawing.Point(6, 40);
			this.checkBoxTemplate.Name = "checkBoxTemplate";
			this.checkBoxTemplate.Size = new global::System.Drawing.Size(71, 16);
			this.checkBoxTemplate.TabIndex = 19;
			this.checkBoxTemplate.Text = "Template";
			this.checkBoxTemplate.UseVisualStyleBackColor = true;
			this.checkBoxTemplate.CheckedChanged += new global::System.EventHandler(this.checkBoxTemplate_CheckedChanged);
			this.groupBoxGraphic.Controls.Add(this.groupBoxTransparency);
			this.groupBoxGraphic.Controls.Add(this.checkBoxCut);
			this.groupBoxGraphic.Controls.Add(this.checkBoxNest);
			this.groupBoxGraphic.Controls.Add(this.checkBoxHalftone);
			this.groupBoxGraphic.Controls.Add(this.checkBoxSurface);
			this.groupBoxGraphic.Controls.Add(this.checkBoxLine);
			this.groupBoxGraphic.Location = new global::System.Drawing.Point(1006, 242);
			this.groupBoxGraphic.Name = "groupBoxGraphic";
			this.groupBoxGraphic.Size = new global::System.Drawing.Size(136, 230);
			this.groupBoxGraphic.TabIndex = 20;
			this.groupBoxGraphic.TabStop = false;
			this.groupBoxGraphic.Text = "Graphic Settings";
			this.groupBoxTransparency.Controls.Add(this.textBoxTransparency);
			this.groupBoxTransparency.Controls.Add(this.trackBarTransparency);
			this.groupBoxTransparency.Location = new global::System.Drawing.Point(6, 131);
			this.groupBoxTransparency.Name = "groupBoxTransparency";
			this.groupBoxTransparency.Size = new global::System.Drawing.Size(110, 90);
			this.groupBoxTransparency.TabIndex = 24;
			this.groupBoxTransparency.TabStop = false;
			this.groupBoxTransparency.Text = "Transparency";
			this.textBoxTransparency.Location = new global::System.Drawing.Point(39, 66);
			this.textBoxTransparency.Name = "textBoxTransparency";
			this.textBoxTransparency.Size = new global::System.Drawing.Size(35, 19);
			this.textBoxTransparency.TabIndex = 25;
			this.textBoxTransparency.TextChanged += new global::System.EventHandler(this.textBoxTransparency_TextChanged);
			this.trackBarTransparency.Location = new global::System.Drawing.Point(9, 15);
			this.trackBarTransparency.Name = "trackBarTransparency";
			this.trackBarTransparency.Size = new global::System.Drawing.Size(95, 45);
			this.trackBarTransparency.TabIndex = 24;
			this.trackBarTransparency.Scroll += new global::System.EventHandler(this.trackBarTransparency_Scroll);
			this.checkBoxCut.AutoSize = true;
			this.checkBoxCut.Location = new global::System.Drawing.Point(6, 106);
			this.checkBoxCut.Name = "checkBoxCut";
			this.checkBoxCut.Size = new global::System.Drawing.Size(42, 16);
			this.checkBoxCut.TabIndex = 16;
			this.checkBoxCut.Text = "Cut";
			this.checkBoxCut.UseVisualStyleBackColor = true;
			this.checkBoxNest.AutoSize = true;
			this.checkBoxNest.Enabled = false;
			this.checkBoxNest.Location = new global::System.Drawing.Point(6, 62);
			this.checkBoxNest.Name = "checkBoxNest";
			this.checkBoxNest.Size = new global::System.Drawing.Size(60, 16);
			this.checkBoxNest.TabIndex = 16;
			this.checkBoxNest.Text = "Nested";
			this.checkBoxNest.UseVisualStyleBackColor = true;
			this.checkBoxSurface.AutoSize = true;
			this.checkBoxSurface.Location = new global::System.Drawing.Point(6, 84);
			this.checkBoxSurface.Name = "checkBoxSurface";
			this.checkBoxSurface.Size = new global::System.Drawing.Size(63, 16);
			this.checkBoxSurface.TabIndex = 16;
			this.checkBoxSurface.Text = "Surface";
			this.checkBoxSurface.UseVisualStyleBackColor = true;
			this.checkBoxLine.AutoSize = true;
			this.checkBoxLine.Location = new global::System.Drawing.Point(6, 40);
			this.checkBoxLine.Name = "checkBoxLine";
			this.checkBoxLine.Size = new global::System.Drawing.Size(45, 16);
			this.checkBoxLine.TabIndex = 16;
			this.checkBoxLine.Text = "Line";
			this.checkBoxLine.UseVisualStyleBackColor = true;
			this.groupBoxFilter.Controls.Add(this.textBoxCustomName);
			this.groupBoxFilter.Controls.Add(this.checkBoxCustomName);
			this.groupBoxFilter.Controls.Add(this.checkBoxTemplate);
			this.groupBoxFilter.Controls.Add(this.buttonFilter);
			this.groupBoxFilter.Location = new global::System.Drawing.Point(658, 516);
			this.groupBoxFilter.Name = "groupBoxFilter";
			this.groupBoxFilter.Size = new global::System.Drawing.Size(226, 98);
			this.groupBoxFilter.TabIndex = 21;
			this.groupBoxFilter.TabStop = false;
			this.groupBoxFilter.Text = "Filter Settings";
			this.textBoxCustomName.Enabled = false;
			this.textBoxCustomName.Location = new global::System.Drawing.Point(102, 15);
			this.textBoxCustomName.Name = "textBoxCustomName";
			this.textBoxCustomName.Size = new global::System.Drawing.Size(107, 19);
			this.textBoxCustomName.TabIndex = 21;
			this.checkBoxCustomName.AutoSize = true;
			this.checkBoxCustomName.Location = new global::System.Drawing.Point(6, 18);
			this.checkBoxCustomName.Name = "checkBoxCustomName";
			this.checkBoxCustomName.Size = new global::System.Drawing.Size(96, 16);
			this.checkBoxCustomName.TabIndex = 20;
			this.checkBoxCustomName.Text = "Custom Name";
			this.checkBoxCustomName.UseVisualStyleBackColor = true;
			this.checkBoxCustomName.CheckedChanged += new global::System.EventHandler(this.checkBoxCustomName_CheckedChanged);
			this.groupBoxColor.Controls.Add(this.RBPalette3);
			this.groupBoxColor.Controls.Add(this.RBPaletteRandom);
			this.groupBoxColor.Controls.Add(this.buttonRefresh);
			this.groupBoxColor.Controls.Add(this.RBPalette2);
			this.groupBoxColor.Controls.Add(this.RBPalette1);
			this.groupBoxColor.Location = new global::System.Drawing.Point(1006, 12);
			this.groupBoxColor.Name = "groupBoxColor";
			this.groupBoxColor.Size = new global::System.Drawing.Size(136, 149);
			this.groupBoxColor.TabIndex = 22;
			this.groupBoxColor.TabStop = false;
			this.groupBoxColor.Text = "Color Options";
			this.RBPalette3.AutoSize = true;
			this.RBPalette3.Location = new global::System.Drawing.Point(5, 62);
			this.RBPalette3.Name = "RBPalette3";
			this.RBPalette3.Size = new global::System.Drawing.Size(69, 16);
			this.RBPalette3.TabIndex = 26;
			this.RBPalette3.TabStop = true;
			this.RBPalette3.Text = "Palette 3";
			this.RBPalette3.UseVisualStyleBackColor = true;
			this.RBPaletteRandom.AutoSize = true;
			this.RBPaletteRandom.Location = new global::System.Drawing.Point(5, 84);
			this.RBPaletteRandom.Name = "RBPaletteRandom";
			this.RBPaletteRandom.Size = new global::System.Drawing.Size(64, 16);
			this.RBPaletteRandom.TabIndex = 23;
			this.RBPaletteRandom.TabStop = true;
			this.RBPaletteRandom.Text = "Random";
			this.RBPaletteRandom.UseVisualStyleBackColor = true;
			this.RBPaletteRandom.CheckedChanged += new global::System.EventHandler(this.RBPaletteRandom_CheckedChanged);
			this.buttonRefresh.Location = new global::System.Drawing.Point(5, 115);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new global::System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 25;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new global::System.EventHandler(this.buttonRefresh_Click);
			this.RBPalette2.AutoSize = true;
			this.RBPalette2.Location = new global::System.Drawing.Point(6, 40);
			this.RBPalette2.Name = "RBPalette2";
			this.RBPalette2.Size = new global::System.Drawing.Size(69, 16);
			this.RBPalette2.TabIndex = 23;
			this.RBPalette2.TabStop = true;
			this.RBPalette2.Text = "Palette 2";
			this.RBPalette2.UseVisualStyleBackColor = true;
			this.RBPalette2.CheckedChanged += new global::System.EventHandler(this.RBPalette2_CheckedChanged);
			this.RBPalette1.AutoSize = true;
			this.RBPalette1.Location = new global::System.Drawing.Point(6, 18);
			this.RBPalette1.Name = "RBPalette1";
			this.RBPalette1.Size = new global::System.Drawing.Size(69, 16);
			this.RBPalette1.TabIndex = 23;
			this.RBPalette1.TabStop = true;
			this.RBPalette1.Text = "Palette 1";
			this.RBPalette1.UseVisualStyleBackColor = true;
			this.RBPalette1.CheckedChanged += new global::System.EventHandler(this.RBPalette1_CheckedChanged);
			this.groupBoxParameterRange.Controls.Add(this.RBParamAll);
			this.groupBoxParameterRange.Controls.Add(this.RBParamOrdered);
			this.groupBoxParameterRange.Location = new global::System.Drawing.Point(343, 11);
			this.groupBoxParameterRange.Name = "groupBoxParameterRange";
			this.groupBoxParameterRange.Size = new global::System.Drawing.Size(300, 36);
			this.groupBoxParameterRange.TabIndex = 23;
			this.groupBoxParameterRange.TabStop = false;
			this.groupBoxParameterRange.Text = "Parameter Range";
			this.RBParamAll.AutoSize = true;
			this.RBParamAll.Location = new global::System.Drawing.Point(6, 18);
			this.RBParamAll.Name = "RBParamAll";
			this.RBParamAll.Size = new global::System.Drawing.Size(99, 16);
			this.RBParamAll.TabIndex = 1;
			this.RBParamAll.TabStop = true;
			this.RBParamAll.Text = "All Parameters";
			this.RBParamAll.UseVisualStyleBackColor = true;
			this.RBParamOrdered.AutoSize = true;
			this.RBParamOrdered.Location = new global::System.Drawing.Point(154, 14);
			this.RBParamOrdered.Name = "RBParamOrdered";
			this.RBParamOrdered.Size = new global::System.Drawing.Size(125, 16);
			this.RBParamOrdered.TabIndex = 0;
			this.RBParamOrdered.TabStop = true;
			this.RBParamOrdered.Text = "Ordered Parameters";
			this.RBParamOrdered.UseVisualStyleBackColor = true;
			this.RBParamOrdered.CheckedChanged += new global::System.EventHandler(this.RBParamOrdered_CheckedChanged);
			this.buttonClose.Location = new global::System.Drawing.Point(1079, 590);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(80, 25);
			this.buttonClose.TabIndex = 24;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.groupBoxOverride.Controls.Add(this.buttonResetOverride);
			this.groupBoxOverride.Controls.Add(this.buttonOverride);
			this.groupBoxOverride.Location = new global::System.Drawing.Point(899, 517);
			this.groupBoxOverride.Name = "groupBoxOverride";
			this.groupBoxOverride.Size = new global::System.Drawing.Size(116, 98);
			this.groupBoxOverride.TabIndex = 26;
			this.groupBoxOverride.TabStop = false;
			this.groupBoxOverride.Text = "Override";
			this.buttonResetOverride.Location = new global::System.Drawing.Point(6, 31);
			this.buttonResetOverride.Name = "buttonResetOverride";
			this.buttonResetOverride.Size = new global::System.Drawing.Size(80, 25);
			this.buttonResetOverride.TabIndex = 16;
			this.buttonResetOverride.Text = "Reset";
			this.buttonResetOverride.UseVisualStyleBackColor = true;
			this.buttonResetOverride.Click += new global::System.EventHandler(this.buttonClear_Click);
			this.groupBoxText.Controls.Add(this.RBTextWhite);
			this.groupBoxText.Controls.Add(this.RBTextBlack);
			this.groupBoxText.Location = new global::System.Drawing.Point(1006, 167);
			this.groupBoxText.Name = "groupBoxText";
			this.groupBoxText.Size = new global::System.Drawing.Size(136, 68);
			this.groupBoxText.TabIndex = 27;
			this.groupBoxText.TabStop = false;
			this.groupBoxText.Text = "Text Color";
			this.RBTextWhite.AutoSize = true;
			this.RBTextWhite.Location = new global::System.Drawing.Point(6, 40);
			this.RBTextWhite.Name = "RBTextWhite";
			this.RBTextWhite.Size = new global::System.Drawing.Size(51, 16);
			this.RBTextWhite.TabIndex = 0;
			this.RBTextWhite.TabStop = true;
			this.RBTextWhite.Text = "White";
			this.RBTextWhite.UseVisualStyleBackColor = true;
			this.RBTextBlack.AutoSize = true;
			this.RBTextBlack.Location = new global::System.Drawing.Point(6, 18);
			this.RBTextBlack.Name = "RBTextBlack";
			this.RBTextBlack.Size = new global::System.Drawing.Size(52, 16);
			this.RBTextBlack.TabIndex = 0;
			this.RBTextBlack.TabStop = true;
			this.RBTextBlack.Text = "Black";
			this.RBTextBlack.UseVisualStyleBackColor = true;
			this.RBTextBlack.CheckedChanged += new global::System.EventHandler(this.RBTextBlack_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			base.ClientSize = new global::System.Drawing.Size(1171, 626);
			base.Controls.Add(this.groupBoxText);
			base.Controls.Add(this.groupBoxOverride);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.groupBoxParameterRange);
			base.Controls.Add(this.groupBoxColor);
			base.Controls.Add(this.groupBoxFilter);
			base.Controls.Add(this.groupBoxGraphic);
			base.Controls.Add(this.groupBoxParameterType);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.buttonNone);
			base.Controls.Add(this.buttonAll);
			base.Controls.Add(this.groupBoxElements);
			base.Controls.Add(this.listViewValues);
			base.Controls.Add(this.listViewParameters);
			base.Controls.Add(this.listViewCategory);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "ColorFilterForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Color Filter";
			base.Load += new global::System.EventHandler(this.ColorElementsForm_Load);
			this.groupBoxElements.ResumeLayout(false);
			this.groupBoxElements.PerformLayout();
			this.groupBoxParameterType.ResumeLayout(false);
			this.groupBoxParameterType.PerformLayout();
			this.groupBoxGraphic.ResumeLayout(false);
			this.groupBoxGraphic.PerformLayout();
			this.groupBoxTransparency.ResumeLayout(false);
			this.groupBoxTransparency.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarTransparency).EndInit();
			this.groupBoxFilter.ResumeLayout(false);
			this.groupBoxFilter.PerformLayout();
			this.groupBoxColor.ResumeLayout(false);
			this.groupBoxColor.PerformLayout();
			this.groupBoxParameterRange.ResumeLayout(false);
			this.groupBoxParameterRange.PerformLayout();
			this.groupBoxOverride.ResumeLayout(false);
			this.groupBoxText.ResumeLayout(false);
			this.groupBoxText.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000238 RID: 568
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.Button buttonFilter;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.ListView listViewParameters;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.ListView listViewValues;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.ColumnHeader columnHeaderPar;

		// Token: 0x0400023D RID: 573
		private global::System.Windows.Forms.ColumnHeader columnHeaderVal;

		// Token: 0x0400023E RID: 574
		private global::System.Windows.Forms.GroupBox groupBoxElements;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.RadioButton RBAView;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.RadioButton RBAll;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.Button buttonAll;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.Button buttonNone;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.Button buttonOverride;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.Button buttonSelect;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.GroupBox groupBoxParameterType;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.RadioButton RBType;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.RadioButton RBInstance;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.ColumnHeader columnHeaderCat;

		// Token: 0x04000249 RID: 585
		private global::System.Windows.Forms.ListView listViewCategory;

		// Token: 0x0400024A RID: 586
		private global::System.Windows.Forms.CheckBox checkBoxHalftone;

		// Token: 0x0400024B RID: 587
		private global::System.Windows.Forms.CheckBox checkBoxTemplate;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.GroupBox groupBoxGraphic;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.CheckBox checkBoxCut;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.CheckBox checkBoxNest;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.CheckBox checkBoxSurface;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.CheckBox checkBoxLine;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.GroupBox groupBoxFilter;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.GroupBox groupBoxColor;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.RadioButton RBPalette2;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.RadioButton RBPalette1;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.GroupBox groupBoxParameterRange;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.RadioButton RBParamAll;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.RadioButton RBParamOrdered;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.GroupBox groupBoxTransparency;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.TextBox textBoxTransparency;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.TrackBar trackBarTransparency;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.Button buttonClose;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.Button buttonRefresh;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.RadioButton RBPaletteRandom;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.GroupBox groupBoxOverride;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.GroupBox groupBoxText;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.RadioButton RBTextWhite;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.RadioButton RBTextBlack;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.RadioButton RBPalette3;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.TextBox textBoxCustomName;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.CheckBox checkBoxCustomName;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.Button buttonResetOverride;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.ToolTip toolTipFilter;
	}
}
