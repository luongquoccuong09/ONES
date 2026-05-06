using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using ExcelRange = Microsoft.Office.Interop.Excel.Range;

namespace ONES
{
    // Token: 0x02000066 RID: 102
    [Transaction(TransactionMode.Manual)]
    public class WarningsExport : IExternalCommand
    {
        // Token: 0x0600024D RID: 589 RVA: 0x00025E74 File Offset: 0x00024074
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Worksheet worksheet = Utils.ExcelWorksheet("Warnings");
            int num = 1;
            worksheet.Cells[num, 1] = "WARNING ID";
            worksheet.Cells[num, 2] = "WARNING DESCRIPTION";
            worksheet.Cells[num, 3] = "ELEMENT CATEGORY";
            worksheet.Cells[num, 4] = "ELEMENT ID";
            worksheet.Cells[num, 5] = "ELEMENT CREATOR";
            IList<FailureMessage> warnings = document.GetWarnings();
            List<ElementId> list = new List<ElementId>();
            foreach (FailureMessage failureMessage in warnings)
            {
                num++;
                ICollection<ElementId> failingElements = failureMessage.GetFailingElements();
                worksheet.Cells[num, 1] = failureMessage.GetFailureDefinitionId();
                worksheet.Cells[num, 2] = failureMessage.GetDescriptionText();
                worksheet.Cells[num, 3] = failureMessage.GetFailureDefinitionId();
                num++;
                foreach (ElementId item in failingElements)
                {
                    list.Add(item);
                }
            }

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (ElementId elementId in list)
            {
                try
                {
                    WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(document, elementId);
                    string creator = worksharingTooltipInfo.Creator;
                    try
                    {
                        Dictionary<string, int> dictionary2 = dictionary;
                        string key = creator;
                        int num2 = dictionary2[key];
                        dictionary2[key] = num2 + 1;
                    }
                    catch (Exception)
                    {
                        dictionary.Add(creator, 1);
                    }
                }
                catch (Exception)
                {
                }
            }

            dynamic worksheetDynamic = worksheet;
            ExcelRange range = (ExcelRange)worksheetDynamic.Range["A1", "Z1"];
            range.Font.Bold = true;
            range.EntireColumn.AutoFit();
            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
