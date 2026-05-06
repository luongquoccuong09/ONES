using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ONES
{
    // Token: 0x0200009C RID: 156
    [Transaction(TransactionMode.Manual)]
    public class CopyFilters : IExternalCommand
    {
        // Token: 0x06000388 RID: 904 RVA: 0x000380A4 File Offset: 0x000362A4
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (document.IsFamilyDocument)
            {
                TaskDialog.Show("Family Document Error", "Copy Filters command doesn't work in a Family Document");
                stopwatch.Stop();
                Utils.ONESLogs(activeUIDocument, this.ToString() + " is tried to open in a Family Document", stopwatch);
                return Result.Failed;
            }

            CopyFiltersForm copyFiltersForm = new CopyFiltersForm(activeUIDocument);
            DialogResult dialogResult = copyFiltersForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}