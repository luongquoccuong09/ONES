using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000062 RID: 98
    [Transaction(TransactionMode.Manual)]
    public class OverrideNone : IExternalCommand
    {
        // Token: 0x06000245 RID: 581 RVA: 0x00025AB4 File Offset: 0x00023CB4
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICollection<ElementId> elementIds = selection.GetElementIds();
            if (elementIds.Count == 0)
            {
                TaskDialog.Show("No Selection", "Please Select Elements");
                return Result.Cancelled;
            }

            using (Transaction transaction = new Transaction(document, "Override Graphics"))
            {
                transaction.Start();
                OverrideGraphicSettings overrideGraphic = new OverrideGraphicSettings();
                foreach (ElementId elementId in elementIds)
                {
                    try
                    {
                        Element element = document.GetElement(elementId);
                        Utils.OverrideElementNested(element, activeView, overrideGraphic);
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