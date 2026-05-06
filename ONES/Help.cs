using System;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000075 RID: 117
    [Transaction(TransactionMode.Manual)]
    public class Help : IExternalCommand
    {
        // Token: 0x0600027F RID: 639 RVA: 0x00028B54 File Offset: 0x00026D54
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string folderONES = Settings.Default.folderONES;
            string text = folderONES + "ONES User Guide EN.pdf";
            string arguments = "/A \"page=3\"";
            if (commandData.Application.Application.Language.ToString() == "Japanese")
            {
                text = folderONES + "ONES User Guide JP.pdf";
            }

            try
            {
                new Process
                {
                    StartInfo = new ProcessStartInfo(text, arguments)
                }.Start();
            }
            catch (Exception)
            {
                TaskDialog.Show("User Guide", "User Guide PDF is failed to open\n" + text);
            }

            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}