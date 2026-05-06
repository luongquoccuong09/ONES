using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000067 RID: 103
    [Transaction(TransactionMode.Manual)]
    public class WarningsIsolateUser : IExternalCommand
    {
        // Token: 0x0600024F RID: 591 RVA: 0x00026138 File Offset: 0x00024338
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            WarningsUserForm warningsUserForm = new WarningsUserForm(document);
            DialogResult dialogResult = warningsUserForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}