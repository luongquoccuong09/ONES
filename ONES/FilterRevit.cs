using System;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200006D RID: 109
    [Transaction(TransactionMode.Manual)]
    public class FilterRevit : IExternalCommand
    {
        // Token: 0x06000263 RID: 611 RVA: 0x00027160 File Offset: 0x00025360
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilterRevitForm filterRevitForm = new FilterRevitForm(activeUIDocument);
            filterRevitForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}