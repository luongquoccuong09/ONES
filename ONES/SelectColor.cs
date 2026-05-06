using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x0200003B RID: 59
    [Transaction(TransactionMode.Manual)]
    public class SelectColor : IExternalCommand
    {
        // Token: 0x060001DB RID: 475 RVA: 0x00021CCC File Offset: 0x0001FECC
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICollection<ElementId> elementIds = selection.GetElementIds();
            if (elementIds.Count == 0)
            {
                TaskDialog.Show("Revit", "You haven't selected any element.");
            }

            List<OverrideGraphicSettings> list = new List<OverrideGraphicSettings>();
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    list.Add(activeView.GetElementOverrides(elementId));
                }
                catch (Exception)
                {
                }
            }

            ICollection<ElementId> collection = new FilteredElementCollector(document, activeView.Id).WhereElementIsNotElementType().ToElementIds();
            List<ElementId> list2 = new List<ElementId>();
            foreach (ElementId elementId2 in collection)
            {
                try
                {
                    OverrideGraphicSettings elementOverrides = activeView.GetElementOverrides(elementId2);
                    foreach (OverrideGraphicSettings overrideGraphicSettings in list)
                    {
                        if (elementOverrides.CutForegroundPatternColor.Red == overrideGraphicSettings.CutForegroundPatternColor.Red && elementOverrides.CutForegroundPatternColor.Green == overrideGraphicSettings.CutForegroundPatternColor.Green && elementOverrides.CutForegroundPatternColor.Blue == overrideGraphicSettings.CutForegroundPatternColor.Blue && elementOverrides.CutBackgroundPatternColor.Red == overrideGraphicSettings.CutBackgroundPatternColor.Red && elementOverrides.CutBackgroundPatternColor.Green == overrideGraphicSettings.CutBackgroundPatternColor.Green && elementOverrides.CutBackgroundPatternColor.Blue == overrideGraphicSettings.CutBackgroundPatternColor.Blue && elementOverrides.SurfaceForegroundPatternColor.Red == overrideGraphicSettings.SurfaceForegroundPatternColor.Red && elementOverrides.SurfaceForegroundPatternColor.Green == overrideGraphicSettings.SurfaceForegroundPatternColor.Green && elementOverrides.SurfaceForegroundPatternColor.Blue == overrideGraphicSettings.SurfaceForegroundPatternColor.Blue && elementOverrides.SurfaceBackgroundPatternColor.Red == overrideGraphicSettings.SurfaceBackgroundPatternColor.Red && elementOverrides.SurfaceBackgroundPatternColor.Green == overrideGraphicSettings.SurfaceBackgroundPatternColor.Green && elementOverrides.SurfaceBackgroundPatternColor.Blue == overrideGraphicSettings.SurfaceBackgroundPatternColor.Blue)
                        {
                            list2.Add(elementId2);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            selection.SetElementIds(list2);
            if (!list2.Any<ElementId>())
            {
                selection.SetElementIds(elementIds);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}