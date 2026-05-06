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
    // Token: 0x02000038 RID: 56
    [Transaction(TransactionMode.Manual)]
    public class TypeFilter : IExternalCommand
    {
        // Token: 0x0600016E RID: 366 RVA: 0x0001AE04 File Offset: 0x00019004
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
            TypeFilterForm typeFilterForm = new TypeFilterForm(activeUIDocument);
            typeFilterForm.ShowDialog();
            List<ElementId> checkedIds = typeFilterForm.checkedIds;
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}