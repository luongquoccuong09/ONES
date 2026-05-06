namespace ONES
{
	// Token: 0x0200001A RID: 26
	public partial class βProceduralTerrainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008A RID: 138 RVA: 0x0000D37D File Offset: 0x0000B57D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000D39C File Offset: 0x0000B59C
		private void InitializeComponent()
		{
			this.buttonTerrain = new global::System.Windows.Forms.Button();
			this.textBoxOctaves = new global::System.Windows.Forms.TextBox();
			this.textBoxAmplitude = new global::System.Windows.Forms.TextBox();
			this.textBoxSpeed = new global::System.Windows.Forms.TextBox();
			this.textBoxDensity = new global::System.Windows.Forms.TextBox();
			this.textBoxMinThickness = new global::System.Windows.Forms.TextBox();
			this.textBoxPredefined = new global::System.Windows.Forms.TextBox();
			this.labelOctaves = new global::System.Windows.Forms.Label();
			this.labelAmplitude = new global::System.Windows.Forms.Label();
			this.labelSpeed = new global::System.Windows.Forms.Label();
			this.labelDensity = new global::System.Windows.Forms.Label();
			this.labelMinThickness = new global::System.Windows.Forms.Label();
			this.labelPredefined = new global::System.Windows.Forms.Label();
			this.buttonCity = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.buttonTerrain.Location = new global::System.Drawing.Point(228, 68);
			this.buttonTerrain.Name = "buttonTerrain";
			this.buttonTerrain.Size = new global::System.Drawing.Size(60, 25);
			this.buttonTerrain.TabIndex = 0;
			this.buttonTerrain.Text = "Terrain";
			this.buttonTerrain.UseVisualStyleBackColor = true;
			this.buttonTerrain.Click += new global::System.EventHandler(this.buttonTerrain_Click);
			this.textBoxOctaves.Location = new global::System.Drawing.Point(101, 28);
			this.textBoxOctaves.Name = "textBoxOctaves";
			this.textBoxOctaves.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxOctaves.TabIndex = 1;
			this.textBoxAmplitude.Location = new global::System.Drawing.Point(101, 53);
			this.textBoxAmplitude.Name = "textBoxAmplitude";
			this.textBoxAmplitude.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxAmplitude.TabIndex = 1;
			this.textBoxSpeed.Location = new global::System.Drawing.Point(101, 78);
			this.textBoxSpeed.Name = "textBoxSpeed";
			this.textBoxSpeed.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxSpeed.TabIndex = 1;
			this.textBoxDensity.Location = new global::System.Drawing.Point(101, 103);
			this.textBoxDensity.Name = "textBoxDensity";
			this.textBoxDensity.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxDensity.TabIndex = 1;
			this.textBoxMinThickness.Location = new global::System.Drawing.Point(101, 128);
			this.textBoxMinThickness.Name = "textBoxMinThickness";
			this.textBoxMinThickness.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxMinThickness.TabIndex = 1;
			this.textBoxPredefined.Location = new global::System.Drawing.Point(101, 153);
			this.textBoxPredefined.Name = "textBoxPredefined";
			this.textBoxPredefined.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxPredefined.TabIndex = 1;
			this.labelOctaves.AutoSize = true;
			this.labelOctaves.Location = new global::System.Drawing.Point(12, 31);
			this.labelOctaves.Name = "labelOctaves";
			this.labelOctaves.Size = new global::System.Drawing.Size(47, 12);
			this.labelOctaves.TabIndex = 2;
			this.labelOctaves.Text = "Octaves";
			this.labelAmplitude.AutoSize = true;
			this.labelAmplitude.Location = new global::System.Drawing.Point(12, 56);
			this.labelAmplitude.Name = "labelAmplitude";
			this.labelAmplitude.Size = new global::System.Drawing.Size(56, 12);
			this.labelAmplitude.TabIndex = 2;
			this.labelAmplitude.Text = "Amplitude";
			this.labelSpeed.AutoSize = true;
			this.labelSpeed.Location = new global::System.Drawing.Point(12, 81);
			this.labelSpeed.Name = "labelSpeed";
			this.labelSpeed.Size = new global::System.Drawing.Size(36, 12);
			this.labelSpeed.TabIndex = 2;
			this.labelSpeed.Text = "Speed";
			this.labelDensity.AutoSize = true;
			this.labelDensity.Location = new global::System.Drawing.Point(12, 106);
			this.labelDensity.Name = "labelDensity";
			this.labelDensity.Size = new global::System.Drawing.Size(44, 12);
			this.labelDensity.TabIndex = 2;
			this.labelDensity.Text = "Density";
			this.labelMinThickness.AutoSize = true;
			this.labelMinThickness.Location = new global::System.Drawing.Point(12, 131);
			this.labelMinThickness.Name = "labelMinThickness";
			this.labelMinThickness.Size = new global::System.Drawing.Size(75, 12);
			this.labelMinThickness.TabIndex = 2;
			this.labelMinThickness.Text = "MinThickness";
			this.labelPredefined.AutoSize = true;
			this.labelPredefined.Location = new global::System.Drawing.Point(12, 156);
			this.labelPredefined.Name = "labelPredefined";
			this.labelPredefined.Size = new global::System.Drawing.Size(59, 12);
			this.labelPredefined.TabIndex = 2;
			this.labelPredefined.Text = "Predefined";
			this.buttonCity.Location = new global::System.Drawing.Point(228, 104);
			this.buttonCity.Name = "buttonCity";
			this.buttonCity.Size = new global::System.Drawing.Size(60, 25);
			this.buttonCity.TabIndex = 3;
			this.buttonCity.Text = "City";
			this.buttonCity.UseVisualStyleBackColor = true;
			this.buttonCity.Click += new global::System.EventHandler(this.buttonCity_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(313, 186);
			base.Controls.Add(this.buttonCity);
			base.Controls.Add(this.labelPredefined);
			base.Controls.Add(this.labelMinThickness);
			base.Controls.Add(this.labelDensity);
			base.Controls.Add(this.labelSpeed);
			base.Controls.Add(this.labelAmplitude);
			base.Controls.Add(this.labelOctaves);
			base.Controls.Add(this.textBoxPredefined);
			base.Controls.Add(this.textBoxMinThickness);
			base.Controls.Add(this.textBoxDensity);
			base.Controls.Add(this.textBoxSpeed);
			base.Controls.Add(this.textBoxAmplitude);
			base.Controls.Add(this.textBoxOctaves);
			base.Controls.Add(this.buttonTerrain);
			base.Name = "βProceduralTerrainForm";
			this.Text = "Form1";
			base.Load += new global::System.EventHandler(this.βProceduralTerrainForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000069 RID: 105
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.Button buttonTerrain;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.TextBox textBoxOctaves;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.TextBox textBoxAmplitude;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.TextBox textBoxSpeed;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.TextBox textBoxDensity;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.TextBox textBoxMinThickness;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.TextBox textBoxPredefined;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.Label labelOctaves;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.Label labelAmplitude;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.Label labelSpeed;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Label labelDensity;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Label labelMinThickness;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.Label labelPredefined;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Button buttonCity;
	}
}
