using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200005A RID: 90
    [Transaction(TransactionMode.Manual)]
    public class IsolateUnpinned : IExternalCommand
    {
        // Token: 0x06000234 RID: 564 RVA: 0x00024F84 File Offset: 0x00023184
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                List<ElementId> list = (
                    from x in new FilteredElementCollector(document, activeView.Id).WhereElementIsNotElementType()
                    where !x.Pinned
                    select x.Id).ToList<ElementId>();
                using (Transaction transaction = new Transaction(document, "Isolate in View"))
                {
                    transaction.Start();
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