using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;

namespace ONES
{
	// Token: 0x02000018 RID: 24
	public partial class WarningManagerForm : System.Windows.Forms.Form
	{
		// Token: 0x0600006B RID: 107 RVA: 0x0000BBF2 File Offset: 0x00009DF2
		public WarningManagerForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = this.uidoc.Document;
			this.view = this.uidoc.ActiveView;
			base.MaximizeBox = false;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000BC30 File Offset: 0x00009E30
		private void WarningManagerForm_Load(object sender, EventArgs e)
		{
			List<TreeNode> list = new List<TreeNode>();
			IList<FailureMessage> warnings = this.doc.GetWarnings();
			List<List<FailureMessage>> list2 = (from x in warnings
			group x by x.GetDescriptionText() into x
			orderby x.Key
			select x.ToList<FailureMessage>()).ToList<List<FailureMessage>>();
			foreach (List<FailureMessage> list3 in list2)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Name = "Failures";
				HashSet<ElementId> hashSet = new HashSet<ElementId>();
				List<Element> list4 = new List<Element>();
				foreach (FailureMessage failureMessage in list3)
				{
					foreach (ElementId elementId in failureMessage.GetFailingElements())
					{
						hashSet.Add(elementId);
						Element element = this.doc.GetElement(elementId);
					}
				}
				foreach (ElementId elementId2 in hashSet)
				{
					Element element2 = this.doc.GetElement(elementId2);
					list4.Add(element2);
				}
				list4 = (from x in list4
				orderby x.Name
				select x).ToList<Element>();
				foreach (Element element3 in list4)
				{
					TreeNode node = this.TreeNodeElement(element3);
					treeNode.Nodes.Add(node);
				}
				treeNode.Text = list3.First<FailureMessage>().GetDescriptionText() + ": " + hashSet.Count.ToString();
				list.Add(treeNode);
			}
			foreach (TreeNode node2 in list)
			{
				this.treeViewWarnings.Nodes.Add(node2);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000BF4C File Offset: 0x0000A14C
		private void RefreshTreeView(List<Element> elements)
		{
			this.treeViewWarnings.Nodes.Clear();
			List<TreeNode> treeNodes = new List<TreeNode>();
			this.ElementsToTreeView(treeNodes);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000BF78 File Offset: 0x0000A178
		private void ElementsToTreeView(List<TreeNode> treeNodes)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "nodeAll";
			treeNode.Text = "All Warnings";
			foreach (TreeNode node in treeNodes)
			{
				treeNode.Nodes.Add(node);
			}
			treeNode.Expand();
			this.treeViewWarnings.Nodes.Add(treeNode);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000C000 File Offset: 0x0000A200
		private TreeNode TreeNodeElement(Element element)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "nodeInstance";
			TreeNode treeNode2 = treeNode;
			string name = element.Name;
			string str = " (";
			ElementId id = element.Id;
			treeNode2.Text = name + str + ((id != null) ? id.ToString() : null) + ")";
			treeNode.Tag = element;
			return treeNode;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000C054 File Offset: 0x0000A254
		public void CheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000C0B0 File Offset: 0x0000A2B0
		public void UncheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000C10C File Offset: 0x0000A30C
		private void CheckChildren(TreeNode rootNode, bool isChecked)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.CheckChildren(treeNode, isChecked);
				treeNode.Checked = isChecked;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000C170 File Offset: 0x0000A370
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

		// Token: 0x06000074 RID: 116 RVA: 0x0000C1E0 File Offset: 0x0000A3E0
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

		// Token: 0x06000075 RID: 117 RVA: 0x000023A6 File Offset: 0x000005A6
		private void treeViewWarnings_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000C264 File Offset: 0x0000A464
		private void treeViewWarnings_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown && e.Node.Nodes.Count > 0)
			{
				this.CheckAllChildNodes(e.Node, e.Node.Checked);
			}
			List<TreeNode> list = new List<TreeNode>();
			this.GetCheckedNodes(this.treeViewWarnings.Nodes, list);
			this.labelCount.Text = this.textCount + list.Count.ToString();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000C2E0 File Offset: 0x0000A4E0
		private string Multiline(string text)
		{
			string text2 = "";
			string[] array = text.Split(new char[]
			{
				'.'
			});
			foreach (string str in array)
			{
				text2 = text2 + str + "\n";
			}
			return text2;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000C32C File Offset: 0x0000A52C
		private void buttonSelect_Click(object sender, EventArgs e)
		{
			List<TreeNode> list = new List<TreeNode>();
			this.GetCheckedNodes(this.treeViewWarnings.Nodes, list);
			List<ElementId> list2 = new List<ElementId>();
			foreach (TreeNode treeNode in list)
			{
				Element element = treeNode.Tag as Element;
				list2.Add(element.Id);
			}
			this.uidoc.Selection.SetElementIds(list2);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0400005E RID: 94
		private UIDocument uidoc;

		// Token: 0x0400005F RID: 95
		private string textCount;

		// Token: 0x04000060 RID: 96
		private Document doc;

		// Token: 0x04000061 RID: 97
		private View view;
	}
}



