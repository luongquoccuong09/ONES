using System;
using System.Diagnostics;
using System.Reflection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200006F RID: 111
    [Transaction(TransactionMode.Manual)]
    public class Update : IExternalCommand
    {
        // Token: 0x06000267 RID: 615 RVA: 0x0002736C File Offset: 0x0002556C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                string onesdll = Settings.Default.ONESdll;
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(onesdll);
                string fileVersion = versionInfo.FileVersion;
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
                string fileVersion2 = versionInfo.FileVersion;
                if (document.Application.Language.ToString() == "Japanese")
                {
                    TaskDialog.Show("バージョン ", "現在のバージョン: " + fileVersion2 + "\nリリースバージョン: " + fileVersion);
                }
                else
                {
                    TaskDialog.Show("Version ", "Current Version: " + fileVersion2 + "\nRelease Version: " + fileVersion);
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", ex.Message);
            }

            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}