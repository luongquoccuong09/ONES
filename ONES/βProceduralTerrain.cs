using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
    // Token: 0x0200001C RID: 28
    [Transaction(TransactionMode.Manual)]
    public class βProceduralTerrain : IExternalCommand
    {
        // Token: 0x0600008E RID: 142 RVA: 0x0000DAD8 File Offset: 0x0000BCD8
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            βProceduralTerrainForm βProceduralTerrainForm = new βProceduralTerrainForm(activeUIDocument);
            DialogResult dialogResult = βProceduralTerrainForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}