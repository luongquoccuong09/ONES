using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000059 RID: 89
    [Transaction(TransactionMode.Manual)]
    public class Pin : IExternalCommand
    {
        // Token: 0x06000232 RID: 562 RVA: 0x00024E40 File Offset: 0x00023040
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                List<Element> list = (
                    from x in new FilteredElementCollector(document, activeView.Id).WhereElementIsNotElementType()
                    where !x.Pinned
                    select x).ToList<Element>();
                using (Transaction transaction = new Transaction(document, "Isolate in View"))
                {
                    transaction.Start();
                    foreach (Element element in list)
                    {
                        try
                        {
                            element.Pinned = true;
                        }
                        catch (Exception)
                        {
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception", ex.Message);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}