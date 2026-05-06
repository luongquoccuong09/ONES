using System;
using System.Diagnostics;
using System.IO;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200007B RID: 123
    [Transaction(TransactionMode.Manual)]
    public class LogProject : IExternalCommand
    {
        // Token: 0x060002C4 RID: 708 RVA: 0x0002AD9C File Offset: 0x00028F9C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string logsFile = Settings.Default.LogsFile;
            if (!File.Exists(logsFile))
            {
                TaskDialog.Show("Log File is missing", "Log File is missing\n" + logsFile);
                return Result.Failed;
            }

            LogProjectForm logProjectForm = new LogProjectForm(activeUIDocument);
            logProjectForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}