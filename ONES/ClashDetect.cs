using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200000C RID: 12
    [Transaction(TransactionMode.Manual)]
    public class ClashDetect : IExternalCommand
    {
        // Token: 0x06000028 RID: 40 RVA: 0x000067F8 File Offset: 0x000049F8
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SelectFilterForm2 selectFilterForm = new SelectFilterForm2(activeUIDocument);
            DialogResult dialogResult = selectFilterForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                List<ElementId> checkedIds = selectFilterForm.checkedIds1;
                List<ElementId> checkedIds2 = selectFilterForm.checkedIds2;
                ClashDetectTreeview clashDetectTreeview = new ClashDetectTreeview(activeUIDocument, checkedIds, checkedIds2);
                clashDetectTreeview.ShowDialog();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}