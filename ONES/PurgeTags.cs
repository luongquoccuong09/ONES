using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000080 RID: 128
    [Transaction(TransactionMode.Manual)]
    public class PurgeTags : IExternalCommand
    {
        // Token: 0x060002D9 RID: 729 RVA: 0x0002C660 File Offset: 0x0002A860
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Element> list = new List<Element>();
            IList<Element> collection = new List<Element>();
            IList<Element> collection2 = new List<Element>();
            collection = (
                from IndependentTag x in new FilteredElementCollector(document).OfClass(typeof(IndependentTag))
                where x.IsOrphaned.Equals(true)select x).Cast<Element>().ToList<Element>();
            collection2 = (
                from SpatialElementTag x in new FilteredElementCollector(document).OfClass(typeof(SpatialElementTag))
                where x.IsOrphaned.Equals(true)select x).Cast<Element>().ToList<Element>();
            list.AddRange(collection);
            list.AddRange(collection2);
            PurgeForm purgeForm = new PurgeForm(application, list);
            DialogResult dialogResult = purgeForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}