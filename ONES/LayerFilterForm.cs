using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Color = Autodesk.Revit.DB.Color;
using Autodesk.Revit.UI;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
	// Token: 0x0200001E RID: 30
	public partial class LayerFilterForm : System.Windows.Forms.Form
	{
		// Token: 0x06000092 RID: 146 RVA: 0x0000DB8C File Offset: 0x0000BD8C
		public LayerFilterForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = _uidoc.Document;
			this.col = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id);
			this.colorsRGB.Add(new Color(byte.MaxValue, 0, 0));
			this.colorsRGB.Add(new Color(0, byte.MaxValue, 0));
			this.colorsRGB.Add(new Color(0, 0, byte.MaxValue));
			this.colorsRGB.Add(new Color(byte.MaxValue, byte.MaxValue, 0));
			this.colorsRGB.Add(new Color(0, byte.MaxValue, byte.MaxValue));
			this.colorsRGB.Add(new Color(byte.MaxValue, 0, byte.MaxValue));
			this.colorsRGB.Add(new Color(128, 0, 0));
			this.colorsRGB.Add(new Color(0, 128, 0));
			this.colorsRGB.Add(new Color(0, 0, 128));
			this.colorsRGB.Add(new Color(128, 128, 0));
			this.colorsRGB.Add(new Color(0, 128, 128));
			this.colorsRGB.Add(new Color(128, 0, 128));
			this.colorsRGB.Add(new Color(225, 0, 0));
			this.colorsRGB.Add(new Color(0, 225, 0));
			this.colorsRGB.Add(new Color(0, 0, 225));
			this.colorsRGB.Add(new Color(225, 225, 0));
			this.colorsRGB.Add(new Color(0, 225, 225));
			this.colorsRGB.Add(new Color(225, 0, 225));
			this.colorsRGB.Add(new Color(150, 0, 0));
			this.colorsRGB.Add(new Color(0, 150, 0));
			this.colorsRGB.Add(new Color(0, 0, 150));
			this.colorsRGB.Add(new Color(150, 150, 0));
			this.colorsRGB.Add(new Color(0, 150, 150));
			this.colorsRGB.Add(new Color(150, 0, 150));
			this.colorsRGB.Add(new Color(200, 0, 0));
			this.colorsRGB.Add(new Color(0, 200, 0));
			this.colorsRGB.Add(new Color(0, 0, 200));
			this.colorsRGB.Add(new Color(200, 200, 0));
			this.colorsRGB.Add(new Color(0, 200, 200));
			this.colorsRGB.Add(new Color(200, 0, 200));
			this.colorsRGB.Add(new Color(175, 0, 0));
			this.colorsRGB.Add(new Color(0, 175, 0));
			this.colorsRGB.Add(new Color(0, 0, 175));
			this.colorsRGB.Add(new Color(175, 175, 0));
			this.colorsRGB.Add(new Color(0, 175, 175));
			this.colorsRGB.Add(new Color(175, 0, 175));
			this.colorsRGB.Add(new Color(100, 0, 0));
			this.colorsRGB.Add(new Color(0, 100, 0));
			this.colorsRGB.Add(new Color(0, 0, 100));
			this.colorsRGB.Add(new Color(100, 100, 0));
			this.colorsRGB.Add(new Color(0, 100, 100));
			this.colorsRGB.Add(new Color(100, 0, 100));
			this.colorsRGB.Add(new Color(240, 0, 0));
			this.colorsRGB.Add(new Color(0, 240, 0));
			this.colorsRGB.Add(new Color(0, 0, 240));
			this.colorsRGB.Add(new Color(240, 240, 0));
			this.colorsRGB.Add(new Color(0, 240, 240));
			this.colorsRGB.Add(new Color(240, 0, 240));
			this.colorsRGB.Add(new Color(140, 0, 0));
			this.colorsRGB.Add(new Color(0, 140, 0));
			this.colorsRGB.Add(new Color(0, 0, 140));
			this.colorsRGB.Add(new Color(140, 140, 0));
			this.colorsRGB.Add(new Color(0, 140, 140));
			this.colorsRGB.Add(new Color(140, 0, 140));
			this.colorsRGB.Add(new Color(212, 0, 0));
			this.colorsRGB.Add(new Color(0, 212, 0));
			this.colorsRGB.Add(new Color(0, 0, 212));
			this.colorsRGB.Add(new Color(212, 212, 0));
			this.colorsRGB.Add(new Color(0, 212, 212));
			this.colorsRGB.Add(new Color(212, 0, 212));
			this.colorsRGB.Add(new Color(162, 0, 0));
			this.colorsRGB.Add(new Color(0, 162, 0));
			this.colorsRGB.Add(new Color(0, 0, 162));
			this.colorsRGB.Add(new Color(162, 162, 0));
			this.colorsRGB.Add(new Color(0, 162, 162));
			this.colorsRGB.Add(new Color(162, 0, 162));
			this.colorsRGB.Add(new Color(187, 0, 0));
			this.colorsRGB.Add(new Color(0, 187, 0));
			this.colorsRGB.Add(new Color(0, 0, 187));
			this.colorsRGB.Add(new Color(187, 187, 0));
			this.colorsRGB.Add(new Color(0, 187, 187));
			this.colorsRGB.Add(new Color(187, 0, 187));
			this.colorsRGB.Add(new Color(75, 0, 0));
			this.colorsRGB.Add(new Color(0, 75, 0));
			this.colorsRGB.Add(new Color(0, 0, 75));
			this.colorsRGB.Add(new Color(75, 75, 0));
			this.colorsRGB.Add(new Color(0, 75, 75));
			this.colorsRGB.Add(new Color(75, 0, 75));
			this.colorsNSS.Add(new Color(byte.MaxValue, 227, 221));
			this.colorsNSS.Add(new Color(byte.MaxValue, byte.MaxValue, 210));
			this.colorsNSS.Add(new Color(232, 248, 154));
			this.colorsNSS.Add(new Color(215, 238, byte.MaxValue));
			this.colorsNSS.Add(new Color(byte.MaxValue, 234, 206));
			this.colorsNSS.Add(new Color(185, 236, 210));
			this.colorsNSS.Add(new Color(232, 218, 245));
			this.colorsNSS.Add(new Color(238, 252, 205));
			this.colorsNSS.Add(new Color(211, 247, 250));
			this.colorsNSS.Add(new Color(208, 250, 177));
			this.colorsNSS.Add(new Color(219, 218, 246));
			this.colorsNSS.Add(new Color(236, 225, 206));
			this.colorsNSS.Add(new Color(237, 211, 235));
			this.colorsNSS.Add(new Color(byte.MaxValue, 216, 157));
			this.colorsNSS.Add(new Color(170, 213, byte.MaxValue));
			this.colorsNSS.Add(new Color(156, 254, 200));
			this.colorsV.Add(new Color(185, 31, 87));
			this.colorsV.Add(new Color(208, 47, 72));
			this.colorsV.Add(new Color(221, 68, 59));
			this.colorsV.Add(new Color(233, 91, 35));
			this.colorsV.Add(new Color(230, 120, 0));
			this.colorsV.Add(new Color(244, 157, 0));
			this.colorsV.Add(new Color(241, 181, 0));
			this.colorsV.Add(new Color(238, 201, 0));
			this.colorsV.Add(new Color(210, 193, 0));
			this.colorsV.Add(new Color(168, 187, 0));
			this.colorsV.Add(new Color(88, 169, 90));
			this.colorsV.Add(new Color(0, 161, 90));
			this.colorsV.Add(new Color(0, 146, 110));
			this.colorsV.Add(new Color(0, 133, 127));
			this.colorsV.Add(new Color(0, 116, 136));
			this.colorsV.Add(new Color(0, 112, 155));
			this.colorsV.Add(new Color(0, 96, 156));
			this.colorsV.Add(new Color(0, 91, 165));
			this.colorsV.Add(new Color(26, 84, 165));
			this.colorsV.Add(new Color(83, 74, 165));
			this.colorsV.Add(new Color(112, 63, 150));
			this.colorsV.Add(new Color(129, 55, 138));
			this.colorsV.Add(new Color(143, 46, 124));
			this.colorsV.Add(new Color(173, 46, 108));
			RadioButton rbpalette = this.RBPalette1;
			rbpalette.Text = rbpalette.Text + ":" + this.colorsNSS.Count<Color>().ToString();
			RadioButton rbpalette2 = this.RBPalette2;
			rbpalette2.Text = rbpalette2.Text + ":" + this.colorsV.Count<Color>().ToString();
			RadioButton rbpalette3 = this.RBPalette3;
			rbpalette3.Text = rbpalette3.Text + ":" + this.colorsRGB.Count<Color>().ToString();
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.groupBoxElements.Text = "要素を選択";
				this.checkBoxHalftone.Text = "ハーフトーン";
				this.columnHeader1.Text = "カテゴリー";
				this.columnHeader2.Text = "カテゴリー";
				this.columnHeader4.Text = "値";
				this.buttonFilter.Text = "フィルタ";
				this.buttonOverride.Text = "上書き";
				this.buttonSelect.Text = "表示";
				this.RBAView.Text = "アクティブビュー";
				this.RBAll.Text = "すべてのプロジェクト";
				this.checkBoxTemplate.Text = "テンプレート";
				this.buttonAll.Text = "すべて選択";
				this.buttonNone.Text = "選択解除";
				this.RBPalette1.Text = "パレット1：" + this.colorsRGB.Count<Color>().ToString();
				this.RBPalette2.Text = "パレット2：" + this.colorsNSS.Count<Color>().ToString();
			}
			base.AcceptButton = this.buttonSelect;
			base.CancelButton = this.buttonCancel;
			base.MaximizeBox = false;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000E9C8 File Offset: 0x0000CBC8
		private void ColorElementsForm_Load(object sender, EventArgs e)
		{
			this.RBAView.Checked = true;
			this.RBPalette1.Checked = true;
			this.RBTextBlack.Checked = true;
			this.checkBoxHalftone.Checked = false;
			this.checkBoxLine.Checked = false;
			this.checkBoxSurface.Checked = true;
			this.checkBoxCut.Checked = true;
			this.checkBoxNest.Checked = false;
			this.GetCategories();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000EA3C File Offset: 0x0000CC3C
		private OverrideGraphicSettings OverrideGraphic(Color color)
		{
			bool @checked = this.checkBoxHalftone.Checked;
			bool checked2 = this.checkBoxLine.Checked;
			bool checked3 = this.checkBoxSurface.Checked;
			bool checked4 = this.checkBoxCut.Checked;
			bool checked5 = this.checkBoxNest.Checked;
			int transparency = this.trackBarTransparency.Value * 10;
			return Utils.OverrideGraphic(this.doc, color, @checked, checked2, checked3, checked4, transparency);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000EAAC File Offset: 0x0000CCAC
		private void LayerToValue(List<CompoundStructureLayer> compoundLayers, List<ElementId> elementsAll, List<ElementId> elementValues)
		{
			foreach (ElementId elementId in elementsAll)
			{
				ElementType elementType = this.doc.GetElement(elementId) as ElementType;
				List<CompoundStructureLayer> allLayers = this.GetAllLayers(new List<Element>
				{
					elementType
				});
				foreach (CompoundStructureLayer compoundStructureLayer in compoundLayers)
				{
					Material material = this.doc.GetElement(compoundStructureLayer.MaterialId) as Material;
					foreach (CompoundStructureLayer compoundStructureLayer2 in allLayers)
					{
						try
						{
							Material material2 = this.doc.GetElement(compoundStructureLayer2.MaterialId) as Material;
							if (!(material.Name != material2.Name))
							{
								if (!elementValues.Contains(elementId))
								{
									string[] items = new string[]
									{
										elementType.Name
									};
									ListViewItem listViewItem = new ListViewItem(items);
									listViewItem.Tag = elementType;
									this.listViewValues.Items.Add(listViewItem);
									elementValues.Add(elementId);
									break;
								}
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		private void CategoryToLayer()
		{
			try
			{
				this.listViewLayers.Items.Clear();
				this.listViewValues.Items.Clear();
				this.selectedCategories = new List<ElementId>();
				ListView.SelectedListViewItemCollection selectedItems = this.listViewCategory.SelectedItems;
				foreach (object obj in selectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					try
					{
						this.selectedCategory = (listViewItem.Tag as Category);
						this.selectedCategories.Add(this.selectedCategory.Id);
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
				}
				ElementMulticategoryFilter elementMulticategoryFilter = new ElementMulticategoryFilter(this.selectedCategories);
				if (this.RBAll.Checked)
				{
					this.col = new FilteredElementCollector(this.doc);
				}
				else
				{
					this.col = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id);
				}
				this.col = this.col.WherePasses(elementMulticategoryFilter).WhereElementIsNotElementType();
				this.elementTypes = (from x in this.col
				select this.doc.GetElement(x.GetTypeId())).ToList<Element>();
				List<CompoundStructureLayer> allLayers = this.GetAllLayers(this.elementTypes);
				List<ElementId> list = new List<ElementId>();
				List<CompoundStructureLayer> list2 = new List<CompoundStructureLayer>();
				foreach (CompoundStructureLayer compoundStructureLayer in allLayers)
				{
					try
					{
						if (compoundStructureLayer != null)
						{
							ElementId materialId = compoundStructureLayer.MaterialId;
							if (!list.Contains(materialId))
							{
								list.Add(materialId);
								list2.Add(compoundStructureLayer);
							}
						}
					}
					catch (Exception)
					{
					}
				}
				list2.Sort((CompoundStructureLayer x, CompoundStructureLayer y) => string.Compare(this.doc.GetElement(x.MaterialId).Name, this.doc.GetElement(y.MaterialId).Name));
				foreach (CompoundStructureLayer compoundStructureLayer2 in list2)
				{
					try
					{
						Material material = this.doc.GetElement(compoundStructureLayer2.MaterialId) as Material;
						string[] items = new string[]
						{
							material.Name
						};
						ListViewItem listViewItem2 = new ListViewItem(items);
						listViewItem2.Tag = compoundStructureLayer2;
						this.listViewLayers.Items.Add(listViewItem2);
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception ex2)
			{
				Debug.Print(ex2.Message);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000EF70 File Offset: 0x0000D170
		private void GetCategories()
		{
			try
			{
				Category category = Category.GetCategory(this.doc, BuiltInCategory.OST_Walls);
				Category category2 = Category.GetCategory(this.doc, BuiltInCategory.OST_Floors);
				Category category3 = Category.GetCategory(this.doc, BuiltInCategory.OST_Ceilings);
				Category category4 = Category.GetCategory(this.doc, BuiltInCategory.OST_Roofs);
				this.categories = new List<Category>
				{
					category,
					category2,
					category3,
					category4
				};
				foreach (Category category5 in this.categories)
				{
					try
					{
						string[] items = new string[]
						{
							category5.Name
						};
						ListViewItem listViewItem = new ListViewItem(items);
						listViewItem.Tag = category5;
						this.listViewCategory.Items.Add(listViewItem);
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Print(ex.Message);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000F090 File Offset: 0x0000D290
		private List<CompoundStructureLayer> GetAllLayers(List<Element> elements)
		{
			List<CompoundStructureLayer> list = new List<CompoundStructureLayer>();
			foreach (Element element in elements)
			{
				try
				{
					CompoundStructure compoundStructure = null;
					if (element is WallType)
					{
						WallType wallType = element as WallType;
						if (wallType != null)
						{
							compoundStructure = wallType.GetCompoundStructure();
						}
					}
					else if (element is FloorType)
					{
						FloorType floorType = element as FloorType;
						if (floorType != null)
						{
							compoundStructure = floorType.GetCompoundStructure();
						}
					}
					else if (element is CeilingType)
					{
						CeilingType ceilingType = element as CeilingType;
						if (ceilingType != null)
						{
							compoundStructure = ceilingType.GetCompoundStructure();
						}
					}
					else if (element is RoofType)
					{
						RoofType roofType = element as RoofType;
						if (roofType != null)
						{
							compoundStructure = roofType.GetCompoundStructure();
						}
					}
					if (compoundStructure != null)
					{
						List<CompoundStructureLayer> collection = compoundStructure.GetLayers().ToList<CompoundStructureLayer>();
						list.AddRange(collection);
					}
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000F188 File Offset: 0x0000D388
		private string FilterName(string parameterName)
		{
			string text = "ONES_";
			foreach (ElementId elementId in this.selectedCategories)
			{
				try
				{
					Category category = Category.GetCategory(this.doc, elementId);
					string name = category.Name;
					text = text + name + "_";
				}
				catch (Exception)
				{
				}
			}
			text += parameterName;
			return text;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000F218 File Offset: 0x0000D418
		private Color ColorFromList(int countColor)
		{
			if (this.RBPalette1.Checked)
			{
				if (countColor >= this.colorsNSS.Count)
				{
					return new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
				return this.colorsNSS[countColor];
			}
			else if (this.RBPalette2.Checked)
			{
				if (countColor >= this.colorsV.Count)
				{
					return new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
				return this.colorsV[countColor];
			}
			else
			{
				if (!this.RBPalette3.Checked)
				{
					Thread.Sleep(20);
					Random random = new Random();
					return new Color((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
				}
				if (countColor >= this.colorsRGB.Count)
				{
					return new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
				return this.colorsRGB[countColor];
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000F318 File Offset: 0x0000D518
		private void ColorRefresh(ListView listview)
		{
			int num = 0;
			if (this.RGBSame.Checked)
			{
				Random random = new Random();
				Color color = new Color((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
				foreach (object obj in listview.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (listViewItem.Checked)
					{
						listViewItem.BackColor = System.Drawing.Color.FromArgb((int)color.Red, (int)color.Green, (int)color.Blue);
						num++;
					}
					else
					{
						listViewItem.BackColor = System.Drawing.Color.White;
					}
				}
				return;
			}
			foreach (object obj2 in listview.Items)
			{
				ListViewItem listViewItem2 = (ListViewItem)obj2;
				if (listViewItem2.Checked)
				{
					Color color2 = this.ColorFromList(num);
					listViewItem2.BackColor = System.Drawing.Color.FromArgb((int)color2.Red, (int)color2.Green, (int)color2.Blue);
					num++;
				}
				else
				{
					listViewItem2.BackColor = System.Drawing.Color.White;
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000F480 File Offset: 0x0000D680
		private void TextColor(ListView listview)
		{
			for (int i = 0; i < listview.Items.Count; i++)
			{
				ListViewItem listViewItem = listview.Items[i];
				if (this.RBTextBlack.Checked)
				{
					listViewItem.ForeColor = System.Drawing.Color.Black;
				}
				else
				{
					listViewItem.ForeColor = System.Drawing.Color.White;
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000F4D5 File Offset: 0x0000D6D5
		private void listViewCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CategoryToLayer();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000F4E0 File Offset: 0x0000D6E0
		private void listViewLayers_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.listViewValues.Items.Clear();
			if (this.listViewLayers.SelectedItems.Count != 0)
			{
				ListView.SelectedListViewItemCollection selectedItems = this.listViewLayers.SelectedItems;
				List<ElementId> elementsAll = (from x in this.col
				select x.GetTypeId()).ToList<ElementId>();
				List<ElementId> elementValues = new List<ElementId>();
				List<CompoundStructureLayer> list = new List<CompoundStructureLayer>();
				foreach (object obj in selectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					try
					{
						CompoundStructureLayer item = listViewItem.Tag as CompoundStructureLayer;
						list.Add(item);
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
				}
				this.LayerToValue(list, elementsAll, elementValues);
				this.ColorRefresh(this.listViewValues);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000F5EC File Offset: 0x0000D7EC
		private void buttonFilter_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.selectedCategory == null)
				{
					RevitTaskDialog.Show("Error", "Please Select a Category");
				}
				else if (this.listViewValues.CheckedItems.Count == 0)
				{
					RevitTaskDialog.Show("Error", "Please Select a Type");
				}
				else
				{
					using (Transaction transaction = new Transaction(this.doc, "Add View Filters"))
					{
						transaction.Start();
						List<ElementId> list = new List<ElementId>();
						ListView.CheckedListViewItemCollection checkedItems = this.listViewValues.CheckedItems;
						foreach (object obj in checkedItems)
						{
							ListViewItem listViewItem = (ListViewItem)obj;
							try
							{
								ElementType elementType = listViewItem.Tag as ElementType;
								Parameter parameter = elementType.get_Parameter(BuiltInParameter.SYMBOL_NAME_PARAM);
								string filterName = this.FilterName("Type Name_" + elementType.Name);
								System.Drawing.Color backColor = listViewItem.BackColor;
								Color color = new Color(backColor.R, backColor.G, backColor.B);
								OverrideGraphicSettings overrideGraphicSettings = this.OverrideGraphic(color);
								IEnumerable<ParameterFilterElement> source = from ParameterFilterElement x in new FilteredElementCollector(this.doc).OfClass(typeof(ParameterFilterElement))
								where x.Name == filterName
								select x;
								ParameterFilterElement parameterFilterElement;
								if (source.Any<ParameterFilterElement>())
								{
									parameterFilterElement = source.First<ParameterFilterElement>();
								}
								else
								{
									ParameterValueProvider parameterValueProvider = new ParameterValueProvider(parameter.Id);
									FilterRule filterRule = Utils.FilterRule(parameter);
									parameterFilterElement = ParameterFilterElement.Create(this.doc, filterName, this.selectedCategories);
									ElementParameterFilter elementFilter = new ElementParameterFilter(filterRule);
									parameterFilterElement.SetElementFilter(elementFilter);
								}
								if (parameterFilterElement != null)
								{
									if (this.checkBoxTemplate.Checked && this.doc.ActiveView.ViewTemplateId != ElementId.InvalidElementId)
									{
										View view = this.doc.GetElement(this.doc.ActiveView.ViewTemplateId) as View;
										view.AddFilter(parameterFilterElement.Id);
										view.SetFilterVisibility(parameterFilterElement.Id, true);
										view.SetFilterOverrides(parameterFilterElement.Id, overrideGraphicSettings);
									}
									else
									{
										this.doc.ActiveView.AddFilter(parameterFilterElement.Id);
										this.doc.ActiveView.SetFilterVisibility(parameterFilterElement.Id, true);
										this.doc.ActiveView.SetFilterOverrides(parameterFilterElement.Id, overrideGraphicSettings);
									}
								}
							}
							catch (Exception ex)
							{
								Debug.Print(ex.Message);
							}
						}
						transaction.Commit();
						base.Close();
					}
				}
			}
			catch (Exception ex2)
			{
				Debug.Print(ex2.Message);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000F908 File Offset: 0x0000DB08
		private void buttonOverride_Click(object sender, EventArgs e)
		{
			if (this.selectedCategory == null)
			{
				RevitTaskDialog.Show("Error", "Please Select a Category");
				return;
			}
			if (this.listViewValues.CheckedItems.Count == 0)
			{
				RevitTaskDialog.Show("Error", "Please Select a Type");
				return;
			}
			using (Transaction transaction = new Transaction(this.doc, "Override Graphics in View"))
			{
				transaction.Start();
				List<ElementId> list = new List<ElementId>();
				ListView.CheckedListViewItemCollection checkedItems = this.listViewValues.CheckedItems;
				foreach (object obj in checkedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					try
					{
						ElementType elementType = listViewItem.Tag as ElementType;
						Parameter parameter = elementType.get_Parameter(BuiltInParameter.SYMBOL_NAME_PARAM);
						System.Drawing.Color backColor = listViewItem.BackColor;
						Color color = new Color(backColor.R, backColor.G, backColor.B);
						OverrideGraphicSettings overrideGraphicSettings = this.OverrideGraphic(color);
						ParameterValueProvider parameterValueProvider = new ParameterValueProvider(parameter.Id);
						FilterRule filterRule = Utils.FilterRule(parameter);
						FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id);
						this.col = new FilteredElementCollector(this.doc);
						if (this.RBAll.Checked)
						{
							filteredElementCollector = new FilteredElementCollector(this.doc);
						}
						ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
						ElementMulticategoryFilter elementMulticategoryFilter = new ElementMulticategoryFilter(this.selectedCategories);
						filteredElementCollector.WhereElementIsNotElementType().WherePasses(elementMulticategoryFilter).WherePasses(elementParameterFilter);
						foreach (Element element in filteredElementCollector)
						{
							try
							{
								this.doc.ActiveView.SetElementOverrides(element.Id, overrideGraphicSettings);
							}
							catch (Exception)
							{
							}
						}
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
				}
				transaction.Commit();
				base.Close();
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000FB7C File Offset: 0x0000DD7C
		private void buttonShow_Click(object sender, EventArgs e)
		{
			if (this.selectedCategory == null)
			{
				RevitTaskDialog.Show("Error", "Please Select a Category");
			}
			else if (this.listViewValues.CheckedItems.Count == 0)
			{
				RevitTaskDialog.Show("Error", "Please Select Values");
			}
			else
			{
				List<ElementId> list = new List<ElementId>();
				List<ElementId> list2 = new List<ElementId>();
				ListView.CheckedListViewItemCollection checkedItems = this.listViewValues.CheckedItems;
				foreach (object obj in checkedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					try
					{
						ElementType elementType = listViewItem.Tag as ElementType;
						Parameter parameter = elementType.get_Parameter(BuiltInParameter.SYMBOL_NAME_PARAM);
						ParameterValueProvider parameterValueProvider = new ParameterValueProvider(parameter.Id);
						FilterRule filterRule = Utils.FilterRule(parameter);
						FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id);
						if (this.RBAll.Checked)
						{
							filteredElementCollector = new FilteredElementCollector(this.doc);
						}
						ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
						ElementMulticategoryFilter elementMulticategoryFilter = new ElementMulticategoryFilter(this.selectedCategories);
						filteredElementCollector.WhereElementIsNotElementType().WherePasses(elementMulticategoryFilter).WherePasses(elementParameterFilter);
						list2.AddRange(filteredElementCollector.ToElementIds());
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
				}
				try
				{
					this.uidoc.Selection.SetElementIds(list2);
				}
				catch (Exception)
				{
				}
			}
			base.Close();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000FD1C File Offset: 0x0000DF1C
		private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
		{
			this.GetCategories();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000FD24 File Offset: 0x0000DF24
		private void buttonAll_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.listViewValues.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				listViewItem.Checked = true;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000FD84 File Offset: 0x0000DF84
		private void buttonNone_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.listViewValues.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				listViewItem.Checked = false;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000023A6 File Offset: 0x000005A6
		private void listViewValues_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000FDE4 File Offset: 0x0000DFE4
		private void listViewValues_ItemCheck(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000023A6 File Offset: 0x000005A6
		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000023A6 File Offset: 0x000005A6
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000023A6 File Offset: 0x000005A6
		private void radioButtonAView_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000023A6 File Offset: 0x000005A6
		private void checkBoxTemplate_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000023A6 File Offset: 0x000005A6
		private void textBoxTransparency_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000FDF4 File Offset: 0x0000DFF4
		private void trackBarTransparency_Scroll(object sender, EventArgs e)
		{
			this.textBoxTransparency.Text = (this.trackBarTransparency.Value * 10).ToString();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000FDE4 File Offset: 0x0000DFE4
		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000FDE4 File Offset: 0x0000DFE4
		private void RBPalette1_CheckedChanged(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000FDE4 File Offset: 0x0000DFE4
		private void RBPalette2_CheckedChanged(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000FDE4 File Offset: 0x0000DFE4
		private void RBPaletteRandom_CheckedChanged(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000FE22 File Offset: 0x0000E022
		private void RBTextBlack_CheckedChanged(object sender, EventArgs e)
		{
			this.TextColor(this.listViewValues);
		}

		// Token: 0x0400007E RID: 126
		private List<Category> categories;

		// Token: 0x0400007F RID: 127
		private FilteredElementCollector col;

		// Token: 0x04000080 RID: 128
		private UIDocument uidoc;

		// Token: 0x04000081 RID: 129
		private Document doc;

		// Token: 0x04000082 RID: 130
		private Category selectedCategory;

		// Token: 0x04000083 RID: 131
		private List<ElementId> selectedCategories = new List<ElementId>();

		// Token: 0x04000084 RID: 132
		private List<CompoundStructureLayer> selectedLayers = new List<CompoundStructureLayer>();

		// Token: 0x04000085 RID: 133
		private List<Element> elementTypes = new List<Element>();

		// Token: 0x04000086 RID: 134
		private List<Color> colorsRGB = new List<Color>();

		// Token: 0x04000087 RID: 135
		private List<Color> colorsNSS = new List<Color>();

		// Token: 0x04000088 RID: 136
		private List<Color> colorsV = new List<Color>();
	}
}



