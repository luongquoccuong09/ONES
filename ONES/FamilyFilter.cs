using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000036 RID: 54
    [Transaction(TransactionMode.Manual)]
    public class FamilyFilter : IExternalCommand
    {
        // Token: 0x0600016A RID: 362 RVA: 0x0001AD1C File Offset: 0x00018F1C
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
            FamilyFilterForm familyFilterForm = new FamilyFilterForm(activeUIDocument);
            familyFilterForm.ShowDialog();
            List<ElementId> checkedIds = familyFilterForm.checkedIds;
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}