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
    // Token: 0x02000088 RID: 136
    [Transaction(TransactionMode.Manual)]
    public class SelectType : IExternalCommand
    {
        // Token: 0x06000325 RID: 805 RVA: 0x000324DC File Offset: 0x000306DC
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
            foreach (ElementId elementId in elementIds)
            {
                Element element = document.GetElement(elementId);
                ElementId typeId = element.GetTypeId();
                list.Add(typeId);
            }

            List<ElementId> list2 = new List<ElementId>();
            using (List<ElementId>.Enumerator enumerator2 = list.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    ElementId id = enumerator2.Current;
                    try
                    {
                        Element element2 = document.GetElement(id);
                        List<Element> list3 = (
                            from x in new FilteredElementCollector(document, document.ActiveView.Id).WhereElementIsNotElementType()
                            where x.GetTypeId().Equals(id)select x).ToList<Element>();
                        foreach (Element element3 in list3)
                        {
                            list2.Add(element3.Id);
                        }
                    }
                    catch (Exception)
                    {
                    }
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