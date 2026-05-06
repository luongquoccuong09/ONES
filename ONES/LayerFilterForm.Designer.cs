namespace ONES
{
	// Token: 0x0200001E RID: 30
	public partial class LayerFilterForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x0000FE30 File Offset: 0x0000E030
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000FE50 File Offset: 0x0000E050
		private void InitializeComponent()
		{
			this.buttonFilter = new global::System.Windows.Forms.Button();
			this.listViewLayers = new global::System.Windows.Forms.ListView();
			this.columnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.listViewValues = new global::System.Windows.Forms.ListView();
			this.columnHeader4 = new global::System.Windows.Forms.ColumnHeader();
			this.groupBoxElements = new global::System.Windows.Forms.GroupBox();
			this.RBAll = new global::System.Windows.Forms.RadioButton();
			this.RBAView = new global::System.Windows.Forms.RadioButton();
			this.buttonAll = new global::System.Windows.Forms.Button();
			this.buttonNone = new global::System.Windows.Forms.Button();
			this.buttonOverride = new global::System.Windows.Forms.Button();
			this.buttonSelect = new global::System.Windows.Forms.Button();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
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
			this.groupBoxColor = new global::System.Windows.Forms.GroupBox();
			this.RBPalette3 = new global::System.Windows.Forms.RadioButton();
			this.RBPaletteRandom = new global::System.Windows.Forms.RadioButton();
			this.buttonRefresh = new global::System.Windows.Forms.Button();
			this.RBPalette2 = new global::System.Windows.Forms.RadioButton();
			this.RBPalette1 = new global::System.Windows.Forms.RadioButton();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.groupBoxOverride = new global::System.Windows.Forms.GroupBox();
			this.groupBoxText = new global::System.Windows.Forms.GroupBox();
			this.RBTextWhite = new global::System.Windows.Forms.RadioButton();
			this.RBTextBlack = new global::System.Windows.Forms.RadioButton();
			this.RGBSame = new global::System.Windows.Forms.RadioButton();
			this.groupBoxElements.SuspendLayout();
			this.groupBoxGraphic.SuspendLayout();
			this.groupBoxTransparency.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarTransparency).BeginInit();
			this.groupBoxFilter.SuspendLayout();
			this.groupBoxColor.SuspendLayout();
			this.groupBoxOverride.SuspendLayout();
			this.groupBoxText.SuspendLayout();
			base.SuspendLayout();
			this.buttonFilter.Location = new global::System.Drawing.Point(6, 40);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new global::System.Drawing.Size(80, 25);
			this.buttonFilter.TabIndex = 4;
			this.buttonFilter.Text = "Filter";
			this.buttonFilter.UseVisualStyleBackColor = true;
			this.buttonFilter.Click += new global::System.EventHandler(this.buttonFilter_Click);
			this.listViewLayers.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader2
			});
			this.listViewLayers.HideSelection = false;
			this.listViewLayers.Location = new global::System.Drawing.Point(354, 54);
			this.listViewLayers.Name = "listViewLayers";
			this.listViewLayers.Size = new global::System.Drawing.Size(325, 559);
			this.listViewLayers.TabIndex = 9;
			this.listViewLayers.UseCompatibleStateImageBehavior = false;
			this.listViewLayers.View = global::System.Windows.Forms.View.Details;
			this.listViewLayers.SelectedIndexChanged += new global::System.EventHandler(this.listViewLayers_SelectedIndexChanged);
			this.columnHeader2.Text = "Layer";
			this.columnHeader2.Width = 295;
			this.listViewValues.CheckBoxes = true;
			this.listViewValues.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader4
			});
			this.listViewValues.HideSelection = false;
			this.listViewValues.Location = new global::System.Drawing.Point(695, 12);
			this.listViewValues.Name = "listViewValues";
			this.listViewValues.Size = new global::System.Drawing.Size(330, 487);
			this.listViewValues.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.listViewValues.TabIndex = 11;
			this.listViewValues.UseCompatibleStateImageBehavior = false;
			this.listViewValues.View = global::System.Windows.Forms.View.Details;
			this.listViewValues.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.listViewValues_ItemCheck);
			this.listViewValues.ItemChecked += new global::System.Windows.Forms.ItemCheckedEventHandler(this.listViewValues_ItemCheck);
			this.listViewValues.SelectedIndexChanged += new global::System.EventHandler(this.listViewValues_SelectedIndexChanged);
			this.columnHeader4.Text = "Type";
			this.columnHeader4.Width = 319;
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
			this.buttonAll.Location = new global::System.Drawing.Point(839, 505);
			this.buttonAll.Name = "buttonAll";
			this.buttonAll.Size = new global::System.Drawing.Size(90, 22);
			this.buttonAll.TabIndex = 13;
			this.buttonAll.Text = "Check All";
			this.buttonAll.UseVisualStyleBackColor = true;
			this.buttonAll.Click += new global::System.EventHandler(this.buttonAll_Click);
			this.buttonNone.Location = new global::System.Drawing.Point(935, 505);
			this.buttonNone.Name = "buttonNone";
			this.buttonNone.Size = new global::System.Drawing.Size(90, 22);
			this.buttonNone.TabIndex = 14;
			this.buttonNone.Text = "Uncheck All";
			this.buttonNone.UseVisualStyleBackColor = true;
			this.buttonNone.Click += new global::System.EventHandler(this.buttonNone_Click);
			this.buttonOverride.Location = new global::System.Drawing.Point(6, 39);
			this.buttonOverride.Name = "buttonOverride";
			this.buttonOverride.Size = new global::System.Drawing.Size(80, 25);
			this.buttonOverride.TabIndex = 15;
			this.buttonOverride.Text = "Override";
			this.buttonOverride.UseVisualStyleBackColor = true;
			this.buttonOverride.Click += new global::System.EventHandler(this.buttonOverride_Click);
			this.buttonSelect.Location = new global::System.Drawing.Point(1082, 588);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new global::System.Drawing.Size(80, 25);
			this.buttonSelect.TabIndex = 16;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new global::System.EventHandler(this.buttonShow_Click);
			this.columnHeader1.Text = "Category";
			this.columnHeader1.Width = 304;
			this.listViewCategory.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1
			});
			this.listViewCategory.HideSelection = false;
			this.listViewCategory.Location = new global::System.Drawing.Point(12, 92);
			this.listViewCategory.Name = "listViewCategory";
			this.listViewCategory.Size = new global::System.Drawing.Size(325, 521);
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
			this.checkBoxTemplate.Location = new global::System.Drawing.Point(6, 18);
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
			this.groupBoxGraphic.Location = new global::System.Drawing.Point(1037, 269);
			this.groupBoxGraphic.Name = "groupBoxGraphic";
			this.groupBoxGraphic.Size = new global::System.Drawing.Size(125, 230);
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
			this.groupBoxFilter.Controls.Add(this.checkBoxTemplate);
			this.groupBoxFilter.Controls.Add(this.buttonFilter);
			this.groupBoxFilter.Location = new global::System.Drawing.Point(695, 543);
			this.groupBoxFilter.Name = "groupBoxFilter";
			this.groupBoxFilter.Size = new global::System.Drawing.Size(112, 70);
			this.groupBoxFilter.TabIndex = 21;
			this.groupBoxFilter.TabStop = false;
			this.groupBoxFilter.Text = "Filter Settings";
			this.groupBoxColor.Controls.Add(this.RGBSame);
			this.groupBoxColor.Controls.Add(this.RBPalette3);
			this.groupBoxColor.Controls.Add(this.RBPaletteRandom);
			this.groupBoxColor.Controls.Add(this.buttonRefresh);
			this.groupBoxColor.Controls.Add(this.RBPalette2);
			this.groupBoxColor.Controls.Add(this.RBPalette1);
			this.groupBoxColor.Location = new global::System.Drawing.Point(1037, 12);
			this.groupBoxColor.Name = "groupBoxColor";
			this.groupBoxColor.Size = new global::System.Drawing.Size(125, 167);
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
			this.buttonRefresh.Location = new global::System.Drawing.Point(5, 128);
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
			this.buttonCancel.Location = new global::System.Drawing.Point(988, 589);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(80, 25);
			this.buttonCancel.TabIndex = 24;
			this.buttonCancel.Text = "Close";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.groupBoxOverride.Controls.Add(this.buttonOverride);
			this.groupBoxOverride.Location = new global::System.Drawing.Point(813, 543);
			this.groupBoxOverride.Name = "groupBoxOverride";
			this.groupBoxOverride.Size = new global::System.Drawing.Size(116, 70);
			this.groupBoxOverride.TabIndex = 26;
			this.groupBoxOverride.TabStop = false;
			this.groupBoxOverride.Text = "Override";
			this.groupBoxText.Controls.Add(this.RBTextWhite);
			this.groupBoxText.Controls.Add(this.RBTextBlack);
			this.groupBoxText.Location = new global::System.Drawing.Point(1037, 195);
			this.groupBoxText.Name = "groupBoxText";
			this.groupBoxText.Size = new global::System.Drawing.Size(125, 68);
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
			this.RGBSame.AutoSize = true;
			this.RGBSame.Location = new global::System.Drawing.Point(6, 106);
			this.RGBSame.Name = "RGBSame";
			this.RGBSame.Size = new global::System.Drawing.Size(82, 16);
			this.RGBSame.TabIndex = 27;
			this.RGBSame.TabStop = true;
			this.RGBSame.Text = "Same Color";
			this.RGBSame.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			base.ClientSize = new global::System.Drawing.Size(1171, 626);
			base.Controls.Add(this.groupBoxText);
			base.Controls.Add(this.groupBoxOverride);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.groupBoxColor);
			base.Controls.Add(this.groupBoxFilter);
			base.Controls.Add(this.groupBoxGraphic);
			base.Controls.Add(this.buttonSelect);
			base.Controls.Add(this.buttonNone);
			base.Controls.Add(this.buttonAll);
			base.Controls.Add(this.groupBoxElements);
			base.Controls.Add(this.listViewValues);
			base.Controls.Add(this.listViewLayers);
			base.Controls.Add(this.listViewCategory);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "LayerFilterForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Layer Filter";
			base.Load += new global::System.EventHandler(this.ColorElementsForm_Load);
			this.groupBoxElements.ResumeLayout(false);
			this.groupBoxElements.PerformLayout();
			this.groupBoxGraphic.ResumeLayout(false);
			this.groupBoxGraphic.PerformLayout();
			this.groupBoxTransparency.ResumeLayout(false);
			this.groupBoxTransparency.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarTransparency).EndInit();
			this.groupBoxFilter.ResumeLayout(false);
			this.groupBoxFilter.PerformLayout();
			this.groupBoxColor.ResumeLayout(false);
			this.groupBoxColor.PerformLayout();
			this.groupBoxOverride.ResumeLayout(false);
			this.groupBoxText.ResumeLayout(false);
			this.groupBoxText.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000089 RID: 137
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Button buttonFilter;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.ListView listViewLayers;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.ListView listViewValues;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.ColumnHeader columnHeader2;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.ColumnHeader columnHeader4;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.GroupBox groupBoxElements;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.RadioButton RBAView;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.RadioButton RBAll;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Button buttonAll;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Button buttonNone;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Button buttonOverride;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Button buttonSelect;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.ListView listViewCategory;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.CheckBox checkBoxHalftone;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.CheckBox checkBoxTemplate;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.GroupBox groupBoxGraphic;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.CheckBox checkBoxCut;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.CheckBox checkBoxNest;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.CheckBox checkBoxSurface;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.CheckBox checkBoxLine;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.GroupBox groupBoxFilter;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.GroupBox groupBoxColor;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.RadioButton RBPalette2;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.RadioButton RBPalette1;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.GroupBox groupBoxTransparency;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.TextBox textBoxTransparency;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.TrackBar trackBarTransparency;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Button buttonCancel;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Button buttonRefresh;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.RadioButton RBPaletteRandom;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.GroupBox groupBoxOverride;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.GroupBox groupBoxText;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.RadioButton RBTextWhite;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.RadioButton RBTextBlack;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.RadioButton RBPalette3;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.RadioButton RGBSame;
	}
}
