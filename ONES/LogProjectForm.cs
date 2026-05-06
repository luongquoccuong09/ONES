using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
	// Token: 0x0200007A RID: 122
	public partial class LogProjectForm : System.Windows.Forms.Form
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x00029E78 File Offset: 0x00028078
		public LogProjectForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00029F3C File Offset: 0x0002813C
		private void LogReportForm_Load(object sender, EventArgs e)
		{
			string username = this.doc.Application.Username;
			bool flag = this.adminUsers.Contains(username);
			if (flag)
			{
				this.radioButtonAdmin.Checked = true;
			}
			else
			{
				this.radioButtonAdmin.Enabled = false;
				this.radioButtonCurrent.Checked = true;
			}
			this.LogToListview();
		}

		// Token: 0x060002BA RID: 698 RVA: 0x000023A6 File Offset: 0x000005A6
		private void labelLogs_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00029F98 File Offset: 0x00028198
		private void buttonExport_Click(object sender, EventArgs e)
		{
			if ((Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046"))) == null)
			{
				TaskDialog.Show("Excel Error", "Failed to get or start Excel");
				return;
			}
			Worksheet worksheet = Utils.ExcelWorksheet("Project Logs");
			this.ExcelTitle(worksheet);
			int num = 2;
			string[] array = File.ReadAllLines(this.Logsfile);
			foreach (string row in array)
			{
				try
				{
					this.RowToExcel(worksheet, row, num);
					num++;
				}
				catch (Exception ex)
				{
					Debug.Print(ex.Message);
				}
			}
			Utils.ExcelTitleStyle(worksheet);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000023A6 File Offset: 0x000005A6
		private void labelTotal_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0002A048 File Offset: 0x00028248
		private void ExcelTitle(Worksheet worksheet)
		{
			int num = 1;
			worksheet.Cells[num, 1] = "Name";
			worksheet.Cells[num, 2] = "User";
			worksheet.Cells[num, 3] = "Date";
			worksheet.Cells[num, 4] = "Time Start";
			worksheet.Cells[num, 5] = "Time End";
			worksheet.Cells[num, 6] = "Time";
			worksheet.Cells[num, 7] = "Modify Time";
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0002A11C File Offset: 0x0002831C
		private void RowToExcel(Worksheet worksheet, string row, int i)
		{
			string[] array = row.Split(new char[]
			{
				';'
			});
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			string text4 = array[3];
			string text5 = array[4];
			string text6 = array[5];
			string text7 = array[6];
			worksheet.Cells[i, 1] = text;
			worksheet.Cells[i, 2] = text2;
			worksheet.Cells[i, 3] = text3;
			worksheet.Cells[i, 4] = text4;
			worksheet.Cells[i, 5] = text5;
			worksheet.Cells[i, 6] = text6;
			worksheet.Cells[i, 7] = text7;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0002A208 File Offset: 0x00028408
		private void LogToListview()
		{
			this.listViewLogs.Items.Clear();
			this.listViewTotal.Items.Clear();
			string[] array = File.ReadAllLines(this.Logsfile);
			string username = this.doc.Application.Username;
			foreach (string text in array)
			{
				try
				{
					string[] array3 = text.Split(new char[]
					{
						';'
					});
					string text2 = array3[0];
					string text3 = array3[1];
					string text4 = array3[2];
					string text5 = array3[3];
					string text6 = array3[4];
					string text7 = array3[5];
					string text8 = array3[6];
					bool flag = username == text3;
					bool @checked = this.radioButtonAdmin.Checked;
					if (!(!flag & !@checked))
					{
						string[] items = new string[]
						{
							text2,
							text3,
							text4,
							text5,
							text6,
							text7,
							text8
						};
						ListViewItem value = new ListViewItem(items);
						this.listViewLogs.Items.Add(value);
						TimeSpan timeSpan = TimeSpan.Parse(text7);
						if (this.dicTotalSpan.ContainsKey(text2))
						{
							this.dicTotalSpan[text2] = this.dicTotalSpan[text2] + timeSpan;
						}
						else
						{
							this.dicTotalSpan.Add(text2, timeSpan);
						}
						TimeSpan timeSpan2 = TimeSpan.Parse(text8);
						if (this.dicModifySpan.ContainsKey(text2))
						{
							this.dicModifySpan[text2] = this.dicModifySpan[text2] + timeSpan2;
						}
						else
						{
							this.dicModifySpan.Add(text2, timeSpan2);
						}
					}
				}
				catch (Exception ex)
				{
					Debug.Print(ex.Message);
				}
			}
			foreach (string text9 in this.dicTotalSpan.Keys)
			{
				try
				{
					string[] items2 = new string[]
					{
						text9,
						this.dicTotalSpan[text9].ToString(),
						this.dicModifySpan[text9].ToString()
					};
					ListViewItem value2 = new ListViewItem(items2);
					this.listViewTotal.Items.Add(value2);
				}
				catch (Exception ex2)
				{
					TaskDialog.Show("total", ex2.Message);
					Debug.Print(ex2.Message);
				}
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0002A4D4 File Offset: 0x000286D4
		private void radioButtonCurrent_CheckedChanged(object sender, EventArgs e)
		{
			this.LogToListview();
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040001EA RID: 490
		private UIDocument uidoc;

		// Token: 0x040001EB RID: 491
		private Document doc;

		// Token: 0x040001EC RID: 492
		private string Logsfile = Settings.Default.LogsFile;

		// Token: 0x040001ED RID: 493
		private Dictionary<string, string> dicDate = new Dictionary<string, string>();

		// Token: 0x040001EE RID: 494
		private Dictionary<string, string> dicTimeStart = new Dictionary<string, string>();

		// Token: 0x040001EF RID: 495
		private Dictionary<string, string> dicTimeEnd = new Dictionary<string, string>();

		// Token: 0x040001F0 RID: 496
		private Dictionary<string, string> dicSpan = new Dictionary<string, string>();

		// Token: 0x040001F1 RID: 497
		private Dictionary<string, TimeSpan> dicTotalSpan = new Dictionary<string, TimeSpan>();

		// Token: 0x040001F2 RID: 498
		private Dictionary<string, TimeSpan> dicModifySpan = new Dictionary<string, TimeSpan>();

		// Token: 0x040001F3 RID: 499
		private List<string> adminUsers = new List<string>
		{
			"esen.onur.au",
			"yoshifuji.naomi",
			"sato.toshiki.ro"
		};
	}
}

