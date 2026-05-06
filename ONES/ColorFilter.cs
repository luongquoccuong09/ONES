using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000083 RID: 131
    [Transaction(TransactionMode.Manual)]
    public class ColorFilter : IExternalCommand
    {
        // Token: 0x060002E0 RID: 736 RVA: 0x0002CDAC File Offset: 0x0002AFAC
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ColorFilterForm colorFilterForm = new ColorFilterForm(activeUIDocument);
            DialogResult dialogResult = colorFilterForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}