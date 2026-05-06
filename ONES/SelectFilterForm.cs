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
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using ONES.Properties;

namespace ONES
{
	// Token: 0x0200003A RID: 58
	public partial class SelectFilterForm : System.Windows.Forms.Form
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000196 RID: 406 RVA: 0x0001CEC2 File Offset: 0x0001B0C2
		// (set) Token: 0x06000197 RID: 407 RVA: 0x0001CECA File Offset: 0x0001B0CA
		public List<ElementId> checkedIds { get; set; }

		// Token: 0x06000198 RID: 408 RVA: 0x0001CED4 File Offset: 0x0001B0D4
		public SelectFilterForm(UIDocument _uidoc)
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
			this.labelCount.Text = this.textCount;
			this.rButtonCurrentView.Checked = true;
			this.rBCurrentViewE.Checked = true;
			this.rBNewSel.Checked = true;
			this.rBListType.Checked = true;
			this.rBTypeName.Checked = true;
			base.AcceptButton = this.buttonSelect;
			base.CancelButton = this.buttonClose;
			base.MaximizeBox = false;
			this.groupBoxExtended.Visible = false;
			this.groupBoxExport.Visible = false;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0001D004 File Offset: 0x0001B204
		private void SelectFilterForm_Load(object sender, EventArgs e)
		{
			this.RefreshTreeView(this.GetElementsForTreeView());
			this.formLoad = true;
			this.comboBoxSearch.Items.Add(this.searchContain);
			this.comboBoxSearch.Items.Add(this.searchEqual);
			this.comboBoxSearch.Items.Add(this.searchStart);
			this.comboBoxSearch.Items.Add(this.searchEnd);
			this.comboBoxSearch.SelectedIndex = 0;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0001D08C File Offset: 0x0001B28C
		private void JapaneseUI()
		{
			this.textCount = "合計選択項目：";
			this.buttonSelect.Text = "選択";
			this.buttonDeselect.Text = "選択解除";
			this.buttonClose.Text = "閉じる";
			this.groupBoxSelection.Text = "選択オプション";
			this.rButtonCurrentSel.Text = "現在の選択";
			this.rButtonCurrentView.Text = "ビュー内の表示";
			this.rButtonAllProject.Text = "プロジェクト全体";
			this.groupBoxListingOption.Text = "グループ化オプション";
			this.rBListType.Text = "タイプ";
			this.rBListWorkset.Text = "ワークセット";
			this.rBListLevel.Text = "レベル";
			this.rBListCreated.Text = "作成者ごと";
			this.rBListOwner.Text = "所有者";
			this.rBListChanged.Text = "変更者ごと";
			this.rBListInplace.Text = "インプレースのみ";
			this.rBWarnings.Text = "警告がある要素";
			this.groupBoxSearch.Text = "検索オプション";
			this.rBTypeName.Text = "タイプ名";
			this.rBFamilyName.Text = "ファミリ名";
			this.buttonSearch.Text = "検索";
			this.buttonReset.Text = "リセット";
			this.searchContain = "いずれかを含む";
			this.searchEqual = "完全一致";
			this.searchStart = "前方一致";
			this.searchEnd = "後方一致";
			this.groupBoxExtended.Text = "拡張選択";
			this.groupBoxCondition.Text = "選定条件";
			this.checkBoxCategory.Text = "同じカテゴリ";
			this.checkBoxFamily.Text = "同じファミリ";
			this.checkBoxType.Text = "同じタイプ";
			this.checkBoxWorkset.Text = "同じワークセット";
			this.checkBoxHostOf.Text = "選択した要素のホスト";
			this.checkBoxIsHost.Text = "選択した要素はホスト";
			this.checkBoxNestedFamily.Text = "ネストファミリ";
			this.checkBoxHostFamily.Text = "ホストファミリ";
			this.checkBoxJoined.Text = "結合された要素";
			this.groupBoxSelectionRange.Text = "選択範囲";
			this.rBCurrentViewE.Text = "現在のビュー";
			this.rBAllProjectE.Text = "全てのプロジェクト";
			this.groupBoxSelMethod.Text = "選択方法";
			this.rBExtendSel.Text = "現在の選択を拡張する";
			this.rBNewSel.Text = "新選択";
			this.groupBoxExport.Text = "Excelにエクスポート";
			this.buttonExcel.Text = "エクスポート";
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0001D350 File Offset: 0x0001B550
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

		// Token: 0x0600019C RID: 412 RVA: 0x0001D3C0 File Offset: 0x0001B5C0
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

		// Token: 0x0600019D RID: 413 RVA: 0x0001D444 File Offset: 0x0001B644
		private void RefreshTreeView(List<Element> elements)
		{
			this.treeViewElements.Nodes.Clear();
			List<TreeNode> treeNodes = new List<TreeNode>();
			if (this.rBListWorkset.Checked)
			{
				treeNodes = this.ElementsToTreeViewByWorkset(elements);
			}
			else if (this.rBListLevel.Checked)
			{
				treeNodes = this.ElementsToTreeViewByLevel(elements);
			}
			else if (this.rBListCreated.Checked)
			{
				treeNodes = this.ElementsToTreeViewByCreated(elements);
			}
			else if (this.rBListOwner.Checked)
			{
				treeNodes = this.ElementsToTreeViewByOwner(elements);
			}
			else if (this.rBListChanged.Checked)
			{
				treeNodes = this.ElementsToTreeViewByChanged(elements);
			}
			else if (this.rBListInplace.Checked)
			{
				treeNodes = this.ElementsToTreeViewInplaceOnly(elements);
			}
			else if (this.rBWarnings.Checked)
			{
				treeNodes = this.ElementsToTreeViewWarnings(elements);
			}
			else
			{
				treeNodes = this.ElementsToTreeViewByType(elements);
			}
			this.ElementsToTreeView(treeNodes);
			this.labelCount.Text = this.textCount;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0001D52C File Offset: 0x0001B72C
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

		// Token: 0x0600019F RID: 415 RVA: 0x0001D5B4 File Offset: 0x0001B7B4
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
					List<Element> source = new List<Element>();
					List<Element> source2 = new List<Element>();
					List<Element> list4 = new List<Element>();
					List<Element> list5 = new List<Element>();
					foreach (Element element in list3)
					{
						try
						{
							if (element.GetTypeId().IntegerValue == -1)
							{
								list4.Add(element);
							}
							else
							{
								list5.Add(element);
							}
						}
						catch (Exception)
						{
						}
					}
					if (source.Any<Element>())
					{
						List<List<FamilyInstance>> list6 = (from FamilyInstance x in source
						group x by x.Symbol.FamilyName into x
						orderby x.Key
						select x.ToList<FamilyInstance>()).ToList<List<FamilyInstance>>();
						foreach (List<FamilyInstance> list7 in list6)
						{
							List<List<FamilyInstance>> list8 = (from x in list7
							group x by x.Symbol.Name into x
							orderby x.Key
							select x.ToList<FamilyInstance>()).ToList<List<FamilyInstance>>();
							TreeNode treeNode2 = new TreeNode();
							treeNode2.Name = "nodeFamily";
							foreach (List<FamilyInstance> list9 in list8)
							{
								TreeNode treeNode3 = new TreeNode();
								treeNode3.Name = "nodeSymbol";
								treeNode3.Text = list9.First<FamilyInstance>().Name + ": " + list9.Count.ToString();
								foreach (FamilyInstance familyInstance in list9)
								{
									try
									{
										TreeNode node = this.TreeNodeElement(familyInstance);
										treeNode3.Nodes.Add(node);
									}
									catch (Exception)
									{
									}
								}
								treeNode2.Nodes.Add(treeNode3);
							}
							treeNode2.Text = list7.First<FamilyInstance>().Symbol.FamilyName + ": " + list7.Count.ToString();
							treeNode.Nodes.Add(treeNode2);
						}
					}
					if (list5.Any<Element>())
					{
						List<List<Element>> list10 = (from x in list5
						group x by (this.doc.GetElement(x.GetTypeId()) as ElementType).FamilyName into x
						orderby x.Key
						select x.ToList<Element>()).ToList<List<Element>>();
						foreach (List<Element> list11 in list10)
						{
							List<List<Element>> list12 = (from x in list11
							group x by (this.doc.GetElement(x.GetTypeId()) as ElementType).Name into x
							orderby x.Key
							select x.ToList<Element>()).ToList<List<Element>>();
							TreeNode treeNode4 = new TreeNode();
							treeNode4.Name = "nodeFamily";
							foreach (List<Element> list13 in list12)
							{
								TreeNode treeNode5 = new TreeNode();
								treeNode5.Name = "nodeSymbol";
								treeNode5.Text = this.doc.GetElement(list13.First<Element>().GetTypeId()).Name + ": " + list13.Count.ToString();
								foreach (Element element2 in list13)
								{
									try
									{
										TreeNode node2 = this.TreeNodeElement(element2);
										treeNode5.Nodes.Add(node2);
									}
									catch (Exception)
									{
									}
								}
								treeNode4.Nodes.Add(treeNode5);
							}
							ElementType elementType = this.doc.GetElement(list11.First<Element>().GetTypeId()) as ElementType;
							treeNode4.Text = elementType.FamilyName + ": " + list11.Count.ToString();
							treeNode.Nodes.Add(treeNode4);
						}
					}
					if (list4.Any<Element>())
					{
						List<List<Element>> list14 = (from x in list4
						where this.doc.GetElement(x.GetTypeId()) != null
						group x by this.doc.GetElement(x.GetTypeId()).Name into x
						orderby x.Key
						select x.ToList<Element>()).ToList<List<Element>>();
						foreach (Element element3 in list3)
						{
							TreeNode node3 = this.TreeNodeElement(element3);
							treeNode.Nodes.Add(node3);
						}
					}
					if (source2.Any<Element>())
					{
						List<List<Element>> list15 = (from x in source2
						where this.doc.GetElement(x.GetTypeId()) != null
						group x by this.doc.GetElement(x.GetTypeId()).Name into x
						orderby x.Key
						select x.ToList<Element>()).ToList<List<Element>>();
						foreach (List<Element> list16 in list15)
						{
							TreeNode treeNode6 = new TreeNode();
							treeNode6.Name = "nodeElementType";
							treeNode6.Text = list16.First<Element>().Name + ": " + list16.Count.ToString();
							foreach (Element element4 in list16)
							{
								TreeNode node4 = this.TreeNodeElement(element4);
								treeNode6.Nodes.Add(node4);
							}
							treeNode.Nodes.Add(treeNode6);
						}
					}
					treeNode.Text = list3.First<Element>().Category.Name + ": " + list3.Count.ToString();
					list2.Add(treeNode);
				}
				catch (Exception ex)
				{
					Debug.Print(ex.Message);
				}
			}
			return list2;
		}

