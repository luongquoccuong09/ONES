using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Application = Autodesk.Revit.ApplicationServices.Application;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
    // Token: 0x02000037 RID: 55
    [Transaction(TransactionMode.Manual)]
    public class ParametersElementId : IExternalCommand
    {
        // Token: 0x0600016C RID: 364 RVA: 0x0001AD94 File Offset: 0x00018F94
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ParametersForm parametersForm = new ParametersForm(activeUIDocument);
            DialogResult dialogResult = parametersForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}