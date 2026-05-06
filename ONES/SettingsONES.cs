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
    // Token: 0x02000076 RID: 118
    [Transaction(TransactionMode.Manual)]
    public class SettingsONES : IExternalCommand
    {
        // Token: 0x06000281 RID: 641 RVA: 0x00028C28 File Offset: 0x00026E28
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SettingsForm settingsForm = new SettingsForm(activeUIDocument);
            DialogResult dialogResult = settingsForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}