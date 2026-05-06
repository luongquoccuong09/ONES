using System;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200008D RID: 141
    [Transaction(TransactionMode.Manual)]
    public class WinCalc : IExternalCommand
    {
        // Token: 0x0600035E RID: 862 RVA: 0x00034DAC File Offset: 0x00032FAC
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Process.Start("Calc");
            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}