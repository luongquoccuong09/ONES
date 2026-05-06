using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x0200002D RID: 45
    [Transaction(TransactionMode.Manual)]
    public class MMinus : IExternalCommand
    {
        // Token: 0x060000F6 RID: 246 RVA: 0x00015A24 File Offset: 0x00013C24
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
            List<string> list = File.ReadLines(path).ToList<string>();
            using (IEnumerator<ElementId> enumerator = elementIds.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ElementId elementId = enumerator.Current;
                    try
                    {
                        list = (
                            from l in list
                            where l != elementId.ToString()select l).ToList<string>();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            File.WriteAllLines(path, list);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}