using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace ONES
{
    // Token: 0x0200007D RID: 125
    [Transaction(TransactionMode.Manual)]
    public class ExportMaterials : IExternalCommand
    {
        // Token: 0x060002CB RID: 715 RVA: 0x0002B628 File Offset: 0x00029828
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector source = new FilteredElementCollector(document).OfClass(typeof(Material));
            List<Material> list = source.Cast<Material>().ToList<Material>();
            list.RemoveAll((Material item) => item == null);
            list.Sort((Material x, Material y) => string.Compare(x.Name, y.Name));
            Worksheet worksheet = Utils.ExcelWorksheet("Materials");
            worksheet.Cells[1, 1] = "MATERIAL NAME";
            worksheet.Cells[1, 2] = "MATERIAL ID";
            worksheet.Cells[1, 3] = "CATEGORY NAME";
            int num = 2;
            foreach (Material material in list)
            {
                try
                {
                    worksheet.Cells[num, 1] = material.Name;
                    worksheet.Cells[num, 2] = material.Id;
                    worksheet.Cells[num, 3] = material.MaterialCategory;
                    num++;
                }
                catch (Exception)
                {
                }
            }

            Utils.ExcelTitleStyle(worksheet);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}