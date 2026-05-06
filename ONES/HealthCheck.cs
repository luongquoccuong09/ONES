using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000090 RID: 144
    [Transaction(TransactionMode.Manual)]
    public class HealthCheck : IExternalCommand
    {
        // Token: 0x06000370 RID: 880 RVA: 0x00036948 File Offset: 0x00034B48
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            HealthCheckForm healthCheckForm = new HealthCheckForm(application);
            DialogResult dialogResult = healthCheckForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}