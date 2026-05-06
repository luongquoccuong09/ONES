using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ONES.Properties;

namespace ONES
{
	// Token: 0x0200000F RID: 15
	public partial class HealthCheckFormOld : System.Windows.Forms.Form
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00006ED0 File Offset: 0x000050D0
		public HealthCheckFormOld(UIApplication _uiapp)
		{
			this.InitializeComponent();
			this.uiapp = _uiapp;
			this.uidoc = this.uiapp.ActiveUIDocument;
			this.doc = this.uidoc.Document;
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.labelCategory.Text = "カテゴリー";
				this.labelReport.Text = "報告";
				this.labelDevelopment.Text = "作業中";
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00006FC4 File Offset: 0x000051C4
		private void HealthCheckForm_Load(object sender, EventArgs e)
		{
			TreeNode treeNode = new TreeNode
			{
				Name = "nodeWarnings",
				Text = "Warnings"
			};
			TreeNode treeNode2 = new TreeNode
			{
				Name = "nodeFilters",
				Text = "Filters"
			};
			TreeNode treeNode3 = new TreeNode
			{
				Name = "nodeImports",
				Text = "Imports"
			};
			TreeNode treeNode4 = new TreeNode
			{
				Name = "nodeLink",
				Text = "Link"
			};
			TreeNode treeNode5 = new TreeNode
			{
				Name = "nodePerformance",
				Text = "Performance"
			};
			this.listBoxCategories.Items.Add("Warnings: " + this.countWarnings.ToString());
			this.listBoxCategories.Items.Add("In-Place: " + this.countInplace.ToString());
			this.listBoxCategories.Items.Add("Unused View Filters: " + this.countUnusedFilters.ToString());
			this.listBoxCategories.Items.Add("Performance Advisor Failings: " + this.countperformanceMessages.ToString());
			this.listBoxCategories.Items.Add("Import Instances (dwg etc.): " + this.countImportedInstances.ToString());
			this.listBoxCategories.Items.Add("Link Instances : " + this.countLinkInstances.ToString());
			int selectedIndex = this.listBoxCategories.SelectedIndex;
			if (selectedIndex == 0)
			{
				using (IEnumerator<FailureMessage> enumerator = this.warnings.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						FailureMessage failureMessage = enumerator.Current;
						try
						{
							string text = "";
							try
							{
								foreach (ElementId elementId in failureMessage.GetFailingElements())
								{
									text = text + elementId.ToString() + ", ";
								}
							}
							catch (Exception)
							{
							}
							string[] items = new string[]
							{
								failureMessage.GetDescriptionText(),
								text
							};
							ListViewItem listViewItem = new ListViewItem(items);
							listViewItem.Tag = failureMessage;
							this.listViewResults.Items.Add(listViewItem);
						}
						catch (Exception)
						{
						}
					}
					goto IL_581;
				}
			}
			int num = selectedIndex;
			if (num == 1)
			{
				using (List<Family>.Enumerator enumerator3 = this.InPlaces.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						Family family = enumerator3.Current;
						try
						{
							string[] items2 = new string[]
							{
								family.Name,
								family.Id.ToString(),
								family.Category.Name
							};
							ListViewItem listViewItem2 = new ListViewItem(items2);
							listViewItem2.Tag = family;
							this.listViewResults.Items.Add(listViewItem2);
						}
						catch (Exception)
						{
						}
					}
					goto IL_581;
				}
			}
			int num2 = selectedIndex;
			if (num2 == 2)
			{
				using (List<Element>.Enumerator enumerator4 = this.unusedFilters.GetEnumerator())
				{
					while (enumerator4.MoveNext())
					{
						Element element = enumerator4.Current;
						try
						{
							string[] items3 = new string[]
							{
								element.Name,
								element.Id.ToString()
							};
							ListViewItem listViewItem3 = new ListViewItem(items3);
							listViewItem3.Tag = element;
							this.listViewResults.Items.Add(listViewItem3);
						}
						catch (Exception)
						{
						}
					}
					goto IL_581;
				}
			}
			int num3 = selectedIndex;
			if (num3 == 3)
			{
				using (IEnumerator<PerformanceAdviserRuleId> enumerator5 = this.ruleIds.GetEnumerator())
				{
					while (enumerator5.MoveNext())
					{
						PerformanceAdviserRuleId performanceAdviserRuleId = enumerator5.Current;
						try
						{
							string ruleName = this.adviser.GetRuleName(performanceAdviserRuleId);
							IList<PerformanceAdviserRuleId> list = new List<PerformanceAdviserRuleId>
							{
								performanceAdviserRuleId
							};
							this.performanceMessages = this.adviser.ExecuteRules(this.doc, list);
							string[] items4 = new string[]
							{
								ruleName,
								this.performanceMessages.Count.ToString()
							};
							ListViewItem listViewItem4 = new ListViewItem(items4);
							listViewItem4.Tag = performanceAdviserRuleId;
							this.listViewResults.Items.Add(listViewItem4);
						}
						catch (Exception)
						{
						}
					}
					goto IL_581;
				}
			}
			int num4 = selectedIndex;
			if (num4 == 4)
			{
				using (List<ImportInstance>.Enumerator enumerator6 = this.importInstances.GetEnumerator())
				{
					while (enumerator6.MoveNext())
					{
						ImportInstance importInstance = enumerator6.Current;
						try
						{
							string[] items5 = new string[]
							{
								importInstance.Name,
								importInstance.Id.ToString(),
								this.doc.GetElement(importInstance.OwnerViewId).Name
							};
							ListViewItem listViewItem5 = new ListViewItem(items5);
							listViewItem5.Tag = importInstance;
							this.listViewResults.Items.Add(listViewItem5);
						}
						catch (Exception)
						{
						}
					}
					goto IL_581;
				}
			}
			int num5 = selectedIndex;
			if (num5 == 5)
			{
				foreach (ImportInstance importInstance2 in this.LinkInstances)
				{
					try
					{
						string[] items6 = new string[]
						{
							importInstance2.Name,
							importInstance2.Id.ToString(),
							this.doc.GetElement(importInstance2.OwnerViewId).Name
						};
						ListViewItem listViewItem6 = new ListViewItem(items6);
						listViewItem6.Tag = importInstance2;
						this.listViewResults.Items.Add(listViewItem6);
					}
					catch (Exception)
					{
					}
				}
			}
			IL_581:
			foreach (FailureMessage failureMessage2 in this.warnings)
			{
				foreach (ElementId elementId2 in failureMessage2.GetFailingElements())
				{
					try
					{
						treeNode.Nodes.Add(elementId2.ToString());
					}
					catch (Exception)
					{
					}
				}
			}
			foreach (Family family2 in this.InPlaces)
			{
				try
				{
					treeNode3.Nodes.Add(family2.Name);
				}
				catch (Exception)
				{
				}
			}
			foreach (Element element2 in this.unusedFilters)
			{
				try
				{
					treeNode2.Nodes.Add(element2.Name);
				}
				catch (Exception)
				{
				}
			}
			foreach (ImportInstance importInstance3 in this.LinkInstances)
			{
				try
				{
					treeNode4.Nodes.Add(importInstance3.Name);
				}
				catch (Exception)
				{
				}
			}
			foreach (PerformanceAdviserRuleId performanceAdviserRuleId2 in this.ruleIds)
			{
				try
				{
					string ruleName2 = this.adviser.GetRuleName(performanceAdviserRuleId2);
					IList<PerformanceAdviserRuleId> list2 = new List<PerformanceAdviserRuleId>
					{
						performanceAdviserRuleId2
					};
					this.performanceMessages = this.adviser.ExecuteRules(this.doc, list2);
					TreeNode treeNode6 = new TreeNode();
					treeNode.Name = ruleName2;
					treeNode.Text = ruleName2;
					HashSet<string> hashSet = new HashSet<string>();
					foreach (FailureMessage failureMessage3 in this.performanceMessages)
					{
						foreach (ElementId elementId3 in failureMessage3.GetFailingElements())
						{
							hashSet.Add(elementId3.ToString());
						}
					}
					foreach (string text2 in hashSet)
					{
						treeNode6.Nodes.Add(text2);
					}
					treeNode5.Nodes.Add(treeNode6);
				}
				catch (Exception)
				{
				}
			}
			this.treeView1.Nodes.Add(treeNode);
			this.treeView1.Nodes.Add(treeNode2);
			this.treeView1.Nodes.Add(treeNode3);
			this.treeView1.Nodes.Add(treeNode4);
			this.treeView1.Nodes.Add(treeNode5);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00007AEC File Offset: 0x00005CEC
		private void UpdateEmoji(PictureBox pictureBox, int score)
		{
			if (score <= 10)
			{
				pictureBox.Image = Resources._10_96;
				return;
			}
			if (score <= 20)
			{
				pictureBox.Image = Resources._20_96;
				return;
			}
			if (score <= 30)
			{
				pictureBox.Image = Resources._30_96;
				return;
			}
			if (score <= 40)
			{
				pictureBox.Image = Resources._40_96;
				return;
			}
			if (score <= 50)
			{
				pictureBox.Image = Resources._50_96;
				return;
			}
			if (score <= 60)
			{
				pictureBox.Image = Resources._60_96;
				return;
			}
			if (score <= 70)
			{
				pictureBox.Image = Resources._70_96;
				return;
			}
			if (score <= 80)
			{
				pictureBox.Image = Resources._80_96;
				return;
			}
			if (score <= 90)
			{
				pictureBox.Image = Resources._90_96;
				return;
			}
			if (score > 90)
			{
				pictureBox.Image = Resources._100_96;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00007BA4 File Offset: 0x00005DA4
		private int Warnings(double factor = 0.2)
		{
			int count = this.doc.GetWarnings().Count;
			int num = Convert.ToInt32((double)count * factor);
			this.labelCountWarnings.Text = count.ToString();
			this.UpdateEmoji(this.pictureBoxWarnings, num);
			return num;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00007BEC File Offset: 0x00005DEC
		private int InPlace(double factor = 0.2)
		{
			List<Family> list = (from Family x in new FilteredElementCollector(this.doc).OfClass(typeof(Family))
			where x.IsInPlace
			select x).ToList<Family>();
			int count = list.Count;
			int result = Convert.ToInt32((double)count * factor);
			this.labelCountInPlace.Text = count.ToString();
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00007C68 File Offset: 0x00005E68
		private int CADImport(double factor = 0.2)
		{
			List<ImportInstance> list = (from ImportInstance i in new FilteredElementCollector(this.doc).OfClass(typeof(ImportInstance))
			where !i.IsLinked
			select i).ToList<ImportInstance>();
			list.RemoveAll((ImportInstance item) => item == null);
			int count = list.Count;
			int result = Convert.ToInt32((double)count * factor);
			this.labelCountCAD.Text = count.ToString();
			return result;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00007D08 File Offset: 0x00005F08
		private int FileSize(double factor = 0.2)
		{
			string fileName = Utils.LocalFilePath(this.uiapp);
			long length = new FileInfo(fileName).Length;
			int result = Convert.ToInt32(length / 1024L);
			this.labelCountFileSize.Text = result.ToString() + " KB";
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00007D58 File Offset: 0x00005F58
		private int TotalViews(double factor = 0.2)
		{
			int count = this.doc.GetWarnings().Count;
			int num = Convert.ToInt32((double)count * factor);
			this.labelCountWarnings.Text = count.ToString();
			this.UpdateEmoji(this.pictureBoxWarnings, num);
			return num;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00007DA0 File Offset: 0x00005FA0
		private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.listViewResults.Items.Clear();
			}
			catch (Exception)
			{
			}
			int selectedIndex = this.listBoxCategories.SelectedIndex;
			if (selectedIndex == 0)
			{
				using (IEnumerator<FailureMessage> enumerator = this.warnings.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						FailureMessage failureMessage = enumerator.Current;
						try
						{
							string text = "";
							try
							{
								foreach (ElementId elementId in failureMessage.GetFailingElements())
								{
									text = text + elementId.ToString() + ", ";
								}
							}
							catch (Exception)
							{
							}
							string[] items = new string[]
							{
								failureMessage.GetDescriptionText(),
								text
							};
							ListViewItem listViewItem = new ListViewItem(items);
							listViewItem.Tag = failureMessage;
							this.listViewResults.Items.Add(listViewItem);
						}
						catch (Exception)
						{
						}
					}
					return;
				}
			}
			int num = selectedIndex;
			if (num == 1)
			{
				using (List<Family>.Enumerator enumerator3 = this.InPlaces.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						Family family = enumerator3.Current;
						try
						{
							string[] items2 = new string[]
							{
								family.Name,
								family.Id.ToString(),
								family.Category.Name
							};
							ListViewItem listViewItem2 = new ListViewItem(items2);
							listViewItem2.Tag = family;
							this.listViewResults.Items.Add(listViewItem2);
						}
						catch (Exception)
						{
						}
					}
					return;
				}
			}
			int num2 = selectedIndex;
			if (num2 == 2)
			{
				using (List<Element>.Enumerator enumerator4 = this.unusedFilters.GetEnumerator())
				{
					while (enumerator4.MoveNext())
					{
						Element element = enumerator4.Current;
						try
						{
							string[] items3 = new string[]
							{
								element.Name,
								element.Id.ToString()
							};
							ListViewItem listViewItem3 = new ListViewItem(items3);
							listViewItem3.Tag = element;
							this.listViewResults.Items.Add(listViewItem3);
						}
						catch (Exception)
						{
						}
					}
					return;
				}
			}
			int num3 = selectedIndex;
			if (num3 == 3)
			{
				using (IEnumerator<PerformanceAdviserRuleId> enumerator5 = this.ruleIds.GetEnumerator())
				{
					while (enumerator5.MoveNext())
					{
						PerformanceAdviserRuleId performanceAdviserRuleId = enumerator5.Current;
						try
						{
							string ruleName = this.adviser.GetRuleName(performanceAdviserRuleId);
							IList<PerformanceAdviserRuleId> list = new List<PerformanceAdviserRuleId>
							{
								performanceAdviserRuleId
							};
							this.performanceMessages = this.adviser.ExecuteRules(this.doc, list);
							string[] items4 = new string[]
							{
								ruleName,
								this.performanceMessages.Count.ToString()
							};
							ListViewItem listViewItem4 = new ListViewItem(items4);
							listViewItem4.Tag = performanceAdviserRuleId;
							this.listViewResults.Items.Add(listViewItem4);
						}
						catch (Exception)
						{
						}
					}
					return;
				}
			}
			int num4 = selectedIndex;
			if (num4 == 4)
			{
				using (List<ImportInstance>.Enumerator enumerator6 = this.importInstances.GetEnumerator())
				{
					while (enumerator6.MoveNext())
					{
						ImportInstance importInstance = enumerator6.Current;
						try
						{
							string[] items5 = new string[]
							{
								importInstance.Name,
								importInstance.Id.ToString(),
								this.doc.GetElement(importInstance.OwnerViewId).Name
							};
							ListViewItem listViewItem5 = new ListViewItem(items5);
							listViewItem5.Tag = importInstance;
							this.listViewResults.Items.Add(listViewItem5);
						}
						catch (Exception)
						{
						}
					}
					return;
				}
			}
			int num5 = selectedIndex;
			if (num5 == 5)
			{
				foreach (ImportInstance importInstance2 in this.LinkInstances)
				{
					try
					{
						string[] items6 = new string[]
						{
							importInstance2.Name,
							importInstance2.Id.ToString(),
							this.doc.GetElement(importInstance2.OwnerViewId).Name
						};
						ListViewItem listViewItem6 = new ListViewItem(items6);
						listViewItem6.Tag = importInstance2;
						this.listViewResults.Items.Add(listViewItem6);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000023A6 File Offset: 0x000005A6
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000023A6 File Offset: 0x000005A6
		private void labelResult_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000023A6 File Offset: 0x000005A6
		private void listViewResults_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000023A6 File Offset: 0x000005A6
		private void buttonShow_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0400000C RID: 12
		private UIApplication uiapp;

		// Token: 0x0400000D RID: 13
		private UIDocument uidoc;

		// Token: 0x0400000E RID: 14
		private Document doc;

		// Token: 0x0400000F RID: 15
		private List<Family> InPlaces = new List<Family>();

		// Token: 0x04000010 RID: 16
		private IList<FailureMessage> warnings;

		// Token: 0x04000011 RID: 17
		private IList<FailureMessage> performanceMessages;

		// Token: 0x04000012 RID: 18
		private ICollection<ElementId> allFilterIds;

		// Token: 0x04000013 RID: 19
		private List<Element> unusedFilters = new List<Element>();

		// Token: 0x04000014 RID: 20
		private List<string> performanceNames = new List<string>();

		// Token: 0x04000015 RID: 21
		private List<ElementId> performanceIds = new List<ElementId>();

		// Token: 0x04000016 RID: 22
		private List<ImportInstance> importInstances = new List<ImportInstance>();

		// Token: 0x04000017 RID: 23
		private List<ImportInstance> LinkInstances = new List<ImportInstance>();

		// Token: 0x04000018 RID: 24
		private List<ElementId> LinkInstancesIds = new List<ElementId>();

		// Token: 0x04000019 RID: 25
		private List<List<string>> listAll = new List<List<string>>();

		// Token: 0x0400001A RID: 26
		private PerformanceAdviser adviser;

		// Token: 0x0400001B RID: 27
		private IList<PerformanceAdviserRuleId> ruleIds;

		// Token: 0x0400001C RID: 28
		private int countWarnings;

		// Token: 0x0400001D RID: 29
		private int countInplace;

		// Token: 0x0400001E RID: 30
		private int countperformanceMessages;

		// Token: 0x0400001F RID: 31
		private int countUnusedFilters;

		// Token: 0x04000020 RID: 32
		private int countImportedInstances;

		// Token: 0x04000021 RID: 33
		private int countLinkInstances;
	}
}

