using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200009B RID: 155
    [Transaction(TransactionMode.Manual)]
    public class WarningsIsolate : IExternalCommand
    {
        // Token: 0x06000386 RID: 902 RVA: 0x00037F78 File Offset: 0x00036178
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = document.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            IList<FailureMessage> warnings = document.GetWarnings();
            List<ElementId> list = new List<ElementId>();
            foreach (FailureMessage failureMessage in warnings)
            {
                ICollection<ElementId> failingElements = failureMessage.GetFailingElements();
                foreach (ElementId item in failingElements)
                {
                    list.Add(item);
                }
            }

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Isolate Warnings");
                activeView.IsolateElementsTemporary(list);
                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}