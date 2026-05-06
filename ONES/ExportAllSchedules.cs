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
    // Token: 0x02000095 RID: 149
    [Transaction(TransactionMode.Manual)]
    public class ExportAllSchedules : IExternalCommand
    {
        // Token: 0x0600037A RID: 890 RVA: 0x0003701C File Offset: 0x0003521C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ExportSchedules exportSchedules = new ExportSchedules(activeUIDocument);
            DialogResult dialogResult = exportSchedules.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}