using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
	// Token: 0x0200002A RID: 42
	public partial class LogElementForm : System.Windows.Forms.Form
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x000151C3 File Offset: 0x000133C3
		public LogElementForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			base.MaximizeBox = false;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00015200 File Offset: 0x00013400
		private void LogElementForm_Load(object sender, EventArgs e)
		{
			string path = this.logsFolder + "logs_" + this.doc.Title + ".txt";
			string[] logData = File.ReadAllLines(path);
			string username = this.doc.Application.Username;
			List<string> adminUsers = new List<string>
			{
				"esen.onur.au"
			};
			TreeNode treeNode = this.LogToTreenode(logData, username, adminUsers);
			treeNode.Expand();
			this.treeViewLog.Nodes.Add(treeNode);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0001527C File Offset: 0x0001347C
		private TreeNode LogToTreenode(string[] logData, string currentUser, List<string> adminUsers)
		{
			List<LogElementForm.LogElement> source = this.LogElementListMake(logData);
			List<List<LogElementForm.LogElement>> list = (from x in source
			where x != null
			group x by x.Project into x
			orderby x.Key
			select x.ToList<LogElementForm.LogElement>()).ToList<List<LogElementForm.LogElement>>();
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "nodeAll";
			treeNode.Text = "All Logs";
			foreach (List<LogElementForm.LogElement> source2 in list)
			{
				List<List<LogElementForm.LogElement>> list2 = (from x in source2
				where x != null
				group x by x.Category into x
				orderby x.Key
				select x.ToList<LogElementForm.LogElement>()).ToList<List<LogElementForm.LogElement>>();
				TreeNode treeNode2 = new TreeNode();
				treeNode2.Name = "nodeProject";
				treeNode2.Text = source2.First<LogElementForm.LogElement>().Project;
				foreach (List<LogElementForm.LogElement> source3 in list2)
				{
					List<List<LogElementForm.LogElement>> list3 = (from x in source3
					where x != null
					group x by x.ElementId into x
					orderby x.Key
					select x.ToList<LogElementForm.LogElement>()).ToList<List<LogElementForm.LogElement>>();
					TreeNode treeNode3 = new TreeNode();
					treeNode3.Name = "nodeCategory";
					treeNode3.Text = source3.First<LogElementForm.LogElement>().Category;
					foreach (List<LogElementForm.LogElement> list4 in list3)
					{
						TreeNode treeNode4 = new TreeNode();
						treeNode4.Name = "nodeElement";
						treeNode4.Text = list4.First<LogElementForm.LogElement>().ElementId + ": " + list4.First<LogElementForm.LogElement>().ElementName;
						foreach (LogElementForm.LogElement log in list4)
						{
							string text = this.LogToRow(log);
							treeNode4.Nodes.Add(text);
						}
						treeNode3.Nodes.Add(treeNode4);
					}
					treeNode2.Nodes.Add(treeNode3);
				}
				treeNode.Nodes.Add(treeNode2);
			}
			return treeNode;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0001566C File Offset: 0x0001386C
		private void TreenodeAppend(List<List<LogElementForm.LogElement>> logsList, string text)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "node" + text;
			treeNode.Text = text;
			foreach (List<LogElementForm.LogElement> list in logsList)
			{
				TreeNode treeNode2 = new TreeNode();
				treeNode2.Name = "node" + text;
				treeNode2.Text = text;
				treeNode.Nodes.Add(treeNode2);
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000156FC File Offset: 0x000138FC
		private LogElementForm.LogElement LogElementMake(string row)
		{
			string[] array = row.Split(new char[]
			{
				';'
			});
			return new LogElementForm.LogElement
			{
				Project = array[0],
				Category = array[1],
				ElementId = array[2],
				ElementName = array[3],
				User = array[4],
				Change = array[5],
				Date = array[6],
				Time = array[7]
			};
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0001576C File Offset: 0x0001396C
		private List<LogElementForm.LogElement> LogElementListMake(string[] logData)
		{
			List<LogElementForm.LogElement> list = new List<LogElementForm.LogElement>();
			foreach (string row in logData)
			{
				try
				{
					LogElementForm.LogElement item = this.LogElementMake(row);
					list.Add(item);
				}
				catch (Exception ex)
				{
					Debug.Print(ex.Message);
				}
			}
			return list;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000157C8 File Offset: 0x000139C8
		private string LogToRow(LogElementForm.LogElement log)
		{
			List<string> values = new List<string>
			{
				log.User,
				log.Change,
				log.Date,
				log.Time
			};
			return string.Join(";", values);
		}

		// Token: 0x040000E4 RID: 228
		private UIDocument uidoc;

		// Token: 0x040000E5 RID: 229
		private Document doc;

		// Token: 0x040000E6 RID: 230
		private string logsFolder = Settings.Default.LogsFileFolder;

		// Token: 0x020000BE RID: 190
		public class LogElement
		{
			// Token: 0x1700005E RID: 94
			// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00038551 File Offset: 0x00036751
			// (set) Token: 0x060003F9 RID: 1017 RVA: 0x00038559 File Offset: 0x00036759
			public string Project { get; set; }

			// Token: 0x1700005F RID: 95
			// (get) Token: 0x060003FA RID: 1018 RVA: 0x00038562 File Offset: 0x00036762
			// (set) Token: 0x060003FB RID: 1019 RVA: 0x0003856A File Offset: 0x0003676A
			public string Category { get; set; }

			// Token: 0x17000060 RID: 96
			// (get) Token: 0x060003FC RID: 1020 RVA: 0x00038573 File Offset: 0x00036773
			// (set) Token: 0x060003FD RID: 1021 RVA: 0x0003857B File Offset: 0x0003677B
			public string ElementId { get; set; }

			// Token: 0x17000061 RID: 97
			// (get) Token: 0x060003FE RID: 1022 RVA: 0x00038584 File Offset: 0x00036784
			// (set) Token: 0x060003FF RID: 1023 RVA: 0x0003858C File Offset: 0x0003678C
			public string ElementName { get; set; }

			// Token: 0x17000062 RID: 98
			// (get) Token: 0x06000400 RID: 1024 RVA: 0x00038595 File Offset: 0x00036795
			// (set) Token: 0x06000401 RID: 1025 RVA: 0x0003859D File Offset: 0x0003679D
			public string User { get; set; }

			// Token: 0x17000063 RID: 99
			// (get) Token: 0x06000402 RID: 1026 RVA: 0x000385A6 File Offset: 0x000367A6
			// (set) Token: 0x06000403 RID: 1027 RVA: 0x000385AE File Offset: 0x000367AE
			public string Change { get; set; }

			// Token: 0x17000064 RID: 100
			// (get) Token: 0x06000404 RID: 1028 RVA: 0x000385B7 File Offset: 0x000367B7
			// (set) Token: 0x06000405 RID: 1029 RVA: 0x000385BF File Offset: 0x000367BF
			public string Date { get; set; }

			// Token: 0x17000065 RID: 101
			// (get) Token: 0x06000406 RID: 1030 RVA: 0x000385C8 File Offset: 0x000367C8
			// (set) Token: 0x06000407 RID: 1031 RVA: 0x000385D0 File Offset: 0x000367D0
			public string Time { get; set; }
		}
	}
}

