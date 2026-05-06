using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x0200002F RID: 47
    [Transaction(TransactionMode.Manual)]
    public class MPlus : IExternalCommand
    {
        // Token: 0x060000FA RID: 250 RVA: 0x00015C18 File Offset: 0x00013E18
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
            ICollection<ElementId> elementIds = selection.GetElementIds();
            string tempPath = Path.GetTempPath();
            string path = Path.Combine(tempPath, "ONES_ElementIds.txt");
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                foreach (ElementId value in elementIds)
                {
                    try
                    {
                        streamWriter.WriteLine(value);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}