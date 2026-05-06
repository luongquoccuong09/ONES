using System;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;

namespace ONES
{
    // Token: 0x02000096 RID: 150
    [Transaction(TransactionMode.Manual)]
    public class ExportActiveSchedule : IExternalCommand
    {
        // Token: 0x0600037C RID: 892 RVA: 0x0003707C File Offset: 0x0003527C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if ((int)document.ActiveView.ViewType != 5)
            {
                TaskDialog.Show("View Type Error", "Active View is not a Schedule View");
                return (Result)(-1);
            }

            ViewSchedule viewSchedule = document.ActiveView as ViewSchedule;
            Worksheet worksheet = Utils.ExcelWorksheet("Schedules");
            string text = (31 < viewSchedule.Name.Length) ? viewSchedule.Name.Substring(0, 31) : viewSchedule.Name;
            text = text.Replace(':', '_').Replace('/', '_').Replace('?', '_').Replace('*', '_').Replace('[', '_').Replace(']', '_').Replace('\\', '_');
            if (text != null)
            {
                try
                {
                    worksheet.Name = text;
                }
                catch (Exception)
                {
                    worksheet.Name = "Schedules";
                }

                TableData tableData = viewSchedule.GetTableData();
                TableSectionData sectionData = tableData.GetSectionData(1);
                int numberOfRows = sectionData.NumberOfRows;
                int numberOfColumns = sectionData.NumberOfColumns;
                try
                {
                    for (int i = 0; i < numberOfRows; i++)
                    {
                        for (int j = 0; j < numberOfColumns; j++)
                        {
                            worksheet.Cells[i + 1, j + 1] = ((TableView)viewSchedule).GetCellText((SectionType)1, i, j);
                        }
                    }
                }
                catch (Exception)
                {
                }

                Utils.ExcelTitleStyle(worksheet);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}