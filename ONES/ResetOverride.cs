using System;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000040 RID: 64
    [Transaction(TransactionMode.Manual)]
    public class ResetOverride : IExternalCommand
    {
        // Token: 0x060001EB RID: 491 RVA: 0x00022B08 File Offset: 0x00020D08
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, activeView.Id).WhereElementIsNotElementType();
            using (Transaction transaction = new Transaction(document, "Reset Override"))
            {
                transaction.Start();
                OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
                foreach (Element element in filteredElementCollector)
                {
                    try
                    {
                        activeView.SetElementOverrides(element.Id, overrideGraphicSettings);
                    }
                    catch (Exception)
                    {
                    }
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}