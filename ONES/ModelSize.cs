using System;
using System.Diagnostics;
using System.IO;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200008E RID: 142
    [Transaction(TransactionMode.Manual)]
    public class ModelSize : IExternalCommand
    {
        // Token: 0x06000360 RID: 864 RVA: 0x00034DF0 File Offset: 0x00032FF0
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string fileName = Utils.LocalFilePath(application);
            long length = new FileInfo(fileName).Length;
            long num = length / 1024L;
            TaskDialog.Show("Model Size", (num / 1024L).ToString() + " MB");
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}