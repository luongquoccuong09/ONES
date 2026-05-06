using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;
using ONES.Properties;

namespace ONES
{
	// Token: 0x02000039 RID: 57
	public partial class TypeFilterForm : System.Windows.Forms.Form
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000170 RID: 368 RVA: 0x0001AE7A File Offset: 0x0001907A
		// (set) Token: 0x06000171 RID: 369 RVA: 0x0001AE82 File Offset: 0x00019082
		public List<ElementId> checkedIds { get; set; }

		// Token: 0x06000172 RID: 370 RVA: 0x0001AE8C File Offset: 0x0001908C
		public TypeFilterForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			this.view = this.uidoc.ActiveView;
			this.textCount = "Total Selection:";
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.buttonSelect.Text = "選択";
				this.buttonDeselect.Text = "選択解除";
				this.textCount = "合計選択項目：";
				this.labelDevelopment.Text = "作業中";
			}
			this.rButtonListType.Checked = true;
			base.MaximizeBox = false;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0001AF54 File Offset: 0x00019154
		private void TypeFilterForm_Load(object sender, EventArgs e)
		{
			this.RefreshTreeView(this.GetElementsForTreeView());
			this.formLoad = true;
			this.comboBoxSearch.Items.Add("Contains");
			this.comboBoxSearch.Items.Add("Equals");
			this.comboBoxSearch.Items.Add("Starts with");
			this.comboBoxSearch.Items.Add("Ends with");
			this.comboBoxSearch.SelectedIndex = 0;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0001AFD8 File Offset: 0x000191D8
		private void buttonSelect_Click(object sender, EventArgs e)
		{
			List<TreeNode> list = new List<TreeNode>();
			this.GetCheckedNodes(this.treeViewElements.Nodes, list);
			this.checkedIds = new List<ElementId>();
			foreach (TreeNode treeNode in list)
			{
				Element element = treeNode.Tag as Element;
				this.checkedIds.Add(element.Id);
			}
			this.uidoc.Selection.SetElementIds(this.checkedIds);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0001B084 File Offset: 0x00019284
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

		// Token: 0x06000176 RID: 374 RVA: 0x0001B0F4 File Offset: 0x000192F4
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

		// Token: 0x06000177 RID: 375 RVA: 0x0001B178 File Offset: 0x00019378
		private void RefreshTreeView(List<Element> elements)
		{
			this.treeViewElements.Nodes.Clear();
			List<TreeNode> treeNodes = new List<TreeNode>();
			if (this.rButtonListCreated.Checked)
			{
				treeNodes = this.ElementsToTreeViewByCreated(elements);
			}
			else if (this.rButtonListChanged.Checked)
			{
				treeNodes = this.ElementsToTreeViewByChanged(elements);
			}
			else
			{
				treeNodes = this.ElementsToTreeViewByType(elements);
			}
			this.ElementsToTreeView(treeNodes);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0001B1D8 File Offset: 0x000193D8
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
			this.treeViewElements.Nodes.Add(treeNode);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0001B260 File Offset: 0x00019460
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
					if (list3.First<Element>() is FamilySymbol)
					{
						List<List<FamilySymbol>> list4 = (from FamilySymbol x in list3
						group x by x.FamilyName into x
						orderby x.Key
						select x.ToList<FamilySymbol>()).ToList<List<FamilySymbol>>();
						using (List<List<FamilySymbol>>.Enumerator enumerator2 = list4.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								List<FamilySymbol> list5 = enumerator2.Current;
								List<List<FamilySymbol>> list6 = (from x in list5
								group x by x.Name into x
								orderby x.Key
								select x.ToList<FamilySymbol>()).ToList<List<FamilySymbol>>();
								TreeNode treeNode2 = new TreeNode();
								treeNode2.Name = "nodeFamily";
								foreach (List<FamilySymbol> list7 in list6)
								{
									TreeNode treeNode3 = new TreeNode();
									treeNode3.Name = "nodeSymbol";
									treeNode3.Text = list7.First<FamilySymbol>().Name + ": " + list7.Count.ToString();
									treeNode2.Nodes.Add(treeNode3);
								}
								treeNode2.Text = list5.First<FamilySymbol>().FamilyName + ": " + list5.Count.ToString();
								treeNode.Nodes.Add(treeNode2);
							}
							goto IL_3B3;
						}
					}
					List<List<Element>> list8 = (from x in list3
					group x by x.Name into x
					orderby x.Key
					select x.ToList<Element>()).ToList<List<Element>>();
					foreach (List<Element> list9 in list8)
					{
						TreeNode treeNode4 = new TreeNode();
						treeNode4.Name = "nodeElementType";
						treeNode4.Text = list9.First<Element>().Name + ": " + list9.Count.ToString();
						treeNode.Nodes.Add(treeNode4);
					}
					IL_3B3:
					treeNode.Text = list3.First<Element>().Category.Name + ": " + list3.Count.ToString();
					list2.Add(treeNode);
				}
				catch (Exception)
				{
				}
			}
			return list2;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0001B6F8 File Offset: 0x000198F8
		private List<TreeNode> ElementsToTreeViewByCreated(List<Element> elements)
		{
			List<List<Element>> list = (from x in elements
			group x by WorksharingUtils.GetWorksharingTooltipInfo(this.doc, x.Id).Creator into x
			orderby x.Key
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

		// Token: 0x0600017B RID: 379 RVA: 0x0001B84C File Offset: 0x00019A4C
		private List<TreeNode> ElementsToTreeViewByChanged(List<Element> elements)
		{
			List<List<Element>> list = (from x in elements
			group x by WorksharingUtils.GetWorksharingTooltipInfo(this.doc, x.Id).LastChangedBy into x
			orderby x.Key
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
				treeNode.Text = worksharingTooltipInfo.LastChangedBy + ": " + list3.Count.ToString();
				list2.Add(treeNode);
			}
			return list2;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0001B9A0 File Offset: 0x00019BA0
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

		// Token: 0x0600017D RID: 381 RVA: 0x0001BB40 File Offset: 0x00019D40
		private TreeNode ListToTreeNode(List<TreeNode> treeNodes)
		{
			TreeNode treeNode = new TreeNode();
			foreach (TreeNode node in treeNodes)
			{
				treeNode.Nodes.Add(node);
			}
			return treeNode;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0001BB9C File Offset: 0x00019D9C
		private List<Element> GetElementsForTreeView()
		{
			Document document = this.uidoc.Document;
			return new FilteredElementCollector(document).WhereElementIsElementType().ToList<Element>();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0001BBC8 File Offset: 0x00019DC8
		private List<Element> ElementsSearched(List<Element> elements, string text)
		{
			List<Element> list = new List<Element>();
			if (this.rButtonTypeName.Checked)
			{
				if (this.comboBoxSearch.SelectedItem.ToString() == "Contains")
				{
					list = (from x in elements
					where x.Name.Contains(text)
					select x).ToList<Element>();
				}
				else if (this.comboBoxSearch.SelectedItem.ToString() == "Equals")
				{
					list = (from x in elements
					where x.Name.Equals(text)
					select x).ToList<Element>();
				}
				else if (this.comboBoxSearch.SelectedItem.ToString() == "Starts with")
				{
					list = (from x in elements
					where x.Name.StartsWith(text)
					select x).ToList<Element>();
				}
				else if (this.comboBoxSearch.SelectedItem.ToString() == "Ends with")
				{
					list = (from x in elements
					where x.Name.EndsWith(text)
					select x).ToList<Element>();
				}
			}
			else
			{
				foreach (Element element in elements)
				{
					if (element is FamilyInstance)
					{
						FamilyInstance familyInstance = element as FamilyInstance;
						string familyName = familyInstance.Symbol.FamilyName;
						if (this.comboBoxSearch.SelectedItem.ToString() == "Contains" & familyName.Contains(text))
						{
							list.Add(element);
						}
						else if (this.comboBoxSearch.SelectedItem.ToString() == "Equals" & familyName.Equals(text))
						{
							list.Add(element);
						}
						else if (this.comboBoxSearch.SelectedItem.ToString() == "Starts with" & familyName.StartsWith(text))
						{
							list.Add(element);
						}
						else if (this.comboBoxSearch.SelectedItem.ToString() == "Ends with" & familyName.EndsWith(text))
						{
							list.Add(element);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000023A6 File Offset: 0x000005A6
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0001BE1C File Offset: 0x0001A01C
		private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown && e.Node.Nodes.Count > 0)
			{
				this.CheckAllChildNodes(e.Node, e.Node.Checked);
			}
			List<TreeNode> list = new List<TreeNode>();
			this.GetCheckedNodes(this.treeViewElements.Nodes, list);
			this.labelCount.Text = this.textCount + list.Count.ToString();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0001BE97 File Offset: 0x0001A097
		private void buttonExpand_Click(object sender, EventArgs e)
		{
			this.treeViewElements.ExpandAll();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0001BEA4 File Offset: 0x0001A0A4
		private void buttonCollapse_Click(object sender, EventArgs e)
		{
			this.treeViewElements.CollapseAll();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0001BEB4 File Offset: 0x0001A0B4
		public void CheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0001BF10 File Offset: 0x0001A110
		public void UncheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0001BF6C File Offset: 0x0001A16C
		private void CheckChildren(TreeNode rootNode, bool isChecked)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.CheckChildren(treeNode, isChecked);
				treeNode.Checked = isChecked;
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0001BFD0 File Offset: 0x0001A1D0
		private void buttonCheck_Click(object sender, EventArgs e)
		{
			this.CheckAllNodes(this.treeViewElements.Nodes);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0001BFE3 File Offset: 0x0001A1E3
		private void buttonUncheck_Click(object sender, EventArgs e)
		{
			this.UncheckAllNodes(this.treeViewElements.Nodes);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0001BFF6 File Offset: 0x0001A1F6
		private void buttonDeselect_Click(object sender, EventArgs e)
		{
			this.uidoc.Selection.SetElementIds(new List<ElementId>());
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000023A6 File Offset: 0x000005A6
		private void labelDevelopment_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0001C00D File Offset: 0x0001A20D
		private void radioButtonFamilyType_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0001C00D File Offset: 0x0001A20D
		private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0001C00D File Offset: 0x0001A20D
		private void rButtonListChanged_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0001C024 File Offset: 0x0001A224
		private void buttonSearch_Click(object sender, EventArgs e)
		{
			string text = this.textBoxSearch.Text;
			this.RefreshTreeView(this.ElementsSearched(this.GetElementsForTreeView(), text));
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0001C050 File Offset: 0x0001A250
		private void buttonReset_Click(object sender, EventArgs e)
		{
			this.RefreshTreeView(this.GetElementsForTreeView());
		}

		// Token: 0x0400012F RID: 303
		private UIDocument uidoc;

		// Token: 0x04000130 RID: 304
		private string textCount;

		// Token: 0x04000131 RID: 305
		private Document doc;

		// Token: 0x04000132 RID: 306
		private View view;

		// Token: 0x04000134 RID: 308
		private bool formLoad;
	}
}



