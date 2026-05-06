namespace ONES
{
	// Token: 0x0200007E RID: 126
	public partial class PurgeForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060002D5 RID: 725 RVA: 0x0002BCC0 File Offset: 0x00029EC0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0002BCE0 File Offset: 0x00029EE0
		private void InitializeComponent()
		{
			this.buttonPurge = new global::System.Windows.Forms.Button();
			this.buttonSA = new global::System.Windows.Forms.Button();
			this.buttonSN = new global::System.Windows.Forms.Button();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.category = new global::System.Windows.Forms.ColumnHeader();
			this.name = new global::System.Windows.Forms.ColumnHeader();
			this.Id = new global::System.Windows.Forms.ColumnHeader();
			this.ownedViewId = new global::System.Windows.Forms.ColumnHeader();
			this.viewName = new global::System.Windows.Forms.ColumnHeader();
			this.buttonShow = new global::System.Windows.Forms.Button();
			this.labelCount = new global::System.Windows.Forms.Label();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.buttonPurge.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.buttonPurge.Location = new global::System.Drawing.Point(635, 397);
			this.buttonPurge.Name = "buttonPurge";
			this.buttonPurge.Size = new global::System.Drawing.Size(75, 33);
			this.buttonPurge.TabIndex = 1;
			this.buttonPurge.Text = "PURGE";
			this.buttonPurge.UseVisualStyleBackColor = false;
			this.buttonPurge.Click += new global::System.EventHandler(this.buttonPurge_Click);
			this.buttonSA.Location = new global::System.Drawing.Point(102, 400);
			this.buttonSA.Name = "buttonSA";
			this.buttonSA.Size = new global::System.Drawing.Size(84, 33);
			this.buttonSA.TabIndex = 2;
			this.buttonSA.Text = "Select All";
			this.buttonSA.UseVisualStyleBackColor = true;
			this.buttonSA.Click += new global::System.EventHandler(this.buttonSA_Click);
			this.buttonSN.Location = new global::System.Drawing.Point(12, 400);
			this.buttonSN.Name = "buttonSN";
			this.buttonSN.Size = new global::System.Drawing.Size(84, 33);
			this.buttonSN.TabIndex = 3;
			this.buttonSN.Text = "Select None";
			this.buttonSN.UseVisualStyleBackColor = true;
			this.buttonSN.Click += new global::System.EventHandler(this.buttonSN_Click);
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.category,
				this.name,
				this.Id,
				this.ownedViewId,
				this.viewName
			});
			this.listView1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new global::System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(722, 382);
			this.listView1.TabIndex = 4;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.category.Text = "Category";
			this.category.Width = 141;
			this.name.Text = "Name";
			this.name.Width = 195;
			this.Id.Text = "ID";
			this.Id.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.Id.Width = 90;
			this.ownedViewId.Text = "View ID";
			this.ownedViewId.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.ownedViewId.Width = 89;
			this.viewName.Text = "View Name";
			this.viewName.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.viewName.Width = 160;
			this.buttonShow.Location = new global::System.Drawing.Point(192, 400);
			this.buttonShow.Name = "buttonShow";
			this.buttonShow.Size = new global::System.Drawing.Size(84, 33);
			this.buttonShow.TabIndex = 5;
			this.buttonShow.Text = "Show";
			this.buttonShow.UseVisualStyleBackColor = true;
			this.buttonShow.Click += new global::System.EventHandler(this.buttonShow_Click);
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new global::System.Drawing.Point(430, 407);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new global::System.Drawing.Size(37, 12);
			this.labelCount.TabIndex = 6;
			this.labelCount.Text = "Count:";
			this.buttonCancel.Location = new global::System.Drawing.Point(554, 397);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(722, 442);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.labelCount);
			base.Controls.Add(this.buttonShow);
			base.Controls.Add(this.listView1);
			base.Controls.Add(this.buttonSN);
			base.Controls.Add(this.buttonSA);
			base.Controls.Add(this.buttonPurge);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "PurgeForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Purge";
			base.Load += new global::System.EventHandler(this._PurgeForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400020B RID: 523
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.Button buttonPurge;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.Button buttonSA;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.Button buttonSN;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.ColumnHeader name;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.ColumnHeader Id;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.ColumnHeader ownedViewId;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.ColumnHeader viewName;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.ColumnHeader category;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.Button buttonShow;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.Label labelCount;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.Button buttonCancel;
	}
}
