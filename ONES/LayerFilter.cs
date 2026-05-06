using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200001D RID: 29
    [Transaction(TransactionMode.Manual)]
    public class LayerFilter : IExternalCommand
    {
        // Token: 0x06000090 RID: 144 RVA: 0x0000DB40 File Offset: 0x0000BD40
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            LayerFilterForm layerFilterForm = new LayerFilterForm(activeUIDocument);
            DialogResult dialogResult = layerFilterForm.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}