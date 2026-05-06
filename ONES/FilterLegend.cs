using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace ONES
{
    // Token: 0x02000026 RID: 38
    [Transaction(TransactionMode.Manual)]
    public class FilterLegend : IExternalCommand
    {
        // Token: 0x060000CE RID: 206 RVA: 0x00013050 File Offset: 0x00011250
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Autodesk.Revit.DB.View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilterLegendForm filterLegendForm = new FilterLegendForm(activeUIDocument);
            DialogResult dialogResult = filterLegendForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}