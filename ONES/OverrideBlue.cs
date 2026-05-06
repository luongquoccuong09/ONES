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
    // Token: 0x0200005F RID: 95
    [Transaction(TransactionMode.Manual)]
    public class OverrideBlue : IExternalCommand
    {
        // Token: 0x0600023E RID: 574 RVA: 0x00025594 File Offset: 0x00023794
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

            Color color = new Color(0, 0, byte.MaxValue);
            using (Transaction transaction = new Transaction(document, "Override Graphics"))
            {
                transaction.Start();
                OverrideGraphicSettings overrideGraphic = Utils.OverrideGraphicDefault(document, color);
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