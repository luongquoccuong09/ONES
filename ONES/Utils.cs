using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Windows;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using ExcelRange = Microsoft.Office.Interop.Excel.Range;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;
using WinRibbonPanel = Autodesk.Windows.RibbonPanel;

namespace ONES
{
	// Token: 0x0200008A RID: 138
	public class Utils
	{
		// Token: 0x06000329 RID: 809 RVA: 0x000327FC File Offset: 0x000309FC
		public static void AddSharedParameter(Autodesk.Revit.ApplicationServices.Application app, Document doc)
		{
			try
			{
				DefinitionFile definitionFile = app.OpenSharedParameterFile();
				if (definitionFile == null)
				{
					return;
				}
				DefinitionGroup definitionGroup = definitionFile.Groups.Create("ONES");
				ExternalDefinitionCreationOptions externalDefinitionCreationOptions = new ExternalDefinitionCreationOptions("Element ID", SpecTypeId.String.Text);
				Definition definition = definitionGroup.Definitions.Create(externalDefinitionCreationOptions);
				Category category = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Walls);
				CategorySet categorySet = app.Create.NewCategorySet();
				categorySet.Insert(category);
				InstanceBinding instanceBinding = app.Create.NewInstanceBinding(categorySet);
				doc.ParameterBindings.Insert(definition, instanceBinding);
			}
			catch (Exception)
			{
				RevitTaskDialog.Show("ERROR", "Failed to create a Shared Parameter: ");
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000328AC File Offset: 0x00030AAC
		public static ONES_Compound KeyToCompound(string key)
		{
			ONES_Compound ones_Compound = new ONES_Compound();
			try
			{
				string[] array = key.Split(new char[]
				{
					';'
				});
				string text = array[1];
				string[] array2 = text.Split(new char[]
				{
					'/'
				});
				string name = array[0];
				ones_Compound.Name = name;
				List<ONES_Layer> list = new List<ONES_Layer>();
				foreach (string text2 in array2)
				{
					if (!(text2 == ""))
					{
						ONES_Layer ones_Layer = new ONES_Layer();
						string[] array4 = text2.Split(new char[]
						{
							'@'
						});
						string[] array5 = array4[0].Split(new char[]
						{
							'*'
						});
						ones_Layer.Material = array5[0];
						ones_Layer.Width = Convert.ToDouble(array5[1]);
						string[] array6 = array4[1].Split(new char[]
						{
							'*'
						});
						ones_Layer.Core = array6[0];
						ones_Layer.Function = array6[1];
						ones_Layer.Structural = array6[2];
						list.Add(ones_Layer);
					}
				}
				ones_Compound.Layers = list;
			}
			catch (Exception)
			{
			}
			return ones_Compound;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000329E8 File Offset: 0x00030BE8
		public static IEnumerable<ExternalFileReference> GetLinkedFileReferences(Document _document)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(_document);
			return (from x in filteredElementCollector.OfClass(typeof(RevitLinkType))
			select x.GetExternalFileReference()).ToList<ExternalFileReference>();
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00032A38 File Offset: 0x00030C38
		public static IEnumerable<Document> GetLinkedDocuments(Document _document)
		{
			IEnumerable<ExternalFileReference> linkedFileReferences = Utils.GetLinkedFileReferences(_document);
			List<string> linkedFileNames = (from x in linkedFileReferences
			select ModelPathUtils.ConvertModelPathToUserVisiblePath(x.GetAbsolutePath())).ToList<string>();
			return from Document doc in _document.Application.Documents
			where linkedFileNames.Any((string fileName) => doc.PathName.Equals(fileName))
			select doc;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00032AA4 File Offset: 0x00030CA4
		public static void EditFamilyTypes(Document document, Family family, string name)
		{
			if (family == null)
			{
				Debug.Print("Family is null");
				return;
			}
			Document document2 = document.EditFamily(family);
			if (document2 == null)
			{
				Debug.Print("Family Document is null");
				return;
			}
			FamilyManager familyManager = document2.FamilyManager;
			if (familyManager == null)
			{
				Debug.Print("Family Manager is null");
				return;
			}
			using (Transaction transaction = new Transaction(document2, "Add Type to Family"))
			{
				transaction.Start();
				try
				{
					FamilyType familyType = familyManager.NewType(name);
				}
				catch (Exception)
				{
					Debug.Print("There is alread same Family Type name");
					return;
				}
				transaction.Commit();
				if (transaction.GetStatus() != TransactionStatus.Committed)
				{
					Debug.Print("Transaction Error");
					return;
				}
			}
			LoadOpts loadOpts = new LoadOpts();
			family = document2.LoadFamily(document, loadOpts);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00032B6C File Offset: 0x00030D6C
		public static Element SelectPickElement(UIDocument uidoc)
		{
			Document document = uidoc.Document;
			Selection selection = uidoc.Selection;
			ICollection<ElementId> elementIds = selection.GetElementIds();
			ElementId elementId = null;
			if (elementIds.Count == 0)
			{
				try
				{
					elementId = uidoc.Selection.PickObject(ObjectType.Element, null, "Select an element or ESC to reset the view").ElementId;
					goto IL_6B;
				}
				catch (Exception)
				{
					return null;
				}
			}
			if (elementIds.Count == 1)
			{
				elementId = elementIds.First<ElementId>();
			}
			else if (elementIds.Count > 1)
			{
				RevitTaskDialog.Show("Revit", "Please select only one element");
				return null;
			}
			IL_6B:
			return document.GetElement(elementId);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00032C04 File Offset: 0x00030E04
		public static void ONESLogs(UIDocument uidoc, string log, Stopwatch stopWatch)
		{
			if (Settings.Default.ONESLogsOnOff)
			{
				try
				{
					Document document = uidoc.Document;
					string oneslogsFile = Settings.Default.ONESLogsFile;
					if (File.Exists(oneslogsFile))
					{
						string text = DateTime.Now.ToString("MM/dd/yyy");
						string username = document.Application.Username;
						string text2 = DateTime.Now.ToString("HH:mm:ss");
						string text3 = string.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
						TimeSpan elapsed = stopWatch.Elapsed;
						string text4 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", new object[]
						{
							elapsed.Hours,
							elapsed.Minutes,
							elapsed.Seconds,
							elapsed.Milliseconds / 10
						});
						using (StreamWriter streamWriter = File.AppendText(oneslogsFile))
						{
							streamWriter.WriteLine(string.Concat(new string[]
							{
								log,
								";",
								username,
								";",
								text,
								";",
								text2,
								";",
								text4,
								";",
								text3
							}));
						}
						Settings @default = Settings.Default;
						int onesusage = @default.ONESUsage;
						@default.ONESUsage = onesusage + 1;
					}
				}
				catch (Exception ex)
				{
					Debug.Print(ex.Message);
				}
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00032DB8 File Offset: 0x00030FB8
		public static Worksheet ExcelWorksheet(string name)
		{
			ExcelApplication application = (ExcelApplication)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			if (application == null)
			{
				RevitTaskDialog.Show("Excel Error", "Failed to get or start Excel");
				return null;
			}
			application.Visible = true;
			Workbook workbook = application.Workbooks.Add(Missing.Value);
			bool flag = true;
			Worksheet worksheet;
			if (flag)
			{
				dynamic sheets = workbook.Sheets;
				worksheet = (Worksheet)sheets.Item[1];
			}
			else
			{
				worksheet = (application.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Worksheet);
			}
			worksheet.Name = name;
			return worksheet;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00032E5C File Offset: 0x0003105C
		public static void ExcelTitleStyle(Worksheet worksheet)
		{
			dynamic worksheetDynamic = worksheet;
			ExcelRange range = (ExcelRange)worksheetDynamic.Range["A1", "Z1"];
			range.Font.Bold = true;
			range.EntireColumn.AutoFit();
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00032E98 File Offset: 0x00031098
		public static int CompoundToExcel(Document doc, Worksheet worksheet, CompoundStructure structure, int row)
		{
			try
			{
				if (structure != null)
				{
					IList<CompoundStructureLayer> layers = structure.GetLayers();
					if (layers != null)
					{
						int num = 0;
						foreach (CompoundStructureLayer compoundStructureLayer in layers)
						{
							try
							{
								if (compoundStructureLayer.MaterialId != ElementId.InvalidElementId)
								{
									Material material = doc.GetElement(compoundStructureLayer.MaterialId) as Material;
									string name = material.Name;
									double num2 = Utils.UnitFeetToMilimeter(compoundStructureLayer.Width);
									MaterialFunctionAssignment function = compoundStructureLayer.Function;
									string text = "";
									if (function == MaterialFunctionAssignment.Structure)
									{
										text = "Structure";
									}
									else if (function == MaterialFunctionAssignment.Substrate)
									{
										text = "Substrate";
									}
									else if (function == MaterialFunctionAssignment.Finish1)
									{
										text = "Finish1";
									}
									else if (function == MaterialFunctionAssignment.Finish2)
									{
										text = "Finish2";
									}
									string text2 = "FALSE";
									int structuralMaterialIndex = structure.StructuralMaterialIndex;
									if (num == structuralMaterialIndex)
									{
										text2 = "TRUE";
									}
									try
									{
										worksheet.Cells[row, 2] = name;
										worksheet.Cells[row, 3] = num2;
										worksheet.Cells[row, 4] = text2;
										worksheet.Cells[row, 5] = text;
									}
									catch (Exception)
									{
										RevitTaskDialog.Show("Excel Interrupt Error", "Excel is interrupted either by a user or an app\nPlease wait until exporting is finished completely");
									}
									num++;
									row++;
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Print(ex.Message);
			}
			return row;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00033094 File Offset: 0x00031294
		public static string LayerFunctionToName(CompoundStructureLayer layer)
		{
			string result;
			try
			{
				MaterialFunctionAssignment function = layer.Function;
				string text = "";
				if (function == MaterialFunctionAssignment.Structure)
				{
					text = "Structure";
				}
				else if (function == MaterialFunctionAssignment.Substrate)
				{
					text = "Substrate";
				}
				else if (function == MaterialFunctionAssignment.Finish1)
				{
					text = "Finish1";
				}
				else if (function == MaterialFunctionAssignment.Finish2)
				{
					text = "Finish2";
				}
				else if (function == MaterialFunctionAssignment.Insulation)
				{
					text = "Insulation";
				}
				else if (function == MaterialFunctionAssignment.Membrane)
				{
					text = "Membrane";
				}
				else if (function == MaterialFunctionAssignment.StructuralDeck)
				{
					text = "StructuralDeck";
				}
				else
				{
					text = "None";
				}
				result = text;
			}
			catch (Exception)
			{
				result = "None";
			}
			return result;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00033130 File Offset: 0x00031330
		public static MaterialFunctionAssignment NameToLayerFunction(string funcName)
		{
			MaterialFunctionAssignment result;
			try
			{
				MaterialFunctionAssignment materialFunctionAssignment = MaterialFunctionAssignment.None;
				if (funcName == "Structure")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.Structure;
				}
				else if (funcName == "Substrate")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.Substrate;
				}
				else if (funcName == "Finish1")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.Finish1;
				}
				else if (funcName == "Finish2")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.Finish2;
				}
				else if (funcName == "Insulation")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.Insulation;
				}
				else if (funcName == "Membrane")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.Membrane;
				}
				else if (funcName == "StructuralDeck")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.StructuralDeck;
				}
				else if (funcName == "None")
				{
					materialFunctionAssignment = MaterialFunctionAssignment.None;
				}
				result = materialFunctionAssignment;
			}
			catch (Exception)
			{
				result = MaterialFunctionAssignment.None;
			}
			return result;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000331E4 File Offset: 0x000313E4
		public static void DialogList(List<string> list)
		{
			string text = "";
			foreach (string str in list)
			{
				text = text + str + "\n";
			}
			RevitTaskDialog.Show("Show Task Dialog List", text);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0003324C File Offset: 0x0003144C
		public static List<Element> IntersectingElements(Document doc, FilteredElementCollector collector, Element element, double scale = 1.0)
		{
			BoundingBoxXYZ boundingBoxXYZ = element.get_BoundingBox(doc.ActiveView);
			Outline outline = new Outline(boundingBoxXYZ.Min, boundingBoxXYZ.Max);
			outline.Scale(scale);
			BoundingBoxIntersectsFilter boundingBoxIntersectsFilter = new BoundingBoxIntersectsFilter(outline);
			collector.WherePasses(boundingBoxIntersectsFilter);
			List<Element> list = new List<Element>();
			foreach (Element item in collector)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000332D8 File Offset: 0x000314D8
		public static FilterRule FilterRule(Parameter parameter)
		{
			ParameterValueProvider parameterValueProvider = new ParameterValueProvider(parameter.Id);
			FilterRule result;
			if (parameter.StorageType == StorageType.ElementId)
			{
				FilterNumericRuleEvaluator filterNumericRuleEvaluator = new FilterNumericEquals();
				result = new FilterElementIdRule(parameterValueProvider, filterNumericRuleEvaluator, parameter.AsElementId());
			}
			else if (parameter.StorageType == StorageType.String)
			{
				result = ParameterFilterRuleFactory.CreateEqualsRule(parameter.Id, parameter.AsString());
			}
			else if (parameter.StorageType == StorageType.Integer)
			{
				FilterNumericRuleEvaluator filterNumericRuleEvaluator2 = new FilterNumericEquals();
				result = new FilterIntegerRule(parameterValueProvider, filterNumericRuleEvaluator2, parameter.AsInteger());
			}
			else
			{
				FilterNumericRuleEvaluator filterNumericRuleEvaluator3 = new FilterNumericEquals();
				result = new FilterDoubleRule(parameterValueProvider, filterNumericRuleEvaluator3, parameter.AsDouble(), 0.0001);
			}
			return result;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x000333B4 File Offset: 0x000315B4
		public static List<Curve> BoundingBoxCurve(BoundingBoxXYZ boundingBox)
		{
			XYZ xyz = new XYZ(boundingBox.Min.X, boundingBox.Min.Y, 0.0);
			XYZ xyz2 = new XYZ(boundingBox.Min.X, boundingBox.Max.Y, 0.0);
			XYZ xyz3 = new XYZ(boundingBox.Max.X, boundingBox.Max.Y, 0.0);
			XYZ xyz4 = new XYZ(boundingBox.Max.X, boundingBox.Min.Y, 0.0);
			return new List<Curve>
			{
				Line.CreateBound(xyz, xyz2),
				Line.CreateBound(xyz2, xyz3),
				Line.CreateBound(xyz3, xyz4),
				Line.CreateBound(xyz4, xyz)
			};
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00033494 File Offset: 0x00031694
		public static List<Curve> BoundingBoxCurveScaled(BoundingBoxXYZ boundingBox, double scale)
		{
			Outline outline = new Outline(boundingBox.Min, boundingBox.Max);
			outline.Scale(scale);
			XYZ xyz = new XYZ(outline.MinimumPoint.X, outline.MinimumPoint.Y, 0.0);
			XYZ xyz2 = new XYZ(outline.MinimumPoint.X, outline.MaximumPoint.Y, 0.0);
			XYZ xyz3 = new XYZ(outline.MaximumPoint.X, outline.MaximumPoint.Y, 0.0);
			XYZ xyz4 = new XYZ(outline.MaximumPoint.X, outline.MinimumPoint.Y, 0.0);
			return new List<Curve>
			{
				Line.CreateBound(xyz, xyz2),
				Line.CreateBound(xyz2, xyz3),
				Line.CreateBound(xyz3, xyz4),
				Line.CreateBound(xyz4, xyz)
			};
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00033590 File Offset: 0x00031790
		public static List<Curve> SquareCurves(XYZ xyz, double d)
		{
			XYZ xyz2 = new XYZ(xyz.X - d, xyz.Y - d, 0.0);
			XYZ xyz3 = new XYZ(xyz.X - d, xyz.Y + d, 0.0);
			XYZ xyz4 = new XYZ(xyz.X + d, xyz.Y + d, 0.0);
			XYZ xyz5 = new XYZ(xyz.X + d, xyz.Y - d, 0.0);
			return new List<Curve>
			{
				Line.CreateBound(xyz2, xyz3),
				Line.CreateBound(xyz3, xyz4),
				Line.CreateBound(xyz4, xyz5),
				Line.CreateBound(xyz5, xyz2)
			};
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00033658 File Offset: 0x00031858
		public static List<Curve> RectangleCurves(XYZ xyz, double w, double h)
		{
			XYZ xyz2 = new XYZ(xyz.X + w, xyz.Y, 0.0);
			XYZ xyz3 = new XYZ(xyz.X + w, xyz.Y - h, 0.0);
			XYZ xyz4 = new XYZ(xyz.X, xyz.Y - h, 0.0);
			return new List<Curve>
			{
				Line.CreateBound(xyz, xyz2),
				Line.CreateBound(xyz2, xyz3),
				Line.CreateBound(xyz3, xyz4),
				Line.CreateBound(xyz4, xyz)
			};
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00033700 File Offset: 0x00031900
		public static CurveArray SquareCurvesArray(XYZ xyz, double d)
		{
			XYZ xyz2 = new XYZ(xyz.X - d, xyz.Y - d, xyz.Z);
			XYZ xyz3 = new XYZ(xyz.X - d, xyz.Y + d, xyz.Z);
			XYZ xyz4 = new XYZ(xyz.X + d, xyz.Y + d, xyz.Z);
			XYZ xyz5 = new XYZ(xyz.X + d, xyz.Y - d, xyz.Z);
			CurveArray curveArray = new CurveArray();
			curveArray.Append(Line.CreateBound(xyz2, xyz3));
			curveArray.Append(Line.CreateBound(xyz3, xyz4));
			curveArray.Append(Line.CreateBound(xyz4, xyz5));
			curveArray.Append(Line.CreateBound(xyz5, xyz2));
			return curveArray;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000337C0 File Offset: 0x000319C0
		public static OverrideGraphicSettings OverrideGraphic(Document doc, Color color, bool halftone, bool lines = true, bool surface = true, bool cut = true, int transparency = 0)
		{
			FillPatternElement fillPatternElement = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement)).Cast<FillPatternElement>().First((FillPatternElement a) => a.GetFillPattern().IsSolidFill);
			ElementId solidPatternId = LinePatternElement.GetSolidPatternId();
			OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
			if (transparency > 100)
			{
				transparency = 100;
			}
			else if (transparency < 0)
			{
				transparency = 0;
			}
			if (cut)
			{
				overrideGraphicSettings.SetCutBackgroundPatternId(fillPatternElement.Id);
				overrideGraphicSettings.SetCutForegroundPatternId(fillPatternElement.Id);
				overrideGraphicSettings.SetCutForegroundPatternColor(color);
				overrideGraphicSettings.SetCutBackgroundPatternColor(color);
			}
			if (surface)
			{
				overrideGraphicSettings.SetSurfaceForegroundPatternId(fillPatternElement.Id);
				overrideGraphicSettings.SetSurfaceBackgroundPatternId(fillPatternElement.Id);
				overrideGraphicSettings.SetSurfaceForegroundPatternColor(color);
				overrideGraphicSettings.SetSurfaceBackgroundPatternColor(color);
				overrideGraphicSettings.SetSurfaceTransparency(transparency);
			}
			if (lines)
			{
				overrideGraphicSettings.SetProjectionLinePatternId(solidPatternId);
				overrideGraphicSettings.SetProjectionLineColor(color);
			}
			if (halftone)
			{
				overrideGraphicSettings.SetHalftone(true);
			}
			return overrideGraphicSettings;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000338B0 File Offset: 0x00031AB0
		public static void OverrideElementNested(Element element, View view, OverrideGraphicSettings overrideGraphic)
		{
			view.SetElementOverrides(element.Id, overrideGraphic);
			if (!Settings.Default.OverrideNest)
			{
				return;
			}
			if (element is FamilyInstance)
			{
				FamilyInstance familyInstance = element as FamilyInstance;
				ICollection<ElementId> subComponentIds = familyInstance.GetSubComponentIds();
				if (subComponentIds.Count > 0)
				{
					foreach (ElementId elementId in subComponentIds)
					{
						try
						{
							view.SetElementOverrides(elementId, overrideGraphic);
							Element element2 = view.Document.GetElement(elementId);
							FamilyInstance familyInstance2 = element2 as FamilyInstance;
							ICollection<ElementId> subComponentIds2 = familyInstance2.GetSubComponentIds();
							if (subComponentIds.Count > 0)
							{
								Utils.OverrideElementNested(element2, view, overrideGraphic);
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00033978 File Offset: 0x00031B78
		public static OverrideGraphicSettings OverrideGraphicDefault(Document doc, Color color)
		{
			bool overrideHalftone = Settings.Default.OverrideHalftone;
			bool overrideLine = Settings.Default.OverrideLine;
			bool overrideSurface = Settings.Default.OverrideSurface;
			bool overrideCut = Settings.Default.OverrideCut;
			bool overrideNest = Settings.Default.OverrideNest;
			int overrideTransparency = Settings.Default.OverrideTransparency;
			return Utils.OverrideGraphic(doc, color, overrideHalftone, overrideLine, overrideSurface, overrideCut, overrideTransparency);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000339DC File Offset: 0x00031BDC
		public static Solid SolidUnion(Element element, View view)
		{
			Solid result;
			if (element is FamilyInstance)
			{
				result = Utils.SolidOfInstanceUnion(element, view);
			}
			else
			{
				result = Utils.SolidOfElementUnion(element, view);
			}
			return result;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00033A08 File Offset: 0x00031C08
		public static List<Solid> SolidList(Element element, View view)
		{
			List<Solid> list = new List<Solid>();
			if (element is FamilyInstance)
			{
				list.AddRange(Utils.SolidOfInstanceList(element, view));
			}
			else
			{
				list.AddRange(Utils.SolidOfElementList(element, view));
			}
			return list;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00033A40 File Offset: 0x00031C40
		public static Solid SolidOfElementUnion(Element element, View view)
		{
			Solid solid = null;
			GeometryElement geometryElement = element.get_Geometry(new Options
			{
				View = view,
				ComputeReferences = true
			});
			if (geometryElement == null)
			{
				return solid;
			}
			foreach (GeometryObject geometryObject in geometryElement)
			{
				Solid solid2 = (Solid)geometryObject;
				try
				{
					if (solid2 != null & solid2.Volume != 0.0)
					{
						if (null == solid)
						{
							solid = solid2;
						}
						else
						{
							solid = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid2, BooleanOperationsType.Union);
						}
					}
				}
				catch (Exception)
				{
				}
			}
			return solid;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00033AFC File Offset: 0x00031CFC
		public static List<Solid> SolidOfElementList(Element element, View view)
		{
			List<Solid> list = new List<Solid>();
			GeometryElement geometryElement = element.get_Geometry(new Options
			{
				View = view,
				ComputeReferences = true
			});
			if (geometryElement == null)
			{
				return list;
			}
			foreach (GeometryObject geometryObject in geometryElement)
			{
				Solid solid = (Solid)geometryObject;
				try
				{
					if (solid != null & solid.Volume != 0.0)
					{
						list.Add(solid);
					}
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00033BAC File Offset: 0x00031DAC
		public static Solid SolidOfInstanceUnion(Element element, View view)
		{
			Solid solid = null;
			GeometryElement source = element.get_Geometry(new Options
			{
				View = view,
				ComputeReferences = true
			});
			GeometryInstance geometryInstance = source.FirstOrDefault<GeometryObject>() as GeometryInstance;
			List<Solid> list = new List<Solid>();
			bool flag = source.OfType<Solid>().Any<Solid>();
			if (flag)
			{
				using (IEnumerator<Solid> enumerator = source.OfType<Solid>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Solid solid2 = enumerator.Current;
						try
						{
							if (solid2 != null & solid2.Volume != 0.0)
							{
								list.Add(solid2);
							}
						}
						catch (Exception)
						{
						}
					}
					goto IL_110;
				}
			}
			GeometryElement instanceGeometry = geometryInstance.GetInstanceGeometry();
			GeometryElement symbolGeometry = geometryInstance.GetSymbolGeometry();
			foreach (Solid solid3 in instanceGeometry.OfType<Solid>())
			{
				try
				{
					if (solid3 != null & solid3.Volume != 0.0)
					{
						list.Add(solid3);
					}
				}
				catch (Exception)
				{
				}
			}
			IL_110:
			foreach (Solid solid4 in list)
			{
				if (solid4 != null & solid4.Volume != 0.0)
				{
					if (null == solid)
					{
						solid = solid4;
					}
					else
					{
						solid = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid4, BooleanOperationsType.Union);
					}
				}
			}
			return solid;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00033D70 File Offset: 0x00031F70
		public static Solid SolidOfInstanceUnionOriginal(Element element, View view)
		{
			Solid solid = null;
			Options options = new Options();
			options.View = view;
			FamilyInstance familyInstance = element as FamilyInstance;
			GeometryElement originalGeometry = familyInstance.GetOriginalGeometry(options);
			Transform transform = familyInstance.GetTransform();
			GeometryElement transformed = originalGeometry.GetTransformed(transform);
			GeometryInstance geometryInstance = transformed.FirstOrDefault<GeometryObject>() as GeometryInstance;
			List<Solid> list = new List<Solid>();
			bool flag = transformed.OfType<Solid>().Any<Solid>();
			if (flag)
			{
				using (IEnumerator<Solid> enumerator = transformed.OfType<Solid>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Solid solid2 = enumerator.Current;
						try
						{
							if (solid2 != null & solid2.Volume != 0.0)
							{
								list.Add(solid2);
							}
						}
						catch (Exception)
						{
						}
					}
					goto IL_128;
				}
			}
			GeometryElement instanceGeometry = geometryInstance.GetInstanceGeometry();
			GeometryElement symbolGeometry = geometryInstance.GetSymbolGeometry();
			foreach (Solid solid3 in instanceGeometry.OfType<Solid>())
			{
				try
				{
					if (solid3 != null & solid3.Volume != 0.0)
					{
						list.Add(solid3);
					}
				}
				catch (Exception)
				{
				}
			}
			IL_128:
			foreach (Solid solid4 in list)
			{
				if (solid4 != null & solid4.Volume != 0.0)
				{
					if (null == solid)
					{
						solid = solid4;
					}
					else
					{
						solid = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid4, BooleanOperationsType.Union);
					}
				}
			}
			return solid;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00033F4C File Offset: 0x0003214C
		public static List<Solid> SolidOfInstanceList(Element element, View view)
		{
			GeometryElement source = element.get_Geometry(new Options
			{
				View = view,
				ComputeReferences = true
			});
			GeometryInstance geometryInstance = source.FirstOrDefault<GeometryObject>() as GeometryInstance;
			List<Solid> list = new List<Solid>();
			bool flag = source.OfType<Solid>().Any<Solid>();
			if (flag)
			{
				using (IEnumerator<Solid> enumerator = source.OfType<Solid>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Solid solid = enumerator.Current;
						try
						{
							if (solid != null & solid.Volume != 0.0)
							{
								list.Add(solid);
							}
						}
						catch (Exception)
						{
						}
					}
					return list;
				}
			}
			GeometryElement instanceGeometry = geometryInstance.GetInstanceGeometry();
			GeometryElement symbolGeometry = geometryInstance.GetSymbolGeometry();
			foreach (Solid solid2 in instanceGeometry.OfType<Solid>())
			{
				try
				{
					if (solid2 != null & solid2.Volume != 0.0)
					{
						list.Add(solid2);
					}
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0003409C File Offset: 0x0003229C
		public static List<Mesh> MeshOfInstanceList(Element element, View view)
		{
			GeometryElement source = element.get_Geometry(new Options
			{
				View = view,
				ComputeReferences = true
			});
			GeometryInstance geometryInstance = source.FirstOrDefault<GeometryObject>() as GeometryInstance;
			List<Mesh> list = new List<Mesh>();
			bool flag = source.OfType<Mesh>().Any<Mesh>();
			if (flag)
			{
				using (IEnumerator<Mesh> enumerator = source.OfType<Mesh>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Mesh mesh = enumerator.Current;
						try
						{
							if (mesh != null & mesh.NumTriangles != 0)
							{
								list.Add(mesh);
							}
						}
						catch (Exception)
						{
						}
					}
					return list;
				}
			}
			GeometryElement instanceGeometry = geometryInstance.GetInstanceGeometry();
			foreach (Mesh mesh2 in instanceGeometry.OfType<Mesh>())
			{
				try
				{
					if (mesh2 != null & mesh2.NumTriangles != 0)
					{
						list.Add(mesh2);
					}
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x000341C8 File Offset: 0x000323C8
		public static List<Solid> SolidSplit(Solid solid, Element element)
		{
			List<Solid> list = new List<Solid>();
			LocationCurve locationCurve = element.Location as LocationCurve;
			Curve curve = locationCurve.Curve;
			XYZ endPoint = curve.GetEndPoint(0);
			XYZ endPoint2 = curve.GetEndPoint(1);
			XYZ xyz = new XYZ(endPoint2.X, endPoint2.Y, endPoint2.Z + 3.0);
			Plane plane = Plane.CreateByThreePoints(endPoint, endPoint2, xyz);
			Solid solid2 = BooleanOperationsUtils.CutWithHalfSpace(solid, plane);
			Solid item = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid2, BooleanOperationsType.Difference);
			list.Add(solid2);
			list.Add(item);
			return list;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00034258 File Offset: 0x00032458
		public static List<PlanarFace> PlanarFacesTop(Solid solid)
		{
			List<PlanarFace> list = new List<PlanarFace>();
			if (solid != null & solid.Volume != 0.0)
			{
				foreach (object obj in solid.Faces)
				{
					Face face = (Face)obj;
					try
					{
						if (face != null)
						{
							PlanarFace planarFace = face as PlanarFace;
							if (!(planarFace == null))
							{
								CurveArray curveArray = new CurveArray();
								if (planarFace.FaceNormal.Z > 0.0)
								{
									list.Add(planarFace);
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			return list;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00034324 File Offset: 0x00032524
		public static CurveArray CurveArraybyPlanarFace(PlanarFace planarFace)
		{
			CurveArray curveArray = new CurveArray();
			IList<CurveLoop> edgesAsCurveLoops = planarFace.GetEdgesAsCurveLoops();
			foreach (CurveLoop curveLoop in edgesAsCurveLoops)
			{
				foreach (Curve curve in curveLoop)
				{
					curveArray.Append(curve);
				}
			}
			return curveArray;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000343B4 File Offset: 0x000325B4
		public static XYZ XYZModifyZ(XYZ xyz, double z)
		{
			return new XYZ(xyz.X, xyz.Y, z);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x000343D8 File Offset: 0x000325D8
		public static Curve CurveModifyZ(Curve curve, double z)
		{
			XYZ endPoint = curve.GetEndPoint(0);
			XYZ endPoint2 = curve.GetEndPoint(1);
			XYZ xyz = new XYZ(endPoint.X, endPoint.Y, z);
			XYZ xyz2 = new XYZ(endPoint2.X, endPoint2.Y, z);
			return Line.CreateBound(xyz, xyz2);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00034428 File Offset: 0x00032628
		public static Curve CurveAddZ(Curve curve, double z)
		{
			XYZ endPoint = curve.GetEndPoint(0);
			XYZ endPoint2 = curve.GetEndPoint(1);
			XYZ xyz = new XYZ(endPoint.X, endPoint.Y, endPoint.Z + z);
			XYZ xyz2 = new XYZ(endPoint2.X, endPoint2.Y, endPoint2.Z + z);
			return Line.CreateBound(xyz, xyz2);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00034484 File Offset: 0x00032684
		public static Curve CurveSubtractZ(Curve curve, double z)
		{
			XYZ endPoint = curve.GetEndPoint(0);
			XYZ endPoint2 = curve.GetEndPoint(1);
			XYZ xyz = new XYZ(endPoint.X, endPoint.Y, endPoint.Z - z);
			XYZ xyz2 = new XYZ(endPoint2.X, endPoint2.Y, endPoint2.Z - z);
			return Line.CreateBound(xyz, xyz2);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000344E0 File Offset: 0x000326E0
		public static ModelLine ModelLineEasy(Document doc, Line line)
		{
			XYZ direction = line.Direction;
			double x = direction.X;
			double y = direction.Y;
			double z = direction.Z;
			XYZ xyz = new XYZ(z - y, x - z, y - x);
			Plane plane = Plane.CreateByNormalAndOrigin(xyz, line.GetEndPoint(0));
			SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
			return doc.Create.NewModelCurve(line, sketchPlane) as ModelLine;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0003454C File Offset: 0x0003274C
		public static double FaceCurveDistance(Face face, XYZ xyz)
		{
			IList<CurveLoop> edgesAsCurveLoops = face.GetEdgesAsCurveLoops();
			List<double> list = new List<double>();
			foreach (CurveLoop curveLoop in edgesAsCurveLoops)
			{
				foreach (Curve curve in curveLoop)
				{
					try
					{
						list.Add(curve.Distance(xyz));
					}
					catch (Exception)
					{
					}
				}
			}
			return list.Min();
		}

		// Token: 0x06000351 RID: 849 RVA: 0x000345FC File Offset: 0x000327FC
		public static Autodesk.Windows.RibbonItem GetButton(string tabName, string panelName, string itemName)
		{
			RibbonControl ribbon = ComponentManager.Ribbon;
			foreach (RibbonTab ribbonTab in ribbon.Tabs)
			{
				if (ribbonTab.Name == tabName)
				{
					foreach (WinRibbonPanel ribbonPanel in ribbonTab.Panels)
					{
						if (ribbonPanel.Source.Title == panelName)
						{
							return ribbonPanel.FindItem(string.Concat(new string[]
							{
								"CustomCtrl_%CustomCtrl_%",
								tabName,
								"%",
								panelName,
								"%",
								itemName
							}), true);
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x000346E8 File Offset: 0x000328E8
		public static double UnitFeetToMilimeter(double input)
		{
			return input * 304.8;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x000346F5 File Offset: 0x000328F5
		public static double UnitMilimeterToFeet(double input)
		{
			return input / 304.8;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00034702 File Offset: 0x00032902
		public static double UnitRadianToDegree(double input)
		{
			return Math.Round(input * 180.0 / 3.1415926535897931, 7);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0003471F File Offset: 0x0003291F
		public static double UnitDegreeToRadian(double input)
		{
			return input * 3.1415926535897931 / 180.0;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00034736 File Offset: 0x00032936
		public static double UnitFeetCubeToMeterCube(double input)
		{
			return input * 0.0283168466;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00034743 File Offset: 0x00032943
		public static double UnitMeterCubeToFeetCube(double input)
		{
			return input / 0.0283168466;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00034750 File Offset: 0x00032950
		public static string LocalFilePath(UIApplication uiapp)
		{
			Autodesk.Revit.ApplicationServices.Application application = uiapp.Application;
			Document document = uiapp.ActiveUIDocument.Document;
			string pathName = document.PathName;
			string result = "";
			if (pathName.StartsWith("BIM"))
			{
				string versionBuild = application.VersionBuild;
				string text = versionBuild.Substring(0, 4);
				string versionName = application.VersionName;
				string text2 = document.WorksharingCentralGUID.ToString() + ".rvt";
				string userName = Environment.UserName;
				string path = string.Concat(new string[]
				{
					"C:\\Users\\",
					userName,
					"\\AppData\\Local\\Autodesk\\Revit\\",
					versionName,
					"\\CollaborationCache"
				});
				List<string> list = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList<string>();
				using (List<string>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string text3 = enumerator.Current;
						if (text3.EndsWith(text2) && !text3.EndsWith("Central Catch\\" + text2))
						{
							result = text3;
						}
					}
					return result;
				}
			}
			result = pathName;
			return result;
		}
	}
}

