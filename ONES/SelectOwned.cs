using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000086 RID: 134
    [Transaction(TransactionMode.Manual)]
    public class SelectOwned : IExternalCommand
    {
        // Token: 0x06000321 RID: 801 RVA: 0x0003222C File Offset: 0x0003042C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, document.ActiveView.Id).WhereElementIsNotElementType();
            List<ElementId> list = new List<ElementId>();
            foreach (Element element in filteredElementCollector)
            {
                if (WorksharingUtils.GetCheckoutStatus(document, element.Id) == null)
                {
                    list.Add(element.Id);
                }
            }

            Selection selection = activeUIDocument.Selection;
            selection.SetElementIds(list);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}