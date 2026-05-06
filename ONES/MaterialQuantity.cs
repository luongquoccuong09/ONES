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
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using ExcelRange = Microsoft.Office.Interop.Excel.Range;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
    // Token: 0x02000012 RID: 18
    [Transaction(TransactionMode.Manual)]
    public class MaterialQuantity : IExternalCommand
    {
        // Token: 0x0600004B RID: 75 RVA: 0x000099A4 File Offset: 0x00007BA4
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICollection<ElementId> elementIds = selection.GetElementIds();
            ExcelApplication application3 = (ExcelApplication)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            if (application3 == null)
            {
                RevitTaskDialog.Show("Excel Error", "Failed to get or start Excel");
                return Result.Failed;
            }

            application3.Visible = true;
            Workbook workbook = application3.Workbooks.Add(Missing.Value);
            bool flag = true;
            Worksheet worksheet;
            if (flag)
            {
                dynamic sheets = workbook.Sheets;
                worksheet = (Worksheet)sheets.Item[1];
            }
            else
            {
                worksheet = (application3.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Worksheet);
            }

            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType();
            worksheet.Name = "By Material";
            Dictionary<ElementId, double> dictionary = new Dictionary<ElementId, double>();
            foreach (Element element in filteredElementCollector)
            {
                foreach (ElementId elementId in element.GetMaterialIds(false))
                {
                    double num = Utils.UnitFeetCubeToMeterCube(element.GetMaterialVolume(elementId));
                    if (num != 0.0)
                    {
                        if (dictionary.ContainsKey(elementId))
                        {
                            Dictionary<ElementId, double> dictionary2 = dictionary;
                            ElementId key = elementId;
                            dictionary2[key] += num;
                        }
                        else
                        {
                            dictionary.Add(elementId, num);
                        }
                    }
                }
            }

            int num2 = 2;
            foreach (ElementId elementId2 in dictionary.Keys)
            {
                Element element2 = document.GetElement(elementId2);
                worksheet.Cells[num2, 1] = element2.Name;
                worksheet.Cells[num2, 2] = dictionary[elementId2];
                num2++;
            }

            worksheet = (application3.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Worksheet);
            worksheet.Name = "By Type";
            worksheet.Cells[1, 1] = "Category";
            worksheet.Cells[1, 2] = "Family";
            worksheet.Cells[1, 3] = "Type";
            worksheet.Cells[1, 4] = "Material";
            worksheet.Cells[1, 5] = "Volume (m3)";
            worksheet.Cells[1, 6] = "Count";
            num2 = 2;
            List<BuiltInCategory> list = new List<BuiltInCategory>();
            List<BuiltInCategory> list2 = new List<BuiltInCategory>();
            list.Add(BuiltInCategory.OST_StructuralFraming);
            list.Add(BuiltInCategory.OST_StructuralColumns);
            list.Add(BuiltInCategory.OST_StructuralFoundation);
            list2.Add(BuiltInCategory.OST_Floors);
            list2.Add(BuiltInCategory.OST_Walls);
            foreach (BuiltInCategory category in list)
            {
                num2 = MaterialQuantity.ExportFamilyCategory(document, category, worksheet, num2);
            }

            foreach (BuiltInCategory category2 in list2)
            {
                num2 = MaterialQuantity.ExportSystemCategory(document, category2, worksheet, num2);
            }

            dynamic worksheetDynamic = worksheet;
            ExcelRange range = (ExcelRange)worksheetDynamic.Range["A1", "Z1"];
            range.Font.Bold = true;
            range.EntireColumn.AutoFit();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x0600004C RID: 76 RVA: 0x00009E24 File Offset: 0x00008024
        private static int ExportFamilyCategory(Document doc, BuiltInCategory category, Worksheet worksheet, int i)
        {
            FilteredElementCollector source = new FilteredElementCollector(doc).OfCategory(category).WhereElementIsNotElementType();
            List<List<FamilyInstance>> list = (
                from FamilyInstance x in source
                orderby x.Symbol.FamilyName
                orderby x.Symbol.Name
                group x by x.Symbol.Id into x
                    select x.ToList<FamilyInstance>()).ToList<List<FamilyInstance>>();
            foreach (List<FamilyInstance> list2 in list)
            {
                double num = 0.0;
                worksheet.Cells[i, 1] = list2.FirstOrDefault<FamilyInstance>().Category.Name;
                worksheet.Cells[i, 2] = list2.FirstOrDefault<FamilyInstance>().Symbol.FamilyName;
                worksheet.Cells[i, 3] = list2.FirstOrDefault<FamilyInstance>().Symbol.Name;
                foreach (FamilyInstance familyInstance in list2)
                {
                    foreach (ElementId elementId in familyInstance.GetMaterialIds(false))
                    {
                        num += Utils.UnitFeetCubeToMeterCube(familyInstance.GetMaterialVolume(elementId));
                    }
                }

                worksheet.Cells[i, 5] = num;
                worksheet.Cells[i, 6] = list2.Count;
                i++;
            }

            return i;
        }

        // Token: 0x0600004D RID: 77 RVA: 0x0000A094 File Offset: 0x00008294
        private static int ExportSystemCategory(Document doc, BuiltInCategory category, Worksheet worksheet, int i)
        {
            FilteredElementCollector source = new FilteredElementCollector(doc).OfCategory(category).WhereElementIsElementType();
            IOrderedEnumerable<Element> orderedEnumerable =
                from x in source
                orderby x.Name
                select x;
            using (IEnumerator<Element> enumerator = orderedEnumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Element type = enumerator.Current;
                    double num = 0.0;
                    worksheet.Cells[i, 1] = type.Category.Name;
                    worksheet.Cells[i, 2] = "System Family";
                    worksheet.Cells[i, 3] = type.Name;
                    IEnumerable<Element> enumerable =
                        from x in new FilteredElementCollector(doc).OfCategory(category).WhereElementIsNotElementType()
                        where doc.GetElement(x.Id).Name.Equals(type.Name)select x;
                    foreach (Element element in enumerable)
                    {
                        foreach (ElementId elementId in element.GetMaterialIds(false))
                        {
                            num += Utils.UnitFeetCubeToMeterCube(element.GetMaterialVolume(elementId));
                        }
                    }

                    worksheet.Cells[i, 5] = num;
                    worksheet.Cells[i, 6] = enumerable.Count<Element>();
                    i++;
                }
            }

            return i;
        }

        // Token: 0x020000B1 RID: 177
        private class QuantityFamily
        {
            // Token: 0x1700005A RID: 90
            // (get) Token: 0x060003C8 RID: 968 RVA: 0x000383E1 File Offset: 0x000365E1
            // (set) Token: 0x060003C9 RID: 969 RVA: 0x000383E9 File Offset: 0x000365E9
            public string FamilyName { get; set; }
            // Token: 0x1700005B RID: 91
            // (get) Token: 0x060003CA RID: 970 RVA: 0x000383F2 File Offset: 0x000365F2
            // (set) Token: 0x060003CB RID: 971 RVA: 0x000383FA File Offset: 0x000365FA
            public string SymbolName { get; set; }
            // Token: 0x1700005C RID: 92
            // (get) Token: 0x060003CC RID: 972 RVA: 0x00038403 File Offset: 0x00036603
            // (set) Token: 0x060003CD RID: 973 RVA: 0x0003840B File Offset: 0x0003660B
            public double Count { get; set; }
            // Token: 0x1700005D RID: 93
            // (get) Token: 0x060003CE RID: 974 RVA: 0x00038414 File Offset: 0x00036614
            // (set) Token: 0x060003CF RID: 975 RVA: 0x0003841C File Offset: 0x0003661C
            public double Volume { get; set; }
        }
    }
}
