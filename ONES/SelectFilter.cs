using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace ONES
{
    // Token: 0x02000032 RID: 50
    [Transaction(TransactionMode.Manual)]
    public class SelectFilter : IExternalCommand
    {
        // Token: 0x06000108 RID: 264 RVA: 0x00015E58 File Offset: 0x00014058
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Autodesk.Revit.DB.View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SelectFilterForm selectFilterForm = new SelectFilterForm(activeUIDocument);
            DialogResult dialogResult = selectFilterForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                List<ElementId> checkedIds = selectFilterForm.checkedIds;
                activeUIDocument.Selection.SetElementIds(checkedIds);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}