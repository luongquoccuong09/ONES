using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
    // Token: 0x0200007C RID: 124
    [Transaction(TransactionMode.Manual)]
    public class ExportAllLayers : IExternalCommand
    {
        // Token: 0x060002C6 RID: 710 RVA: 0x0002AE14 File Offset: 0x00029014
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<WallType> list = (
                from x in new FilteredElementCollector(document).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_Walls).OfType<WallType>()orderby x.Name
                select x).ToList<WallType>();
            List<CeilingType> list2 = (
                from x in new FilteredElementCollector(document).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_Ceilings).OfType<CeilingType>()orderby x.Name
                select x).ToList<CeilingType>();
            List<FloorType> list3 = (
                from x in new FilteredElementCollector(document).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_Floors).OfType<FloorType>()orderby x.Name
                select x).ToList<FloorType>();
            List<CompoundStructure> list4 = new List<CompoundStructure>();
            ExcelApplication application3 = (ExcelApplication)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            if (application3 == null)
            {
                RevitTaskDialog.Show("Excel Error", "Failed to get or start Excel");
                return Result.Failed;
            }

            application3.Visible = true;
            Workbook workbook = application3.Workbooks.Add(Missing.Value);
            dynamic sheets = workbook.Sheets;
            Worksheet worksheet = (Worksheet)sheets.Item[1];
            Worksheet worksheet2 = application3.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Worksheet;
            Worksheet worksheet3 = application3.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Worksheet;
            worksheet.Name = "Walls";
            worksheet2.Name = "Ceilings";
            worksheet3.Name = "Floors";
            int num = 2;
            int num2 = 2;
            int num3 = 2;
            this.SheetHeader(worksheet);
            list4 = new List<CompoundStructure>();
            foreach (WallType wallType in list)
            {
                CompoundStructure compoundStructure = wallType.GetCompoundStructure();
                if (compoundStructure != null)
                {
                    worksheet.Cells[num, 1] = wallType.Name;
                    num = this.ExportCompound(document, compoundStructure, worksheet, num);
                }

                num++;
            }

            Utils.ExcelTitleStyle(worksheet);
            this.SheetHeader(worksheet2);
            list4 = new List<CompoundStructure>();
            foreach (CeilingType ceilingType in list2)
            {
                CompoundStructure compoundStructure2 = ceilingType.GetCompoundStructure();
                if (compoundStructure2 != null)
                {
                    worksheet2.Cells[num2, 1] = ceilingType.Name;
                    num2 = this.ExportCompound(document, compoundStructure2, worksheet2, num2);
                }

                num2++;
            }

            Utils.ExcelTitleStyle(worksheet2);
            this.SheetHeader(worksheet3);
            list4 = new List<CompoundStructure>();
            foreach (FloorType floorType in list3)
            {
                CompoundStructure compoundStructure3 = floorType.GetCompoundStructure();
                if (compoundStructure3 != null)
                {
                    worksheet3.Cells[num3, 1] = floorType.Name;
                    num3 = this.ExportCompound(document, compoundStructure3, worksheet3, num3);
                }

                num3++;
            }

            Utils.ExcelTitleStyle(worksheet3);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x060002C7 RID: 711 RVA: 0x0002B1D0 File Offset: 0x000293D0
        private void ExportCompounds(Document doc, List<CompoundStructure> structures, Worksheet worksheet)
        {
            int num = 2;
            foreach (CompoundStructure compoundStructure in structures)
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
                                Material material = doc.GetElement(compoundStructureLayer.MaterialId) as Material;
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
                            }

                            num2++;
                            num++;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                num++;
            }
        }

        // Token: 0x060002C8 RID: 712 RVA: 0x0002B3D8 File Offset: 0x000295D8
        private int ExportCompound(Document doc, CompoundStructure structure, Worksheet worksheet, int row)
        {
            IList<CompoundStructureLayer> layers = structure.GetLayers();
            if (layers != null)
            {
                int num = 0;
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
                            Material material = doc.GetElement(compoundStructureLayer.MaterialId) as Material;
                            text = material.Name;
                        }

                        double num2 = Utils.UnitFeetToMilimeter(compoundStructureLayer.Width);
                        string text2 = Utils.LayerFunctionToName(compoundStructureLayer);
                        string text3 = "FALSE";
                        int structuralMaterialIndex = structure.StructuralMaterialIndex;
                        if (num == structuralMaterialIndex)
                        {
                            text3 = "TRUE";
                        }

                        string text4 = "FALSE";
                        if (structure.IsCoreLayer(num))
                        {
                            text4 = "TRUE";
                        }

                        try
                        {
                            worksheet.Cells[row, 2] = text;
                            worksheet.Cells[row, 3] = num2;
                            worksheet.Cells[row, 4] = text4;
                            worksheet.Cells[row, 5] = text2;
                            worksheet.Cells[row, 6] = text3;
                        }
                        catch (Exception)
                        {
                        }

                        num++;
                        row++;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return row;
        }

        // Token: 0x060002C9 RID: 713 RVA: 0x0002B58C File Offset: 0x0002978C
        private void SheetHeader(Worksheet worksheet)
        {
            worksheet.Cells[1, 1] = "NAME";
            worksheet.Cells[1, 2] = "LAYER";
            worksheet.Cells[1, 3] = "WIDTH";
            worksheet.Cells[1, 4] = "STRUCTURAL";
            worksheet.Cells[1, 5] = "FUNCTION";
        }
    }
}
