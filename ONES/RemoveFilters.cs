using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200005D RID: 93
    [Transaction(TransactionMode.Manual)]
    public class RemoveFilters : IExternalCommand
    {
        // Token: 0x0600023A RID: 570 RVA: 0x0002538C File Offset: 0x0002358C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICollection<ElementId> filters = activeView.GetFilters();
            using (Transaction transaction = new Transaction(document, "Remove Filters"))
            {
                transaction.Start();
                foreach (ElementId elementId in filters)
                {
                    activeView.RemoveFilter(elementId);
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}