        // Token: 0x060001A0 RID: 416 RVA: 0x0001DF6C File Offset: 0x0001C16C
        private List<TreeNode> ElementsToTreeViewByWorkset(List<Element> elements)
        {
            //IL_00ac: Unknown result type (might be due to invalid IL or missing references)
            //IL_00b1: Unknown result type (might be due to invalid IL or missing references)
            //IL_00b3: Unknown result type (might be due to invalid IL or missing references)
            //IL_00b6: Invalid comparison between Unknown and I4
            List<List<Element>> list = (from x in elements
                                        where x.WorksetId != (WorksetId)null
                                        group x by x.WorksetId into x
                                        select x.ToList()).ToList();
            List<TreeNode> list2 = new List<TreeNode>();
            foreach (List<Element> item in list)
            {
                Workset workset = doc.GetWorksetTable().GetWorkset(item.First().WorksetId);
                WorksetKind kind = workset.Kind;
                if ((int)kind != 4)
                {
                    continue;
                }
                TreeNode treeNode = new TreeNode();
                List<TreeNode> list3 = ElementsToTreeViewByType(item);
                foreach (TreeNode item2 in list3)
                {
                    treeNode.Nodes.Add(item2);
                }
                treeNode.Text = ((WorksetPreview)workset).Name + ": " + item.Count;
                list2.Add(treeNode);
            }
            return list2;
        }

