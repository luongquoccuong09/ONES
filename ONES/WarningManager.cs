using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000017 RID: 23
    [Transaction(TransactionMode.Manual)]
    public class WarningManager : IExternalCommand
    {
        // Token: 0x06000069 RID: 105 RVA: 0x0000BBA8 File Offset: 0x00009DA8
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            WarningManagerForm warningManagerForm = new WarningManagerForm(activeUIDocument);
            DialogResult dialogResult = warningManagerForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}