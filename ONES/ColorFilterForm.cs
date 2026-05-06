using System;
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
	// Token: 0x02000085 RID: 133
	public partial class ColorFilterForm : System.Windows.Forms.Form
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x0002DC64 File Offset: 0x0002BE64
		public ColorFilterForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = _uidoc.Document;
			this.col = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id);
			this.ColorPalette();
			if (this.doc.Application.Language.ToString() == "Japanese")
			{
				this.JapaneseUI();
			}
			RadioButton rbpalette = this.RBPalette1;
			rbpalette.Text += this.colorsNSS.Count<Color>().ToString();
			RadioButton rbpalette2 = this.RBPalette2;
			rbpalette2.Text += this.colorsV.Count<Color>().ToString();
			RadioButton rbpalette3 = this.RBPalette3;
			rbpalette3.Text += this.colorsRGB.Count<Color>().ToString();
			base.AcceptButton = this.buttonSelect;
			base.CancelButton = this.buttonClose;
			base.MaximizeBox = false;
			this.groupBoxParameterRange.Visible = false;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0002DDC4 File Offset: 0x0002BFC4
		private void ColorElementsForm_Load(object sender, EventArgs e)
		{
			this.RBAView.Checked = true;
			this.RBInstance.Checked = true;
			this.RBPalette1.Checked = true;
			this.RBTextBlack.Checked = true;
			this.checkBoxHalftone.Checked = false;
			this.checkBoxLine.Checked = false;
			this.checkBoxSurface.Checked = true;
			this.checkBoxCut.Checked = true;
			this.checkBoxNest.Checked = false;
			this.RBParamAll.Checked = true;
			this.checkBoxCustomName.Checked = false;
			this.textBoxCustomName.Enabled = false;
			this.GetCategories();
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0002DE68 File Offset: 0x0002C068
		private void JapaneseUI()
		{
			this.Text = "カラーフィルタ";
			this.buttonAll.Text = "すべて選択";
			this.buttonNone.Text = "選択解除";
			this.columnHeaderCat.Text = "カテゴリ";
			this.columnHeaderPar.Text = "パラメータ";
			this.columnHeaderVal.Text = "値";
			this.groupBoxElements.Text = "要素を選択";
			this.RBAView.Text = "現在のビュー";
			this.RBAll.Text = "すべてのプロジェクト";
			this.groupBoxParameterType.Text = "パラメータタイプ";
			this.RBInstance.Text = "インスタンス";
			this.RBType.Text = "タイプ";
			this.groupBoxParameterRange.Text = "パラメータ範囲";
			this.RBParamAll.Text = "すべてのパラメータ";
			this.RBParamOrdered.Text = "順序付けられたパラメーター";
			this.groupBoxFilter.Text = "フィルタ設定";
			this.checkBoxTemplate.Text = "テンプレート";
			this.buttonFilter.Text = "フィルタ";
			this.checkBoxCustomName.Text = "カスタム名";
			this.groupBoxOverride.Text = "上書き";
			this.buttonOverride.Text = "上書き";
			this.buttonResetOverride.Text = "上書き削除";
			this.groupBoxColor.Text = "カラーオプション";
			this.RBPalette1.Text = "パレット1：";
			this.RBPalette2.Text = "パレット2：";
			this.RBPalette3.Text = "パレット3：";
			this.RBPaletteRandom.Text = "ランダム";
			this.buttonRefresh.Text = "更新";
			this.groupBoxText.Text = "テキストの色";
			this.RBTextBlack.Text = "黒";
			this.RBTextWhite.Text = "白";
			this.groupBoxGraphic.Text = "グラフィック設定";
			this.checkBoxHalftone.Text = "ハーフトーン";
			this.checkBoxLine.Text = "線";
			this.checkBoxNest.Text = "ネスト";
			this.checkBoxSurface.Text = "サーフェス";
			this.checkBoxCut.Text = "切断面";
			this.groupBoxTransparency.Text = "透過度";
			this.buttonSelect.Text = "表示";
			this.buttonClose.Text = "閉じる";
			this.filterErrorDialog = "選択したパラメータは、フィルタの作成にはサポートされていません\nグラフィックの上書きを使用するか、別のパラメータを選択してフィルタを作成してください。";
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0002E0FC File Offset: 0x0002C2FC
		private void ToolTips()
		{
			string caption = "It will create new filters of select the current filter if there is already filter with same name.\nAnd it will add filters to the current view by selected colors and settings.";
			ToolTip toolTip = new ToolTip();
			toolTip.SetToolTip(this.buttonFilter, caption);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0002E124 File Offset: 0x0002C324
		private void ColorPalette()
		{
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
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0002ECE8 File Offset: 0x0002CEE8
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

		// Token: 0x060002FA RID: 762 RVA: 0x0002ED58 File Offset: 0x0002CF58
		private void ParameterToValue(ParameterSet parameters, List<string> parameterValues)
		{
			foreach (object obj in parameters)
			{
				Parameter parameter = (Parameter)obj;
				try
				{
					if (!(parameter.Id != this.selectedParameter.Id))
					{
						string text;
						if (parameter.StorageType.Equals(3))
						{
							text = parameter.AsString();
						}
						else
						{
							text = parameter.AsValueString();
						}
						if (!parameterValues.Contains(text))
						{
							parameterValues.Add(text);
							string[] items = new string[]
							{
								text
							};
							ListViewItem listViewItem = new ListViewItem(items);
							listViewItem.Tag = parameter;
							this.listViewValues.Items.Add(listViewItem);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0002EE4C File Offset: 0x0002D04C
		private void CategoryToParameter()
		{
			try
			{
				this.listViewParameters.Items.Clear();
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
				FilteredElementCollector collector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id).WherePasses(elementMulticategoryFilter);
				if (this.RBAll.Checked)
				{
					collector = new FilteredElementCollector(this.doc).WherePasses(elementMulticategoryFilter);
				}
				List<Parameter> list = new List<Parameter>();
				if (this.RBParamAll.Checked)
				{
					list = this.GetAllParameters(collector);
				}
				else
				{
					list = this.GetOrderedParameters(collector);
				}
				List<string> list2 = new List<string>();
				List<Parameter> list3 = new List<Parameter>();
				foreach (Parameter parameter in list)
				{
					try
					{
						if (parameter != null)
						{
							InternalDefinition internalDefinition = parameter.Definition as InternalDefinition;
							string text = internalDefinition.BuiltInParameter.ToString();
							if (!text.StartsWith("FAMILY_TOP") && !text.StartsWith("FAMILY_BASE"))
							{
								string name = parameter.Definition.Name;
								if (!list2.Contains(name))
								{
									list2.Add(name);
									list3.Add(parameter);
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
				if (this.RBParamAll.Checked)
				{
					list3.Sort((Parameter x, Parameter y) => string.Compare(x.Definition.Name, y.Definition.Name));
				}
				foreach (Parameter parameter2 in list3)
				{
					try
					{
						string[] items = new string[]
						{
							parameter2.Definition.Name
						};
						ListViewItem listViewItem2 = new ListViewItem(items);
						listViewItem2.Tag = parameter2;
						this.listViewParameters.Items.Add(listViewItem2);
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

		// Token: 0x060002FC RID: 764 RVA: 0x0002F190 File Offset: 0x0002D390
		private void GetCategories()
		{
			try
			{
				if (this.RBAll.Checked)
				{
					this.listViewParameters.Items.Clear();
					this.listViewCategory.Items.Clear();
					this.listViewValues.Items.Clear();
					this.categories = (from Category x in this.doc.Settings.Categories
					where x.AllowsBoundParameters
					select x).ToList<Category>();
					this.categories.Sort((Category x, Category y) => string.Compare(x.Name, y.Name));
					using (List<Category>.Enumerator enumerator = this.categories.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Category category = enumerator.Current;
							try
							{
								string[] items = new string[]
								{
									category.Name
								};
								ListViewItem listViewItem = new ListViewItem(items);
								listViewItem.Tag = category;
								this.listViewCategory.Items.Add(listViewItem);
							}
							catch (Exception)
							{
							}
						}
						goto IL_240;
					}
				}
				this.categories = (from x in new FilteredElementCollector(this.doc, this.doc.ActiveView.Id).ToElements()
				select x.Category).Distinct(new CategoryComparer()).ToList<Category>();
				this.categories.RemoveAll((Category item) => item == null);
				this.categories.Sort((Category x, Category y) => string.Compare(x.Name, y.Name));
				this.listViewCategory.Items.Clear();
				foreach (Category category2 in this.categories)
				{
					try
					{
						string[] items2 = new string[]
						{
							category2.Name
						};
						ListViewItem listViewItem2 = new ListViewItem(items2);
						listViewItem2.Tag = category2;
						this.listViewCategory.Items.Add(listViewItem2);
					}
					catch (Exception)
					{
					}
				}
				IL_240:;
			}
			catch (Exception ex)
			{
				Debug.Print(ex.Message);
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0002F46C File Offset: 0x0002D66C
		private List<Parameter> GetAllParameters(FilteredElementCollector collector)
		{
			List<Parameter> list = new List<Parameter>();
			if (this.RBInstance.Checked)
			{
				using (IEnumerator<Element> enumerator = collector.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Element element = enumerator.Current;
						try
						{
							list.AddRange(element.Parameters.Cast<Parameter>().ToList<Parameter>());
						}
						catch (Exception)
						{
						}
					}
					return list;
				}
			}
			if (this.RBType.Checked)
			{
				HashSet<ElementId> hashSet = new HashSet<ElementId>();
				foreach (Element element2 in collector)
				{
					try
					{
						hashSet.Add(element2.GetTypeId());
					}
					catch (Exception)
					{
					}
				}
				foreach (ElementId elementId in hashSet)
				{
					try
					{
						Element element3 = this.doc.GetElement(elementId);
						if (element3 != null)
						{
							IList<Parameter> collection = element3.Parameters.Cast<Parameter>().ToList<Parameter>();
							list.AddRange(collection);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			return list;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0002F5D0 File Offset: 0x0002D7D0
		private List<Parameter> GetOrderedParameters(FilteredElementCollector collector)
		{
			List<Parameter> list = new List<Parameter>();
			if (this.RBInstance.Checked)
			{
				using (IEnumerator<Element> enumerator = collector.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Element element = enumerator.Current;
						try
						{
							list.AddRange(element.GetOrderedParameters().Cast<Parameter>().ToList<Parameter>());
						}
						catch (Exception)
						{
						}
					}
					return list;
				}
			}
			if (this.RBType.Checked)
			{
				HashSet<ElementId> hashSet = new HashSet<ElementId>();
				foreach (Element element2 in collector)
				{
					try
					{
						hashSet.Add(element2.GetTypeId());
					}
					catch (Exception)
					{
					}
				}
				foreach (ElementId elementId in hashSet)
				{
					try
					{
						Element element3 = this.doc.GetElement(elementId);
						if (element3 != null)
						{
							IList<Parameter> collection = element3.GetOrderedParameters().Cast<Parameter>().ToList<Parameter>();
							list.AddRange(collection);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			return list;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0002F734 File Offset: 0x0002D934
		private void RBParamOrdered_CheckedChanged(object sender, EventArgs e)
		{
			this.CategoryToParameter();
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0002F73C File Offset: 0x0002D93C
		private string FilterName(Parameter parameter)
		{
			string text;
			if (this.checkBoxCustomName.Checked & this.textBoxCustomName.Text != "")
			{
				text = this.textBoxCustomName.Text;
			}
			else
			{
				text = "ONES_";
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
				text = text + this.selectedParameter.Definition.Name + "_";
			}
			if (parameter.StorageType.Equals(3))
			{
				text += parameter.AsString();
			}
			else
			{
				text += parameter.AsValueString();
			}
			return text;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0002F84C File Offset: 0x0002DA4C
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

		// Token: 0x06000302 RID: 770 RVA: 0x0002F94C File Offset: 0x0002DB4C
		private void ColorRefresh(ListView listview)
		{
			int num = 0;
			foreach (object obj in listview.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				if (listViewItem.Checked)
				{
					Color color = this.ColorFromList(num);
					listViewItem.BackColor = System.Drawing.Color.FromArgb((int)color.Red, (int)color.Green, (int)color.Blue);
					num++;
				}
				else
				{
					listViewItem.BackColor = System.Drawing.Color.White;
				}
			}
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0002F9E4 File Offset: 0x0002DBE4
		private void TextColor(ListView listview)
		{
			for (int i = 0; i < listview.Items.Count; i++)
			{
				ListViewItem listViewItem = listview.Items[i];
				Color color = this.ColorFromList(i);
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

		// Token: 0x06000304 RID: 772 RVA: 0x0002FA44 File Offset: 0x0002DC44
		private void FilterCheck(Parameter parameter)
		{
			try
			{
				List<ElementId> list = new List<ElementId>();
				list.Add(this.selectedCategory.Id);
				string text = this.FilterName(parameter);
				FilterRule filterRule = Utils.FilterRule(parameter);
				ParameterFilterElement parameterFilterElement = ParameterFilterElement.Create(this.doc, text, this.selectedCategories);
				ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
				bool enabled = parameterFilterElement.AllRuleParametersApplicable(elementParameterFilter);
				this.buttonFilter.Enabled = enabled;
			}
			catch (Exception ex)
			{
				this.buttonFilter.Enabled = true;
				Debug.Print(ex.Message);
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0002F734 File Offset: 0x0002D934
		private void listViewCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CategoryToParameter();
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0002FAD8 File Offset: 0x0002DCD8
		private void listViewParameters_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.listViewValues.Items.Clear();
			if (this.listViewParameters.SelectedItems.Count != 0)
			{
				ListView.SelectedListViewItemCollection selectedItems = this.listViewParameters.SelectedItems;
				List<string> parameterValues = new List<string>();
				foreach (object obj in selectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					try
					{
						this.selectedParameter = (listViewItem.Tag as Parameter);
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
				}
				ElementMulticategoryFilter elementMulticategoryFilter = new ElementMulticategoryFilter(this.selectedCategories);
				FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id).WherePasses(elementMulticategoryFilter);
				if (this.RBAll.Checked)
				{
					filteredElementCollector = new FilteredElementCollector(this.doc).WherePasses(elementMulticategoryFilter);
				}
				foreach (Element element in filteredElementCollector)
				{
					try
					{
						ParameterSet parameterSet = null;
						if (this.RBInstance.Checked)
						{
							parameterSet = element.Parameters;
						}
						else if (this.RBType.Checked)
						{
							Element element2 = this.doc.GetElement(element.GetTypeId());
							if (element2 == null)
							{
								continue;
							}
							parameterSet = element2.Parameters;
						}
						if (parameterSet != null)
						{
							this.ParameterToValue(parameterSet, parameterValues);
						}
					}
					catch (Exception)
					{
					}
				}
				this.ColorRefresh(this.listViewValues);
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0002FC8C File Offset: 0x0002DE8C
		private void buttonFilter_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.selectedCategory == null)
				{
					RevitTaskDialog.Show("Error", "Please Select a Category");
				}
				else if (this.selectedParameter == null)
				{
					RevitTaskDialog.Show("Error", "Please Select a Parameter");
				}
				else
				{
					using (Transaction transaction = new Transaction(this.doc, "Add View Filters"))
					{
						transaction.Start();
						List<ElementId> list = new List<ElementId>();
						list.Add(this.selectedCategory.Id);
						ListView.CheckedListViewItemCollection checkedItems = this.listViewValues.CheckedItems;
						bool flag = true;
						foreach (object obj in checkedItems)
						{
							ListViewItem listViewItem = (ListViewItem)obj;
							try
							{
								Parameter parameter = listViewItem.Tag as Parameter;
								string filterName = this.FilterName(parameter);
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
									ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
									flag = parameterFilterElement.AllRuleParametersApplicable(elementParameterFilter);
									if (!flag)
									{
										RevitTaskDialog.Show("Filter is not Applicable", this.filterErrorDialog);
										break;
									}
									parameterFilterElement.SetElementFilter(elementParameterFilter);
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
						if (!flag)
						{
							transaction.RollBack();
						}
						else
						{
							transaction.Commit();
							base.Close();
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Debug.Print(ex2.Message);
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0002FFC8 File Offset: 0x0002E1C8
		private void buttonOverride_Click(object sender, EventArgs e)
		{
			if (this.selectedCategory == null)
			{
				RevitTaskDialog.Show("Error", "Please Select a Category");
				return;
			}
			if (this.selectedParameter == null)
			{
				RevitTaskDialog.Show("Error", "Please Select a Parameter");
				return;
			}
			using (Transaction transaction = new Transaction(this.doc, "Override Graphics in View"))
			{
				transaction.Start();
				List<ElementId> list = new List<ElementId>();
				list.Add(this.selectedCategory.Id);
				ListView.CheckedListViewItemCollection checkedItems = this.listViewValues.CheckedItems;
				foreach (object obj in checkedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					try
					{
						Parameter parameter = listViewItem.Tag as Parameter;
						ElementId id = this.selectedParameter.Id;
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

		// Token: 0x0600030A RID: 778 RVA: 0x00030244 File Offset: 0x0002E444
		private void buttonShow_Click(object sender, EventArgs e)
		{
			if (this.selectedCategory == null)
			{
				RevitTaskDialog.Show("Error", "Please Select a Category");
				return;
			}
			if (this.selectedParameter == null)
			{
				RevitTaskDialog.Show("Error", "Please Select a Parameter");
				return;
			}
			if (this.listViewValues.CheckedItems.Count == 0)
			{
				RevitTaskDialog.Show("Error", "Please Select Values");
				return;
			}
			List<ElementId> list = new List<ElementId>();
			list.Add(this.selectedCategory.Id);
			List<ElementId> list2 = new List<ElementId>();
			ListView.CheckedListViewItemCollection checkedItems = this.listViewValues.CheckedItems;
			foreach (object obj in checkedItems)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				try
				{
					Parameter parameter = listViewItem.Tag as Parameter;
					ElementId id = this.selectedParameter.Id;
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
			base.Close();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00030404 File Offset: 0x0002E604
		private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
		{
			this.GetCategories();
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0003040C File Offset: 0x0002E60C
		private void buttonAll_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.listViewValues.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				listViewItem.Checked = true;
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0003046C File Offset: 0x0002E66C
		private void buttonNone_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.listViewValues.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				listViewItem.Checked = false;
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000304CC File Offset: 0x0002E6CC
		private void listViewValues_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x000304CC File Offset: 0x0002E6CC
		private void listViewValues_ItemCheck(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000023A6 File Offset: 0x000005A6
		private void radioButtonInstance_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000023A6 File Offset: 0x000005A6
		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0002F734 File Offset: 0x0002D934
		private void radioButtonType_CheckedChanged(object sender, EventArgs e)
		{
			this.CategoryToParameter();
		}

		// Token: 0x06000313 RID: 787 RVA: 0x000023A6 File Offset: 0x000005A6
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000023A6 File Offset: 0x000005A6
		private void radioButtonAView_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000023A6 File Offset: 0x000005A6
		private void checkBoxTemplate_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000023A6 File Offset: 0x000005A6
		private void textBoxTransparency_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000304DC File Offset: 0x0002E6DC
		private void trackBarTransparency_Scroll(object sender, EventArgs e)
		{
			this.textBoxTransparency.Text = (this.trackBarTransparency.Value * 10).ToString();
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000304CC File Offset: 0x0002E6CC
		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000304CC File Offset: 0x0002E6CC
		private void RBPalette1_CheckedChanged(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000304CC File Offset: 0x0002E6CC
		private void RBPalette2_CheckedChanged(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000304CC File Offset: 0x0002E6CC
		private void RBPaletteRandom_CheckedChanged(object sender, EventArgs e)
		{
			this.ColorRefresh(this.listViewValues);
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0003050A File Offset: 0x0002E70A
		private void RBTextBlack_CheckedChanged(object sender, EventArgs e)
		{
			this.TextColor(this.listViewValues);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00030518 File Offset: 0x0002E718
		private void checkBoxCustomName_CheckedChanged(object sender, EventArgs e)
		{
			this.textBoxCustomName.Enabled = this.checkBoxCustomName.Checked;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00030530 File Offset: 0x0002E730
		private void buttonClear_Click(object sender, EventArgs e)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(this.doc, this.doc.ActiveView.Id).WhereElementIsNotElementType();
			using (Transaction transaction = new Transaction(this.doc, "Reset Override"))
			{
				transaction.Start();
				OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
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
				transaction.Commit();
			}
		}

		// Token: 0x0400022D RID: 557
		private List<Category> categories;

		// Token: 0x0400022E RID: 558
		private FilteredElementCollector col;

		// Token: 0x0400022F RID: 559
		private UIDocument uidoc;

		// Token: 0x04000230 RID: 560
		private Document doc;

		// Token: 0x04000231 RID: 561
		private Category selectedCategory;

		// Token: 0x04000232 RID: 562
		private List<ElementId> selectedCategories = new List<ElementId>();

		// Token: 0x04000233 RID: 563
		private Parameter selectedParameter;

		// Token: 0x04000234 RID: 564
		private List<Color> colorsRGB = new List<Color>();

		// Token: 0x04000235 RID: 565
		private List<Color> colorsNSS = new List<Color>();

		// Token: 0x04000236 RID: 566
		private List<Color> colorsV = new List<Color>();

		// Token: 0x04000237 RID: 567
		private string filterErrorDialog = "Selected parameter is not supported to create a filter\nPlease use override graphics or select another parameter to create a filter/";
	}
}



