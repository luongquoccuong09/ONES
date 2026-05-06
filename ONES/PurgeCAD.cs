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
    // Token: 0x02000073 RID: 115
    [Transaction(TransactionMode.Manual)]
    public class PurgeCAD : IExternalCommand
    {
        // Token: 0x06000278 RID: 632 RVA: 0x00028504 File Offset: 0x00026704
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Element> list = new List<Element>();
            list = (
                from ImportInstance i in new FilteredElementCollector(document).OfClass(typeof(ImportInstance))
                where !i.IsLinked
                select i).Cast<Element>().ToList<Element>();
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