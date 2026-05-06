using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;
using RevitColor = Autodesk.Revit.DB.Color;

namespace ONES
{
	// Token: 0x02000028 RID: 40
	public partial class ClashDetectTreeview : System.Windows.Forms.Form
	{
		// Token: 0x060000DB RID: 219 RVA: 0x00014530 File Offset: 0x00012730
		public ClashDetectTreeview(UIDocument _uidoc, List<ElementId> _checkedIds1, List<ElementId> _checkedIds2)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.checkedIds1 = _checkedIds1;
			this.checkedIds2 = _checkedIds2;
			this.doc = this.uidoc.Document;
			this.view = this.doc.ActiveView;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000023A6 File Offset: 0x000005A6
		private void ClashDetectTreeview_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000145A0 File Offset: 0x000127A0
		private void buttonSelect_Click(object sender, EventArgs e)
		{
			List<TreeNode> list = new List<TreeNode>();
			OverrideGraphicSettings overrideGraphicSettings = Utils.OverrideGraphicDefault(this.doc, new RevitColor(0, byte.MaxValue, 0));
			OverrideGraphicSettings overrideGraphicSettings2 = Utils.OverrideGraphicDefault(this.doc, new RevitColor(0, 0, byte.MaxValue));
			using (Transaction transaction = new Transaction(this.doc, "Clash Check"))
			{
				transaction.Start();
				foreach (ElementId elementId in this.checkedIds1)
				{
					try
					{
						Element element = this.doc.GetElement(elementId);
						TreeNode treeNode = new TreeNode();
						treeNode.Name = "nodeElement1";
						treeNode.Tag = element;
						int num = 0;
						Solid solid = Utils.SolidUnion(element, this.view);
						if (!(solid == null))
						{
							BoundingBoxXYZ boundingBoxXYZ = element.get_BoundingBox(this.view);
							Outline outline = new Outline(boundingBoxXYZ.Min, boundingBoxXYZ.Max);
							foreach (ElementId elementId2 in this.checkedIds2)
							{
								try
								{
									if (!(elementId == elementId2))
									{
										Element element2 = this.doc.GetElement(elementId2);
										BoundingBoxXYZ boundingBoxXYZ2 = element2.get_BoundingBox(this.view);
										Outline outline2 = new Outline(boundingBoxXYZ2.Min, boundingBoxXYZ2.Max);
										if (outline.Intersects(outline2, 0.0))
										{
											Solid solid2 = Utils.SolidUnion(element2, this.view);
											if (!(solid2 == null))
											{
												Solid solid3 = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid2, BooleanOperationsType.Intersect);
												if (solid3 != null & solid3.Volume != 0.0)
												{
													num++;
													this.TreenodeAdd(treeNode, element2);
													this.view.SetElementOverrides(elementId, overrideGraphicSettings);
													this.view.SetElementOverrides(elementId2, overrideGraphicSettings2);
													if (this.checkBoxDirectShape.Checked)
													{
														this.DirectShapeGenerate(solid3);
													}
												}
											}
										}
									}
								}
								catch (Exception)
								{
								}
							}
							TreeNode treeNode2 = treeNode;
							string[] array = new string[5];
							array[0] = element.Name;
							array[1] = " (";
							int num2 = 2;
							ElementId elementId3 = elementId;
							array[num2] = ((elementId3 != null) ? elementId3.ToString() : null);
							array[3] = "): ";
							array[4] = num.ToString();
							treeNode2.Text = string.Concat(array);
							list.Add(treeNode);
						}
					}
					catch (Exception)
					{
					}
				}
				transaction.Commit();
			}
			this.ResultToTreeView(list);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000148AC File Offset: 0x00012AAC
		private void ResultToTreeView(List<TreeNode> treeNodes)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "nodeResult";
			treeNode.Text = "Result " + this.countResult.ToString();
			this.countResult++;
			foreach (TreeNode node in treeNodes)
			{
				treeNode.Nodes.Add(node);
			}
			treeNode.Expand();
			this.treeViewClash.Nodes.Add(treeNode);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00014954 File Offset: 0x00012B54
		private void DirectShapeGenerate(Solid solidIntersection)
		{
			DirectShape directShape = DirectShape.CreateElement(this.doc, new ElementId(-2003400));
			directShape.ApplicationId = "Application id";
			directShape.ApplicationDataId = "Geometry object id";
			directShape.SetShape(new List<GeometryObject>
			{
				solidIntersection
			});
			OverrideGraphicSettings overrideGraphicSettings = Utils.OverrideGraphic(this.doc, new RevitColor(byte.MaxValue, 0, 0), false, false, true, true, 0);
			this.view.SetElementOverrides(directShape.Id, overrideGraphicSettings);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000149D0 File Offset: 0x00012BD0
		private void TreenodeAdd(TreeNode treeNodeElement1, Element element2)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Name = "nodeElement2";
			TreeNode treeNode2 = treeNode;
			string name = element2.Name;
			string str = " (";
			ElementId id = element2.Id;
			treeNode2.Text = name + str + ((id != null) ? id.ToString() : null) + ")";
			treeNodeElement1.Tag = element2;
			treeNodeElement1.Nodes.Add(treeNode);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00014A2F File Offset: 0x00012C2F
		private void buttonClear_Click(object sender, EventArgs e)
		{
			this.treeViewClash.Nodes.Clear();
			this.countResult = 1;
		}

		// Token: 0x040000D3 RID: 211
		private UIDocument uidoc;

		// Token: 0x040000D4 RID: 212
		private Document doc;

		// Token: 0x040000D5 RID: 213
		private View view;

		// Token: 0x040000D6 RID: 214
		private List<ElementId> checkedIds1 = new List<ElementId>();

		// Token: 0x040000D7 RID: 215
		private List<ElementId> checkedIds2 = new List<ElementId>();

		// Token: 0x040000D8 RID: 216
		private int countResult = 1;
	}
}



