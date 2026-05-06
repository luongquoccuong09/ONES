using System;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000064 RID: 100
    [Transaction(TransactionMode.Manual)]
    public class Empty : IExternalCommand
    {
        // Token: 0x06000249 RID: 585 RVA: 0x00025D08 File Offset: 0x00023F08
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Element element;
            try
            {
                if (Utils.SelectPickElement(activeUIDocument) == null)
                {
                    return Result.Failed;
                }

                element = Utils.SelectPickElement(activeUIDocument);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return Result.Failed;
            }

            Element element2 = document.GetElement(element.GetTypeId());
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}