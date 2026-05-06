using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x0200006E RID: 110
    [Transaction(TransactionMode.Manual)]
    public class SelectFamily : IExternalCommand
    {
        // Token: 0x06000265 RID: 613 RVA: 0x000271AC File Offset: 0x000253AC
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Selection selection = activeUIDocument.Selection;
            ICollection<ElementId> elementIds = selection.GetElementIds();
            if (elementIds.Count == 0)
            {
                TaskDialog.Show("No Selection", "Please Select Elements");
                return Result.Cancelled;
            }

            HashSet<ElementId> hashSet = new HashSet<ElementId>();
            List<ElementId> list = new List<ElementId>();
            List<ElementId> list2 = new List<ElementId>();
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    Element element = document.GetElement(elementId);
                    if (element is FamilyInstance)
                    {
                        FamilyInstance familyInstance = element as FamilyInstance;
                        FamilySymbol symbol = familyInstance.Symbol;
                        string familyName = symbol.FamilyName;
                        IEnumerable<FamilyInstance> enumerable =
                            from FamilyInstance x in new FilteredElementCollector(document, document.ActiveView.Id).WhereElementIsNotElementType().OfClass(typeof(FamilyInstance))
                            where x.Symbol.FamilyName.Equals(familyName)select x;
                        foreach (FamilyInstance familyInstance2 in enumerable)
                        {
                            list2.Add(familyInstance2.Id);
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