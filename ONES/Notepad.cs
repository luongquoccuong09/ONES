using System;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200008C RID: 140
    [Transaction(TransactionMode.Manual)]
    public class Notepad : IExternalCommand
    {
        // Token: 0x0600035C RID: 860 RVA: 0x00034D68 File Offset: 0x00032F68
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Process.Start("Notepad");
            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}