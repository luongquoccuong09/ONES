using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
    // Token: 0x02000013 RID: 19
    [Transaction(TransactionMode.Manual)]
    public class ModelReport : IExternalCommand
    {
        // Token: 0x0600004F RID: 79 RVA: 0x0000A2D0 File Offset: 0x000084D0
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
            try
            {
                if (Utils.SelectPickElement(activeUIDocument) == null)
                {
                    return Result.Failed;
                }

                Element element = Utils.SelectPickElement(activeUIDocument);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return Result.Failed;
            }

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

            worksheet.Name = "Sheet1";
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
