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
    // Token: 0x02000087 RID: 135
    [Transaction(TransactionMode.Manual)]
    public class SelectCategory : IExternalCommand
    {
        // Token: 0x06000323 RID: 803 RVA: 0x000322F8 File Offset: 0x000304F8
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Selection selection = activeUIDocument.Selection;
            ICollection<ElementId> elementIds = selection.GetElementIds();
            if (elementIds.Count == 0)
            {
                TaskDialog.Show("Revit", "You haven't selected any element.");
            }

            List<Category> list = new List<Category>();
            List<ElementId> list2 = new List<ElementId>();
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    Element element = document.GetElement(elementId);
                    Category category = element.Category;
                    list.Add(category);
                    list2.Add(category.Id);
                }
                catch (Exception)
                {
                }
            }

            List<ElementId> list3 = new List<ElementId>();
            foreach (Category category2 in list)
            {
                try
                {
                    string name = category2.Name;
                    ElementId id = category2.Id;
                    List<Element> list4 = new FilteredElementCollector(document, document.ActiveView.Id).OfCategoryId(id).WhereElementIsNotElementType().Cast<Element>().ToList<Element>();
                    foreach (Element element2 in list4)
                    {
                        list3.Add(element2.Id);
                    }
                }
                catch (Exception)
                {
                }
            }

            selection.SetElementIds(list3);
            if (!list3.Any<ElementId>())
            {
                selection.SetElementIds(elementIds);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}