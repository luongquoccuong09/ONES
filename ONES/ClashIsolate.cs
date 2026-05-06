using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000053 RID: 83
    [Transaction(TransactionMode.Manual)]
    public class ClashIsolate : IExternalCommand
    {
        // Token: 0x06000226 RID: 550 RVA: 0x00023E80 File Offset: 0x00022080
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = document.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, document.ActiveView.Id).WhereElementIsNotElementType();
                List<ElementId> list = new List<ElementId>();
                foreach (Element element in filteredElementCollector)
                {
                    try
                    {
                        FilteredElementCollector filteredElementCollector2 = new FilteredElementCollector(document, document.ActiveView.Id).WhereElementIsNotElementType().WherePasses(new ElementIntersectsElementFilter(element));
                        if (filteredElementCollector2.GetElementCount() > 0)
                        {
                            list.Add(element.Id);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                using (Transaction transaction = new Transaction(document))
                {
                    transaction.Start("Isolate Clashing Elements");
                    activeView.IsolateElementsTemporary(list);
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception", ex.Message);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}