using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000091 RID: 145
    [Transaction(TransactionMode.Manual)]
    public class ZoomElements : IExternalCommand
    {
        // Token: 0x06000372 RID: 882 RVA: 0x00036994 File Offset: 0x00034B94
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Selection selection = activeUIDocument.Selection;
            ICollection<ElementId> elementIds = selection.GetElementIds();
            if (elementIds.Count == 0)
            {
                try
                {
                    ElementId elementId = activeUIDocument.Selection.PickObject((ObjectType)1, "Select an element or ESC to reset the view").ElementId;
                    if (elementId != null)
                    {
                        activeUIDocument.ShowElements(elementId);
                    }

                    goto IL_69;
                }
                catch (Exception)
                {
                    goto IL_69;
                }
            }

            activeUIDocument.ShowElements(elementIds);
            IL_69:
                stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}