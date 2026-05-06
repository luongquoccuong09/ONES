using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;

namespace ONES
{
    // Token: 0x02000099 RID: 153
    [Transaction(TransactionMode.Manual)]
    public class ExportWallLayers : IExternalCommand
    {
        // Token: 0x06000382 RID: 898 RVA: 0x00037A68 File Offset: 0x00035C68
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector source = new FilteredElementCollector(document).WhereElementIsElementType().OfCategory((BuiltInCategory)(-2000011));
            List<WallType> list = (
                from x in source.OfType<WallType>()orderby x.Name
                select x).ToList<WallType>();
            Worksheet worksheet = Utils.ExcelWorksheet("Walls");
            worksheet.Cells[1, 1] = "NAME";
            worksheet.Cells[1, 2] = "LAYER";
            worksheet.Cells[1, 3] = "THICKNESS";
            worksheet.Cells[1, 4] = "CORE";
            worksheet.Cells[1, 5] = "FUNCTION";
            worksheet.Cells[1, 6] = "STRUCTURAL";
            int num = 2;
            foreach (WallType wallType in list)
            {
                if (wallType.GetCompoundStructure() != null)
                {
                    try
                    {
                        worksheet.Cells[num, 1] = wallType.Name;
                    }
                    catch (Exception)
                    {
                        TaskDialog.Show("Excel Interrupt Error", "Excel is interrupted either by a user or an app\nPlease wait until exporting is finished completely");
                        return Result.Failed;
                    }

                    try
                    {
                        CompoundStructure compoundStructure = wallType.GetCompoundStructure();
                        if (compoundStructure != null)
                        {
                            IList<CompoundStructureLayer> layers = compoundStructure.GetLayers();
                            if (layers != null)
                            {
                                int num2 = 0;
                                foreach (CompoundStructureLayer compoundStructureLayer in layers)
                                {
                                    try
                                    {
                                        string text;
                                        if (compoundStructureLayer.MaterialId.IntegerValue == -1)
                                        {
                                            text = "<By_Category>";
                                        }
                                        else
                                        {
                                            Material material = document.GetElement(compoundStructureLayer.MaterialId) as Material;
                                            text = material.Name;
                                        }

                                        double num3 = Utils.UnitFeetToMilimeter(compoundStructureLayer.Width);
                                        string text2 = Utils.LayerFunctionToName(compoundStructureLayer);
                                        string text3 = "FALSE";
                                        int structuralMaterialIndex = compoundStructure.StructuralMaterialIndex;
                                        if (num2 == structuralMaterialIndex)
                                        {
                                            text3 = "TRUE";
                                        }

                                        string text4 = "FALSE";
                                        if (compoundStructure.IsCoreLayer(num2))
                                        {
                                            text4 = "TRUE";
                                        }

                                        try
                                        {
                                            worksheet.Cells[num, 2] = text;
                                            worksheet.Cells[num, 3] = num3;
                                            worksheet.Cells[num, 4] = text4;
                                            worksheet.Cells[num, 5] = text2;
                                            worksheet.Cells[num, 6] = text3;
                                        }
                                        catch (Exception)
                                        {
                                            TaskDialog.Show("Excel Interrupt Error", "Excel is interrupted either by a user or an app\nPlease wait until exporting is finished completely");
                                            return Result.Failed;
                                        }

                                        num2++;
                                        num++;
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
                        TaskDialog.Show("Error", ex.Message);
                        return Result.Failed;
                    }

                    num++;
                }
            }

            Utils.ExcelTitleStyle(worksheet);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}