        // Token: 0x060001A1 RID: 417 RVA: 0x0001E0E8 File Offset: 0x0001C2E8
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

		// Token: 0x060001A2 RID: 418 RVA: 0x0001E23C File Offset: 0x0001C43C
		private List<TreeNode> ElementsToTreeViewByOwner(List<Element> elements)
		{
			List<List<Element>> list = (from x in elements
			group x by WorksharingUtils.GetWorksharingTooltipInfo(this.doc, x.Id).Owner into x
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
				treeNode.Text = worksharingTooltipInfo.Owner + ": " + list3.Count.ToString();
				list2.Add(treeNode);
			}
			return list2;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0001E390 File Offset: 0x0001C590
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

		// Token: 0x060001A4 RID: 420 RVA: 0x0001E4E4 File Offset: 0x0001C6E4
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
							Parameter parameter = element.get_Parameter((BuiltInParameter)(-1001383));
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
						Debug.Print(ex.Message);
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

		// Token: 0x060001A5 RID: 421 RVA: 0x0001E718 File Offset: 0x0001C918
		private List<TreeNode> ElementsToTreeViewInplaceOnly(List<Element> elements)
		{
			List<Element> list = new List<Element>();
			foreach (Element element in elements)
			{
				if (element is FamilyInstance)
				{
					FamilyInstance familyInstance = element as FamilyInstance;
					Family family = familyInstance.Symbol.Family;
					if (family.IsInPlace)
					{
						list.Add(element);
					}
				}
			}
			List<List<Element>> list2 = (from x in list
			where x.Category != null
			group x by x.Category.Name into x
			orderby x.Key
			select x.ToList<Element>()).ToList<List<Element>>();
			List<TreeNode> list3 = new List<TreeNode>();
			foreach (List<Element> list4 in list2)
			{
				try
				{
					TreeNode treeNode = new TreeNode();
					treeNode.Name = "nodeElementCategory";
					if (list4.First<Element>() is FamilyInstance)
					{
						List<List<FamilyInstance>> list5 = (from FamilyInstance x in list4
						group x by x.Symbol.FamilyName into x
						orderby x.Key
						select x.ToList<FamilyInstance>()).ToList<List<FamilyInstance>>();
						using (List<List<FamilyInstance>>.Enumerator enumerator3 = list5.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								List<FamilyInstance> list6 = enumerator3.Current;
								List<List<FamilyInstance>> list7 = (from x in list6
								group x by x.Symbol.Name into x
								orderby x.Key
								select x.ToList<FamilyInstance>()).ToList<List<FamilyInstance>>();
								TreeNode treeNode2 = new TreeNode();
								treeNode2.Name = "nodeFamily";
								foreach (List<FamilyInstance> list8 in list7)
								{
									TreeNode treeNode3 = new TreeNode();
									treeNode3.Name = "nodeSymbol";
									treeNode3.Text = list8.First<FamilyInstance>().Name + ": " + list8.Count.ToString();
									foreach (FamilyInstance familyInstance2 in list8)
									{
										try
										{
											TreeNode treeNode4 = new TreeNode();
											treeNode4.Name = "nodeInstance";
											TreeNode treeNode5 = treeNode4;
											string name = familyInstance2.Name;
											string str = " (";
											ElementId id = familyInstance2.Id;
											treeNode5.Text = name + str + ((id != null) ? id.ToString() : null) + ")";
											treeNode4.Tag = familyInstance2;
											treeNode3.Nodes.Add(treeNode4);
										}
										catch (Exception)
										{
										}
									}
									treeNode2.Nodes.Add(treeNode3);
								}
								treeNode2.Text = list6.First<FamilyInstance>().Symbol.FamilyName + ": " + list6.Count.ToString();
								treeNode.Nodes.Add(treeNode2);
							}
							goto IL_53E;
						}
					}
					List<List<Element>> list9 = (from x in list4
					where this.doc.GetElement(x.GetTypeId()) != null
					group x by this.doc.GetElement(x.GetTypeId()).Name into x
					orderby x.Key
					select x.ToList<Element>()).ToList<List<Element>>();
					foreach (List<Element> list10 in list9)
					{
						TreeNode treeNode6 = new TreeNode();
						treeNode6.Name = "nodeElementType";
						treeNode6.Text = list10.First<Element>().Name + ": " + list10.Count.ToString();
						foreach (Element element2 in list10)
						{
							TreeNode treeNode7 = new TreeNode();
							treeNode7.Name = "nodeElement";
							TreeNode treeNode8 = treeNode7;
							string name2 = element2.Name;
							string str2 = " (";
							ElementId id2 = element2.Id;
							treeNode8.Text = name2 + str2 + ((id2 != null) ? id2.ToString() : null) + ")";
							treeNode7.Tag = element2;
							treeNode6.Nodes.Add(treeNode7);
						}
						treeNode.Nodes.Add(treeNode6);
					}
					IL_53E:
					treeNode.Text = list4.First<Element>().Category.Name + ": " + list4.Count.ToString();
					list3.Add(treeNode);
				}
				catch (Exception)
				{
				}
			}
			return list3;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0001ED9C File Offset: 0x0001CF9C
		private List<TreeNode> ElementsToTreeViewWarnings(List<Element> elements)
		{
			IList<FailureMessage> warnings = this.doc.GetWarnings();
			HashSet<ElementId> hashSet = new HashSet<ElementId>();
			List<Element> list = new List<Element>();
			foreach (FailureMessage failureMessage in warnings)
			{
				foreach (ElementId item in failureMessage.GetFailingElements())
				{
					hashSet.Add(item);
				}
			}
			foreach (ElementId elementId in hashSet)
			{
				list.Add(this.doc.GetElement(elementId));
			}
			return this.ElementsToTreeViewByType(list);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0001EE90 File Offset: 0x0001D090
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

		// Token: 0x060001A8 RID: 424 RVA: 0x0001F030 File Offset: 0x0001D230
		private TreeNode ListToTreeNode(List<TreeNode> treeNodes)
		{
			TreeNode treeNode = new TreeNode();
			foreach (TreeNode node in treeNodes)
			{
				treeNode.Nodes.Add(node);
			}
			return treeNode;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0001F08C File Offset: 0x0001D28C
		private List<Element> GetElementsForTreeView()
		{
			Document document = this.uidoc.Document;
			View activeView = this.uidoc.ActiveView;
			List<Element> list = new List<Element>();
			if (this.rButtonAllProject.Checked)
			{
				list = new FilteredElementCollector(document).WhereElementIsNotElementType().ToList<Element>();
			}
			else if (this.rButtonCurrentView.Checked)
			{
				list = new FilteredElementCollector(document, activeView.Id).WhereElementIsNotElementType().ToList<Element>();
			}
			else if (this.rButtonCurrentSel.Checked)
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

		// Token: 0x060001AA RID: 426 RVA: 0x0001F180 File Offset: 0x0001D380
		private List<Element> ElementsSearch(List<Element> elements, string text)
		{
			List<Element> list = new List<Element>();
			if (this.rBTypeName.Checked)
			{
				if (this.comboBoxSearch.SelectedIndex == 0)
				{
					list = (from x in elements
					where x.Name.Contains(text)
					select x).ToList<Element>();
				}
				else if (this.comboBoxSearch.SelectedIndex == 1)
				{
					list = (from x in elements
					where x.Name.Equals(text)
					select x).ToList<Element>();
				}
				else if (this.comboBoxSearch.SelectedIndex == 2)
				{
					list = (from x in elements
					where x.Name.StartsWith(text)
					select x).ToList<Element>();
				}
				else if (this.comboBoxSearch.SelectedIndex == 3)
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
						if (this.comboBoxSearch.SelectedIndex == 0 & familyName.Contains(text))
						{
							list.Add(element);
						}
						else if (this.comboBoxSearch.SelectedIndex == 1 & familyName.Equals(text))
						{
							list.Add(element);
						}
						else if (this.comboBoxSearch.SelectedIndex == 2 & familyName.StartsWith(text))
						{
							list.Add(element);
						}
						else if (this.comboBoxSearch.SelectedIndex == 3 & familyName.EndsWith(text))
						{
							list.Add(element);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0001F35C File Offset: 0x0001D55C
		public void CheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0001F3B8 File Offset: 0x0001D5B8
		public void UncheckAllNodes(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0001F414 File Offset: 0x0001D614
		private void CheckChildren(TreeNode rootNode, bool isChecked)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.CheckChildren(treeNode, isChecked);
				treeNode.Checked = isChecked;
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0001F478 File Offset: 0x0001D678
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

		// Token: 0x060001AF RID: 431 RVA: 0x0001F4CC File Offset: 0x0001D6CC
		private TreeNode TreeNodeElement(FamilyInstance familyInstance)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "nodeInstance";
			TreeNode treeNode2 = treeNode;
			string name = familyInstance.Name;
			string str = " (";
			ElementId id = familyInstance.Id;
			treeNode2.Text = name + str + ((id != null) ? id.ToString() : null) + ")";
			treeNode.Tag = familyInstance;
			return treeNode;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0001F520 File Offset: 0x0001D720
		private void RecurseNodes(TreeNodeCollection currentNode, Worksheet worksheet, int row, int col)
		{
			foreach (object obj in currentNode)
			{
				TreeNode treeNode = (TreeNode)obj;
				row++;
				worksheet.Cells[row, col] = treeNode.Text;
				if (treeNode.FirstNode != null)
				{
					this.RecurseNodes(treeNode.Nodes, worksheet, row, col + 1);
				}
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0001F608 File Offset: 0x0001D808
		private void ExportNodes(TreeNodeCollection currentNode, Worksheet worksheet, int row, int col)
		{
			foreach (object obj in currentNode)
			{
				TreeNode treeNode = (TreeNode)obj;
				row++;
				worksheet.Cells[row, col] = treeNode.Text;
				row++;
				this.ExportNodes(treeNode.Nodes, worksheet, row++, col);
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000023A6 File Offset: 0x000005A6
		private void ExportElements(TreeNodeCollection currentNode, Worksheet worksheet, int row, int col)
		{
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000023A6 File Offset: 0x000005A6
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0001F6F0 File Offset: 0x0001D8F0
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

		// Token: 0x060001B5 RID: 437 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonCurrentSel_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonCurrentView_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonAllProject_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonFamilyType_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonWorkset_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonListLevel_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonInplace_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void radioButtonWarning_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void rButtonListOwner_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0001F76B File Offset: 0x0001D96B
		private void rButtonListChanged_CheckedChanged(object sender, EventArgs e)
		{
			if (this.formLoad)
			{
				this.RefreshTreeView(this.GetElementsForTreeView());
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0001F784 File Offset: 0x0001D984
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
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0001F818 File Offset: 0x0001DA18
		private void buttonSearch_Click(object sender, EventArgs e)
		{
			string text = this.textBoxSearch.Text;
			this.RefreshTreeView(this.ElementsSearch(this.GetElementsForTreeView(), text));
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0001F844 File Offset: 0x0001DA44
		private void buttonReset_Click(object sender, EventArgs e)
		{
			this.RefreshTreeView(this.GetElementsForTreeView());
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0001F854 File Offset: 0x0001DA54
		private void buttonExcel_Click(object sender, EventArgs e)
		{
			Worksheet worksheet = Utils.ExcelWorksheet("TreeView Export");
			int row = 1;
			int col = 1;
			this.ExportNodes(this.treeViewElements.Nodes, worksheet, row, col);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0001F884 File Offset: 0x0001DA84
		private void buttonCheck_Click(object sender, EventArgs e)
		{
			this.CheckAllNodes(this.treeViewElements.Nodes);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0001F897 File Offset: 0x0001DA97
		private void buttonUncheck_Click(object sender, EventArgs e)
		{
			this.UncheckAllNodes(this.treeViewElements.Nodes);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0001F8AA File Offset: 0x0001DAAA
		private void buttonDeselect_Click(object sender, EventArgs e)
		{
			this.uidoc.Selection.SetElementIds(new List<ElementId>());
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0001F8C4 File Offset: 0x0001DAC4
		private void buttonExtend_Click(object sender, EventArgs e)
		{
			Selection selection = this.uidoc.Selection;
			ICollection<ElementId> elementIds = selection.GetElementIds();
			Element element = this.doc.GetElement(elementIds.First<ElementId>());
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc, this.view.Id);
			if (this.rBAllProjectE.Checked)
			{
				filteredElementCollector = new FilteredElementCollector(this.doc);
			}
			if (this.checkBoxCategory.Checked)
			{
				ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(element.Category.Id);
				filteredElementCollector.WherePasses(elementCategoryFilter);
			}
			if (this.checkBoxWorkset.Checked)
			{
				ElementWorksetFilter elementWorksetFilter = new ElementWorksetFilter(element.WorksetId);
				filteredElementCollector.WherePasses(elementWorksetFilter);
			}
			List<Element> list = filteredElementCollector.WhereElementIsNotElementType().ToList<Element>();
			if (this.checkBoxFamily.Checked)
			{
				FamilyInstance familyInstance = element as FamilyInstance;
				string familyName = familyInstance.Symbol.FamilyName;
				List<Element> list2 = new List<Element>();
				foreach (Element element4 in list)
				{
					if (element4 is FamilyInstance)
					{
						FamilyInstance familyInstance2 = element4 as FamilyInstance;
						string familyName2 = familyInstance2.Symbol.FamilyName;
						if (familyName2 == familyName)
						{
							list2.Add(element4);
						}
					}
				}
				list = list2;
			}
			if (this.checkBoxType.Checked)
			{
				list = (from x in list
				where x.GetTypeId().Equals(element.GetTypeId())
				select x).ToList<Element>();
			}
			if (this.checkBoxJoined.Checked)
			{
				ICollection<ElementId> joinedElements = JoinGeometryUtils.GetJoinedElements(this.doc, element);
				List<Element> list3 = new List<Element>();
				foreach (ElementId elementId in joinedElements)
				{
					Element element2 = this.doc.GetElement(elementId);
					list3.Add(element2);
				}
				list = list3;
			}
			if (this.checkBoxHostOf.Checked)
			{
				try
				{
					FamilyInstance familyInstance3 = element as FamilyInstance;
					Element host = familyInstance3.Host;
					if (host != null)
					{
						list = new List<Element>
						{
							host
						};
					}
					else
					{
						list = new List<Element>();
					}
				}
				catch (Exception)
				{
				}
			}
			if (this.checkBoxIsHost.Checked)
			{
				IList<ElementId> dependentElements = element.GetDependentElements(null);
				List<Element> list4 = new List<Element>();
				foreach (ElementId elementId2 in dependentElements)
				{
					try
					{
						Element element3 = this.doc.GetElement(elementId2);
						list4.Add(element3);
					}
					catch (Exception)
					{
					}
				}
				list = list4;
			}
			if (this.rBExtendSel.Checked)
			{
				list.Add(element);
			}
			this.treeViewElements.Nodes.Clear();
			List<TreeNode> treeNodes = this.ElementsToTreeViewByType(list);
			this.ElementsToTreeView(treeNodes);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0001FBF0 File Offset: 0x0001DDF0
		private void buttonExpand_Click(object sender, EventArgs e)
		{
			this.treeViewElements.ExpandAll();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0001FBFD File Offset: 0x0001DDFD
		private void buttonCollapse_Click(object sender, EventArgs e)
		{
			this.treeViewElements.CollapseAll();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000023A6 File Offset: 0x000005A6
		private void groupBoxSelection_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x0400014A RID: 330
		private UIDocument uidoc;

		// Token: 0x0400014B RID: 331
		private string textCount;

		// Token: 0x0400014C RID: 332
		private Document doc;

		// Token: 0x0400014D RID: 333
		private View view;

		// Token: 0x0400014F RID: 335
		private bool formLoad;

		// Token: 0x04000150 RID: 336
		private string searchContain = "Contains";

		// Token: 0x04000151 RID: 337
		private string searchEqual = "Equals";

		// Token: 0x04000152 RID: 338
		private string searchStart = "Starts with";

		// Token: 0x04000153 RID: 339
		private string searchEnd = "Ends with";
	}
}



