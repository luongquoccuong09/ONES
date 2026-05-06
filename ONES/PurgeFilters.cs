using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
    // Token: 0x0200005C RID: 92
    [Transaction(TransactionMode.Manual)]
    public class PurgeFilters : IExternalCommand
    {
        // Token: 0x06000238 RID: 568 RVA: 0x000251D4 File Offset: 0x000233D4
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Element> list = new List<Element>();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Views);
            ICollection<ElementId> collection = new FilteredElementCollector(document).OfClass(typeof(ParameterFilterElement)).ToElementIds();
            HashSet<ElementId> hashSet = new HashSet<ElementId>();
            foreach (Element element in filteredElementCollector)
            {
                View view = (View)element;
                foreach (ElementId item2 in view.GetFilters())
                {
                    hashSet.Add(item2);
                }
            }

            foreach (ElementId elementId in collection)
            {
                if (!hashSet.Contains(elementId))
                {
                    list.Add(document.GetElement(elementId));
                }
            }

            list.RemoveAll((Element item) => item == null);
            list.Sort((Element x, Element y) => string.Compare(x.Name, y.Name));
            PurgeForm purgeForm = new PurgeForm(application, list);
            DialogResult dialogResult = purgeForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
