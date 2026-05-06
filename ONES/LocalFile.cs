using System;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000030 RID: 48
    [Transaction(TransactionMode.Manual)]
    public class LocalFile : IExternalCommand
    {
        // Token: 0x060000FC RID: 252 RVA: 0x00015D0C File Offset: 0x00013F0C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string str = Utils.LocalFilePath(application);
            string arguments = "/select, \"" + str + "\"";
            Process.Start("explorer.exe", arguments);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}