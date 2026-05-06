using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000003 RID: 3
    [Transaction(TransactionMode.Manual)]
    public class AboutApp : IExternalCommand
    {
        // Token: 0x06000007 RID: 7 RVA: 0x0000216C File Offset: 0x0000036C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            AboutBox1 aboutBox = new AboutBox1();
            DialogResult dialogResult = aboutBox.ShowDialog();
            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}