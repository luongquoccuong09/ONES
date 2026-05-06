using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
	// Token: 0x02000033 RID: 51
	public partial class ExportSchedules : System.Windows.Forms.Form
	{
		// Token: 0x0600010A RID: 266 RVA: 0x00015EDC File Offset: 0x000140DC
		public ExportSchedules(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = _uidoc.Document;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.JapaneseUI();
			}
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00015F4C File Offset: 0x0001414C
		private void ExportSchedules_Load(object sender, EventArgs e)
		{
			IList<Element> source = new FilteredElementCollector(this.doc).OfClass(typeof(ViewSchedule)).ToElements();
			IList<Element> list = (from x in source
			orderby x.Name
			select x).ToList<Element>();
			foreach (Element element in list)
			{
				ViewSchedule viewSchedule = (ViewSchedule)element;
				string[] items = new string[]
				{
					viewSchedule.Name
				};
				ListViewItem listViewItem = new ListViewItem(items);
				listViewItem.Tag = viewSchedule;
				this.listView1.Items.Add(listViewItem);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00016014 File Offset: 0x00014214
		private void JapaneseUI()
		{
			this.Text = "集計表のエクスポート";
			this.buttonCheck.Text = "全て選択";
			this.buttonUncheck.Text = "選択解除";
			this.buttonCancel.Text = "キャンセル";
			this.buttonExport.Text = "エクスポート";
			this.labelSchedules.Text = "集計表";
			this.columnHeaderScheduleName.Text = "集計表ビュー名";
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0001608C File Offset: 0x0001428C
		private void buttonExport_Click(object sender, EventArgs e)
		{
			Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			if (application == null)
			{
				RevitTaskDialog.Show("Excel Error", "Failed to get or start Excel");
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			List<Element> list = new List<Element>();
			application.Visible = true;
			Workbook workbook = application.Workbooks.Add(Missing.Value);
			bool flag = true;
			Worksheet worksheet;
			if (flag)
			{
				dynamic sheets = workbook.Sheets;
				worksheet = (Worksheet)sheets.Item[1];
			}
			else
			{
				worksheet = (application.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Worksheet);
			}
			worksheet.Name = "Sheet00";
			int num = 1;
			ListView.CheckedListViewItemCollection checkedItems = this.listView1.CheckedItems;
			foreach (object obj in checkedItems)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				ViewSchedule viewSchedule = listViewItem.Tag as ViewSchedule;
				TableData tableData = viewSchedule.GetTableData();
				TableSectionData sectionData = tableData.GetSectionData(SectionType.Body);
				int numberOfRows = sectionData.NumberOfRows;
				int numberOfColumns = sectionData.NumberOfColumns;
				if (numberOfRows > 1)
				{
					worksheet = (application.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Worksheet);
					string text = (31 < viewSchedule.Name.Length) ? viewSchedule.Name.Substring(0, 31) : viewSchedule.Name;
					text = text.Replace(':', '_').Replace('/', '_').Replace('?', '_').Replace('*', '_').Replace('[', '_').Replace(']', '_').Replace('\\', '_');
					text = num.ToString() + text;
					if (text != null)
					{
						try
						{
							worksheet.Name = text;
						}
						catch (Exception)
						{
							worksheet.Name = num.ToString();
						}
						try
						{
							for (int i = 0; i < numberOfRows; i++)
							{
								for (int j = 0; j < numberOfColumns; j++)
								{
									try
									{
										worksheet.Cells[i + 1, j + 1] = viewSchedule.GetCellText(SectionType.Body, i, j);
									}
									catch (Exception)
									{
										RevitTaskDialog.Show("Excel Interrupt Error", "Excel is interrupted either by a user or an app\nPlease wait until exporting is finished completely");
										base.DialogResult = DialogResult.Cancel;
										base.Close();
									}
								}
							}
						}
						catch (Exception)
						{
						}
						Utils.ExcelTitleStyle(worksheet);
					}
					num++;
				}
			}
			base.Close();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00016384 File Offset: 0x00014584
		private void buttonCheck_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = true;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000163C4 File Offset: 0x000145C4
		private void buttonUncheck_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = false;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040000EB RID: 235
		private Document doc;

		// Token: 0x040000EC RID: 236
		private UIDocument uidoc;
	}
}

