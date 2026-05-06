using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;
using ONES.Properties;

namespace ONES
{
	// Token: 0x02000035 RID: 53
	public partial class FamilyFilterForm : System.Windows.Forms.Form
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0001918A File Offset: 0x0001738A
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00019192 File Offset: 0x00017392
		public List<ElementId> checkedIds { get; set; }

		// Token: 0x06000147 RID: 327 RVA: 0x0001919C File Offset: 0x0001739C
		public FamilyFilterForm(UIDocument _uidoc)
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

		// Token: 0x06000148 RID: 328 RVA: 0x00019264 File Offset: 0x00017464
		private void FamilyFilterForm_Load(object sender, EventArgs e)
		{
			this.RefreshTreeView(this.GetElementsForTreeView());
			this.formLoad = true;
			this.comboBoxSearch.Items.Add("Contains");
			this.comboBoxSearch.Items.Add("Equals");
			this.comboBoxSearch.Items.Add("Starts with");
			this.comboBoxSearch.Items.Add("Ends with");
			this.comboBoxSearch.SelectedIndex = 0;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000192E8 File Offset: 0x000174E8
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

		// Token: 0x0600014A RID: 330 RVA: 0x00019394 File Offset: 0x00017594
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

		// Token: 0x0600014B RID: 331 RVA: 0x00019404 File Offset: 0x00017604
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

		// Token: 0x0600014C RID: 332 RVA: 0x00019488 File Offset: 0x00017688
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

		// Token: 0x0600014D RID: 333 RVA: 0x000194E8 File Offset: 0x000176E8
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

		// Token: 0x0600014E RID: 334 RVA: 0x00019570 File Offset: 0x00017770
		private List<TreeNode> ElementsToTreeViewByType(List<Element> elements)
		{
			List<List<Family>> list = (from Family x in elements
			where x.FamilyCategory != null
			group x by x.FamilyCategory.Name into x
			orderby x.Key
			select x.ToList<Family>()).ToList<List<Family>>();
			List<Family> list2 = elements.Cast<Family>().ToList<Family>();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			List<TreeNode> list3 = new List<TreeNode>();
			foreach (List<Family> list4 in list)
			{
				try
				{
					TreeNode treeNode = new TreeNode();
					treeNode.Name = "nodeElementCategory";
					Category familyCategory = list4.First<Family>().FamilyCategory;
					ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(familyCategory.Id);
					foreach (Family family in list4)
					{
						TreeNode treeNode2 = new TreeNode();
						treeNode2.Name = "nodeFamily";
						treeNode2.Text = family.Name;
						treeNode2.ForeColor = System.Drawing.Color.Red;
						FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc).WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).WherePasses(elementCategoryFilter);
						foreach (Element element in filteredElementCollector)
						{
							FamilyInstance familyInstance = element as FamilyInstance;
							if (familyInstance.Symbol.FamilyName == family.Name)
							{
								treeNode2.ForeColor = System.Drawing.Color.Black;
								break;
							}
						}
						treeNode.Nodes.Add(treeNode2);
					}
					treeNode.Text = familyCategory.Name + ": " + list4.Count.ToString();
					list3.Add(treeNode);
				}
				catch (Exception)
				{
				}
			}
			stopwatch.Stop();
			TimeSpan elapsed = stopwatch.Elapsed;
			return list3;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00019834 File Offset: 0x00017A34
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

		// Token: 0x06000150 RID: 336 RVA: 0x00019988 File Offset: 0x00017B88
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

		// Token: 0x06000151 RID: 337 RVA: 0x00019ADC File Offset: 0x00017CDC
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

		// Token: 0x06000152 RID: 338 RVA: 0x00019C7C File Offset: 0x00017E7C
		private List<Element> GetElementsForTreeView()
		{
			Document document = this.uidoc.Document;
			return new FilteredElementCollector(document).OfClass(typeof(Family)).ToList<Element>();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00019CB4 File Offset: 0x00017EB4
		private List<Element> ElementsSearched(List<Element> elements, string text)
		{
			List<Element> result = new List<Element>();
			if (this.comboBoxSearch.SelectedItem.ToString() == "Contains")
			{
				result = (from x in elements
				where x.Name.Contains(text)
				select x).ToList<Element>();
			}
			else if (this.comboBoxSearch.SelectedItem.ToString() == "Equals")
			{
				result = (from x in elements
				where x.Name.Equals(text)
				select x).ToList<Element>();
			}
			else if (this.comboBoxSearch.SelectedItem.ToString() == "Starts with")
			{
				result = (from x in elements
				where x.Name.StartsWith(text)
				select x).ToList<Element>();
			}
			else if (this.comboBoxSearch.SelectedItem.ToString() == "Ends with")
			{
				result = (from x in elements
				where x.Name.EndsWith(text)
				select x).ToList<Element>();
			}
			return result;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000023A6 File Offset: 0x000005A6
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00019DB0 File Offset: 0x00017FB0
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

		// Token: 0x06000156 RID: 342 RVA: 0x00019E2B File Offset: 0x0001802B
		private void buttonExpand_Click(object sender, EventArgs e)
		{
			this.treeViewElements.ExpandAll();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00019E38 File Offset: 0x00018038
		private void buttonCollapse_Click(object sender, EventArgs e)
		{
			this.treeViewElements.CollapseAll();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00019E48 File Offset: 0x00018048
		public void CheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00019EA4 File Offset: 0x000180A4
		public void UncheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00019F00 File Offset: 0x00018100
		private void CheckChildren(TreeNode rootNode, bool isChecked)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.CheckChildren(treeNode, isChecked);
				treeNode.Checked = isChecked;
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00019F64 File Offset: 0x00018164
		private void buttonCheck_Click(object sender, EventArgs e)
		{
			this.CheckAllNodes(this.treeViewElements.Nodes);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00019F77 File Offset: 0x00018177
		private void buttonUncheck_Click(object sender, EventArgs e)
		{
			this.UncheckAllNodes(this.treeViewElements.Nodes);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00019F8A File Offset: 0x0001818A
		private void buttonDeselect_Click(object sender, EventArgs e)
		{
			this.uidoc.Selection.SetElementIds(new List<ElementId>());
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000023A6 File Offset: 0x000005A6
		private void labelDevelopment_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00019FA1 File Offset: 0x000181A1
		private void radioButtonFamilyType_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00019FA1 File Offset: 0x000181A1
		private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00019FA1 File Offset: 0x000181A1
		private void rButtonListChanged_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00019FB8 File Offset: 0x000181B8
		private void buttonSearch_Click(object sender, EventArgs e)
		{
			string text = this.textBoxSearch.Text;
			this.RefreshTreeView(this.ElementsSearched(this.GetElementsForTreeView(), text));
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00019FE4 File Offset: 0x000181E4
		private void buttonReset_Click(object sender, EventArgs e)
		{
			this.RefreshTreeView(this.GetElementsForTreeView());
		}

		// Token: 0x04000116 RID: 278
		private UIDocument uidoc;

		// Token: 0x04000117 RID: 279
		private string textCount;

		// Token: 0x04000118 RID: 280
		private Document doc;

		// Token: 0x04000119 RID: 281
		private View view;

		// Token: 0x0400011B RID: 283
		private bool formLoad;
	}
}



