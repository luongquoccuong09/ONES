using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000089 RID: 137
    [Transaction(TransactionMode.Manual)]
    public class SelectIntersectingElements : IExternalCommand
    {
        // Token: 0x06000327 RID: 807 RVA: 0x000326C0 File Offset: 0x000308C0
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                Element element;
                try
                {
                    if (Utils.SelectPickElement(activeUIDocument) == null)
                    {
                        return Result.Failed;
                    }

                    element = Utils.SelectPickElement(activeUIDocument);
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                    return Result.Failed;
                }

                FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, document.ActiveView.Id);
                filteredElementCollector.WherePasses(new ElementIntersectsElementFilter(element));
                List<ElementId> list = new List<ElementId>();
                foreach (Element element2 in filteredElementCollector)
                {
                    if (element2.Id != null)
                    {
                        list.Add(element2.Id);
                    }
                }

                selection.SetElementIds(list);
            }
            catch (Exception ex2)
            {
                TaskDialog.Show("Error", ex2.Message);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}