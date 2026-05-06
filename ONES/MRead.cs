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
    // Token: 0x0200002E RID: 46
    [Transaction(TransactionMode.Manual)]
    public class MRead : IExternalCommand
    {
        // Token: 0x060000F8 RID: 248 RVA: 0x00015B2C File Offset: 0x00013D2C
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
            List<ElementId> list = new List<ElementId>();
            if (File.Exists(path))
            {
                string[] array = File.ReadAllLines(path);
                foreach (string value in array)
                {
                    try
                    {
                        int num = Convert.ToInt32(value);
                        ElementId item = new ElementId(num);
                        list.Add(item);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            selection.SetElementIds(list);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}