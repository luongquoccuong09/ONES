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
    // Token: 0x0200006B RID: 107
    [Transaction(TransactionMode.Manual)]
    public class Unhide : IExternalCommand
    {
        // Token: 0x0600025B RID: 603 RVA: 0x00026B44 File Offset: 0x00024D44
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View view = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector source = new FilteredElementCollector(document).WhereElementIsNotElementType();
            IEnumerable<Element> enumerable = (
                from x in source
                where x.IsHidden(view)select x).Cast<Element>();
            if (!enumerable.Any<Element>())
            {
                return Result.Failed;
            }

            ICollection<ElementId> collection = new List<ElementId>();
            using (Transaction transaction = new Transaction(document, "Unhide Elements"))
            {
                transaction.Start();
                try
                {
                    foreach (Element element in enumerable)
                    {
                        try
                        {
                            collection.Add(element.Id);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    view.UnhideElements(collection);
                }
                catch (Exception)
                {
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}