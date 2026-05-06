using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ONES.Properties;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
	// Token: 0x02000034 RID: 52
	public partial class SelectFilterForm2 : System.Windows.Forms.Form
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00016885 File Offset: 0x00014A85
		// (set) Token: 0x06000114 RID: 276 RVA: 0x0001688D File Offset: 0x00014A8D
		public List<ElementId> checkedIds1 { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00016896 File Offset: 0x00014A96
		// (set) Token: 0x06000116 RID: 278 RVA: 0x0001689E File Offset: 0x00014A9E
		public List<ElementId> checkedIds2 { get; set; }

		// Token: 0x06000117 RID: 279 RVA: 0x000168A8 File Offset: 0x00014AA8
		public SelectFilterForm2(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			this.view = this.uidoc.ActiveView;
			this.textCount = "Total Selection:";
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.JapaneseUI();
			}
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00016938 File Offset: 0x00014B38
		private void ClashDetectForm_Load(object sender, EventArgs e)
		{
			this.radioButtonCurrentView.Checked = true;
			this.radioButtonListType.Checked = true;
			this.RefreshTreeView();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00016958 File Offset: 0x00014B58
		private void JapaneseUI()
		{
			this.groupBoxSelection.Text = "選択オプション";
			this.radioButtonCurrentSel.Text = "現在の選択";
			this.radioButtonCurrentView.Text = "ビュー内の表示";
			this.radioButtonAllProject.Text = "プロジェクト全体";
			this.buttonSelect.Text = "選択";
			this.buttonDeselect.Text = "選択解除";
			this.textCount = "合計選択項目：";
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000169D0 File Offset: 0x00014BD0
		private void buttonSelect_Click(object sender, EventArgs e)
		{
			List<TreeNode> list = new List<TreeNode>();
			List<TreeNode> list2 = new List<TreeNode>();
			this.GetCheckedNodes(this.treeViewElements1.Nodes, list);
			this.GetCheckedNodes(this.treeViewElements2.Nodes, list2);
			this.checkedIds1 = new List<ElementId>();
			this.checkedIds2 = new List<ElementId>();
			foreach (TreeNode treeNode in list)
			{
				Element element = treeNode.Tag as Element;
				this.checkedIds1.Add(element.Id);
			}
			foreach (TreeNode treeNode2 in list2)
			{
				Element element2 = treeNode2.Tag as Element;
				this.checkedIds2.Add(element2.Id);
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00016AE4 File Offset: 0x00014CE4
		private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach (object obj in treeNode.Nodes)
			{
				TreeNode treeNode2 = (TreeNode)obj;
				treeNode2.Checked = nodeChecked;
				if (treeNode2.Nodes.Count > 0)
				{
					this.CheckAllChildNodes(treeNode2, nodeChecked);
				}
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00016B54 File Offset: 0x00014D54
		public void GetCheckedNodes(TreeNodeCollection nodes, List<TreeNode> treeNodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				Console.WriteLine(treeNode.Text);
				if (treeNode.Nodes.Count != 0)
				{
					this.GetCheckedNodes(treeNode.Nodes, treeNodes);
				}
				else if (treeNode.Checked)
				{
					treeNodes.Add(treeNode);
				}
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00016BD8 File Offset: 0x00014DD8
		private void RefreshTreeView()
		{
			this.treeViewElements1.Nodes.Clear();
			this.treeViewElements2.Nodes.Clear();
			List<Element> elementsForTreeView = this.GetElementsForTreeView();
			List<TreeNode> treeNodes = new List<TreeNode>();
			if (this.radioButtonListWorkset.Checked)
			{
				treeNodes = this.ElementsToTreeViewByWorkset(elementsForTreeView);
			}
			else if (this.radioButtonListUser.Checked)
			{
				treeNodes = this.ElementsToTreeViewByUser(elementsForTreeView);
			}
			else if (this.radioButtonListLevel.Checked)
			{
				treeNodes = this.ElementsToTreeViewByLevel(elementsForTreeView);
			}
			else
			{
				treeNodes = this.ElementsToTreeViewByType(elementsForTreeView);
			}
			this.ElementsToTreeView(treeNodes);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00016C68 File Offset: 0x00014E68
		private void ElementsToTreeView(List<TreeNode> treeNodes)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "nodeAll";
			treeNode.Text = "All Elements";
			foreach (TreeNode node in treeNodes)
			{
				treeNode.Nodes.Add(node);
			}
			treeNode.Expand();
			TreeNode treeNode2 = treeNode.Clone() as TreeNode;
			treeNode2.Expand();
			this.treeViewElements1.Nodes.Add(treeNode);
			this.treeViewElements2.Nodes.Add(treeNode2);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00016D14 File Offset: 0x00014F14
		private List<TreeNode> ElementsToTreeViewByType(List<Element> elements)
		{
			List<List<Element>> list = (from x in elements
			where x.Category != null
			group x by x.Category.Name into x
			orderby x.Key
			select x.ToList<Element>()).ToList<List<Element>>();
			List<TreeNode> list2 = new List<TreeNode>();
			foreach (List<Element> list3 in list)
			{
				try
				{
					TreeNode treeNode = new TreeNode();
					treeNode.Name = "nodeElementCategory";
					if (list3.First<Element>() is FamilyInstance)
					{
						List<List<FamilyInstance>> list4 = (from FamilyInstance x in list3
						group x by x.Symbol.FamilyName into x
						orderby x.Key
						select x.ToList<FamilyInstance>()).ToList<List<FamilyInstance>>();
						using (List<List<FamilyInstance>>.Enumerator enumerator2 = list4.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								List<FamilyInstance> source = enumerator2.Current;
								List<List<FamilyInstance>> list5 = (from x in source
								group x by x.Symbol.Name into x
								orderby x.Key
								select x.ToList<FamilyInstance>()).ToList<List<FamilyInstance>>();
								TreeNode treeNode2 = new TreeNode();
								treeNode2.Name = "nodeFamily";
								foreach (List<FamilyInstance> list6 in list5)
								{
									TreeNode treeNode3 = new TreeNode();
									treeNode3.Name = "nodeSymbol";
									treeNode3.Text = list6.First<FamilyInstance>().Name + ": " + list6.Count.ToString();
									foreach (FamilyInstance familyInstance in list6)
									{
										try
										{
											TreeNode treeNode4 = new TreeNode();
											treeNode4.Name = "nodeInstance";
											TreeNode treeNode5 = treeNode4;
											string name = familyInstance.Name;
											string str = " (";
											ElementId id = familyInstance.Id;
											treeNode5.Text = name + str + ((id != null) ? id.ToString() : null) + ")";
											treeNode4.Tag = familyInstance;
											treeNode3.Nodes.Add(treeNode4);
										}
										catch (Exception)
										{
										}
									}
									treeNode2.Nodes.Add(treeNode3);
								}
								treeNode2.Text = source.First<FamilyInstance>().Symbol.FamilyName + ": " + list4.Count.ToString();
								treeNode.Nodes.Add(treeNode2);
							}
							goto IL_4D7;
						}
					}
					List<List<Element>> list7 = (from x in list3
					where this.doc.GetElement(x.GetTypeId()) != null
					group x by this.doc.GetElement(x.GetTypeId()).Name into x
					orderby x.Key
					select x.ToList<Element>()).ToList<List<Element>>();
					foreach (List<Element> list8 in list7)
					{
						TreeNode treeNode6 = new TreeNode();
						treeNode6.Name = "nodeElementType";
						treeNode6.Text = list8.First<Element>().Name + ": " + list8.Count.ToString();
						foreach (Element element in list8)
						{
							TreeNode treeNode7 = new TreeNode();
							treeNode7.Name = "nodeElement";
							TreeNode treeNode8 = treeNode7;
							string name2 = element.Name;
							string str2 = " (";
							ElementId id2 = element.Id;
							treeNode8.Text = name2 + str2 + ((id2 != null) ? id2.ToString() : null) + ")";
							treeNode7.Tag = element;
							treeNode6.Nodes.Add(treeNode7);
						}
						treeNode.Nodes.Add(treeNode6);
					}
					IL_4D7:
					treeNode.Text = list3.First<Element>().Category.Name + ": " + list3.Count.ToString();
					list2.Add(treeNode);
				}
				catch (Exception)
				{
				}
			}
			return list2;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00017318 File Offset: 0x00015518
		private List<TreeNode> ElementsToTreeViewByWorkset(List<Element> elements)
		{
			List<List<Element>> list = (from x in elements
			where x.WorksetId != null
			group x by x.WorksetId into x
			select x.ToList<Element>()).ToList<List<Element>>();
			List<TreeNode> list2 = new List<TreeNode>();
			foreach (List<Element> list3 in list)
			{
				Workset workset = this.doc.GetWorksetTable().GetWorkset(list3.First<Element>().WorksetId);
				WorksetKind kind = workset.Kind;
				if (kind == WorksetKind.UserWorkset)
				{
					TreeNode treeNode = new TreeNode();
					List<TreeNode> list4 = this.ElementsToTreeViewByType(list3);
					foreach (TreeNode node in list4)
					{
						treeNode.Nodes.Add(node);
					}
					treeNode.Text = workset.Name + ": " + list3.Count.ToString();
					list2.Add(treeNode);
				}
			}
			return list2;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00017494 File Offset: 0x00015694
		private List<TreeNode> ElementsToTreeViewByUser(List<Element> elements)
		{
			List<List<Element>> list = (from x in elements
			group x by WorksharingUtils.GetWorksharingTooltipInfo(this.doc, x.Id).Creator into x
			select x.ToList<Element>()).ToList<List<Element>>();
			List<TreeNode> list2 = new List<TreeNode>();
			foreach (List<Element> list3 in list)
			{
				TreeNode treeNode = new TreeNode();
				List<TreeNode> list4 = this.ElementsToTreeViewByType(list3);
				foreach (TreeNode node in list4)
				{
					treeNode.Nodes.Add(node);
				}
				WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(this.doc, list3.First<Element>().Id);
				treeNode.Text = worksharingTooltipInfo.Creator + ": " + list3.Count.ToString();
				list2.Add(treeNode);
			}
			return list2;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000175C4 File Offset: 0x000157C4
		private List<TreeNode> ElementsToTreeViewByLevel(List<Element> elements)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc);
			IEnumerable<Level> enumerable = (from Level lvl in filteredElementCollector.OfClass(typeof(Level))
			orderby lvl.Elevation
			select lvl).ToList<Level>();
			List<List<Element>> list = new List<List<Element>>();
			List<TreeNode> list2 = new List<TreeNode>();
			foreach (Level level in enumerable)
			{
				TreeNode treeNode = new TreeNode();
				List<Element> list3 = new List<Element>();
				foreach (Element element in elements)
				{
					try
					{
						if (element.LevelId == null || element.LevelId.IntegerValue == -1)
						{
							Parameter parameter = element.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM);
							if (parameter != null)
							{
								if (parameter.AsElementId() == level.Id)
								{
									list3.Add(element);
								}
							}
						}
						else if (element.LevelId == level.Id)
						{
							list3.Add(element);
						}
					}
					catch (Exception ex)
					{
						RevitTaskDialog.Show("Exception", ex.Message);
					}
				}
				List<TreeNode> list4 = this.ElementsToTreeViewByType(list3);
				foreach (TreeNode node in list4)
				{
					treeNode.Nodes.Add(node);
				}
				treeNode.Text = level.Name + ": " + list3.Count.ToString();
				list2.Add(treeNode);
			}
			return list2;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000177FC File Offset: 0x000159FC
		private List<TreeNode> CategoryToTypes(List<Element> elementCategory)
		{
			List<List<Element>> list = (from x in elementCategory
			where this.doc.GetElement(x.GetTypeId()) != null
			group x by this.doc.GetElement(x.GetTypeId()).Name into x
			orderby x.Key
			select x.ToList<Element>()).ToList<List<Element>>();
			List<TreeNode> list2 = new List<TreeNode>();
			foreach (List<Element> list3 in list)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Name = "nodeElementType";
				treeNode.Text = list3.First<Element>().Name + ": " + list3.Count.ToString();
				foreach (Element element in list3)
				{
					TreeNode treeNode2 = new TreeNode();
					treeNode2.Name = "nodeElement";
					TreeNode treeNode3 = treeNode2;
					string name = element.Name;
					string str = " (";
					ElementId id = element.Id;
					treeNode3.Text = name + str + ((id != null) ? id.ToString() : null) + ")";
					treeNode2.Tag = element;
					treeNode.Nodes.Add(treeNode2);
				}
				list2.Add(treeNode);
			}
			return list2;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0001799C File Offset: 0x00015B9C
		private TreeNode ListToTreeNode(List<TreeNode> treeNodes)
		{
			TreeNode treeNode = new TreeNode();
			foreach (TreeNode node in treeNodes)
			{
				treeNode.Nodes.Add(node);
			}
			return treeNode;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000179F8 File Offset: 0x00015BF8
		private List<Element> GetElementsForTreeView()
		{
			Document document = this.uidoc.Document;
			View activeView = this.uidoc.ActiveView;
			List<Element> list = new List<Element>();
			if (this.radioButtonAllProject.Checked)
			{
				list = new FilteredElementCollector(document).WhereElementIsNotElementType().ToList<Element>();
			}
			else if (this.radioButtonCurrentView.Checked)
			{
				list = new FilteredElementCollector(document, activeView.Id).WhereElementIsNotElementType().ToList<Element>();
			}
			else if (this.radioButtonCurrentSel.Checked)
			{
				Selection selection = this.uidoc.Selection;
				ICollection<ElementId> elementIds = selection.GetElementIds();
				foreach (ElementId elementId in elementIds)
				{
					try
					{
						Element element = document.GetElement(elementId);
						list.Add(element);
					}
					catch (Exception)
					{
					}
				}
			}
			return list;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00017AEC File Offset: 0x00015CEC
		public void CheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00017B48 File Offset: 0x00015D48
		public void UncheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00017BA4 File Offset: 0x00015DA4
		private void CheckChildren(TreeNode rootNode, bool isChecked)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.CheckChildren(treeNode, isChecked);
				treeNode.Checked = isChecked;
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000023A6 File Offset: 0x000005A6
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00017C08 File Offset: 0x00015E08
		private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown && e.Node.Nodes.Count > 0)
			{
				this.CheckAllChildNodes(e.Node, e.Node.Checked);
			}
			List<TreeNode> list = new List<TreeNode>();
			this.GetCheckedNodes(this.treeViewElements1.Nodes, list);
			this.labelCount1.Text = this.textCount + list.Count.ToString();
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00017C84 File Offset: 0x00015E84
		private void treeViewElements2_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown && e.Node.Nodes.Count > 0)
			{
				this.CheckAllChildNodes(e.Node, e.Node.Checked);
			}
			List<TreeNode> list = new List<TreeNode>();
			this.GetCheckedNodes(this.treeViewElements1.Nodes, list);
			this.labelCount2.Text = this.textCount + list.Count.ToString();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00017CFF File Offset: 0x00015EFF
		private void buttonCheck_Click(object sender, EventArgs e)
		{
			this.CheckAllNodes(this.treeViewElements1.Nodes);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00017D12 File Offset: 0x00015F12
		private void buttonUncheck_Click(object sender, EventArgs e)
		{
			this.UncheckAllNodes(this.treeViewElements1.Nodes);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00017D25 File Offset: 0x00015F25
		private void buttonExpand_Click(object sender, EventArgs e)
		{
			this.treeViewElements1.ExpandAll();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00017D32 File Offset: 0x00015F32
		private void buttonCollapse_Click(object sender, EventArgs e)
		{
			this.treeViewElements1.CollapseAll();
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00017D3F File Offset: 0x00015F3F
		private void buttonDeselect_Click(object sender, EventArgs e)
		{
			this.uidoc.Selection.SetElementIds(new List<ElementId>());
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00017D56 File Offset: 0x00015F56
		private void buttonCheck2_Click(object sender, EventArgs e)
		{
			this.CheckAllNodes(this.treeViewElements2.Nodes);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00017D69 File Offset: 0x00015F69
		private void buttonUncheck2_Click(object sender, EventArgs e)
		{
			this.UncheckAllNodes(this.treeViewElements2.Nodes);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00017D7C File Offset: 0x00015F7C
		private void buttonExpand2_Click(object sender, EventArgs e)
		{
			this.treeViewElements2.ExpandAll();
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00017D89 File Offset: 0x00015F89
		private void buttonCollapse2_Click(object sender, EventArgs e)
		{
			this.treeViewElements2.CollapseAll();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00017D96 File Offset: 0x00015F96
		private void radioButtonFamilyType_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshTreeView();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00017D96 File Offset: 0x00015F96
		private void radioButtonWorkset_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshTreeView();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00017D96 File Offset: 0x00015F96
		private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshTreeView();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00017D96 File Offset: 0x00015F96
		private void radioButtonListLevel_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshTreeView();
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000023A6 File Offset: 0x000005A6
		private void groupBoxSelection_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00017D96 File Offset: 0x00015F96
		private void radioButtonCurrentSel_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshTreeView();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00017D96 File Offset: 0x00015F96
		private void radioButtonCurrentView_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshTreeView();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00017D96 File Offset: 0x00015F96
		private void radioButtonAllProject_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshTreeView();
		}

		// Token: 0x040000F5 RID: 245
		private UIDocument uidoc;

		// Token: 0x040000F6 RID: 246
		private string textCount;

		// Token: 0x040000F7 RID: 247
		private Document doc;

		// Token: 0x040000F8 RID: 248
		private View view;
	}
}



