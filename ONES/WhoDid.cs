using System;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200009A RID: 154
    [Transaction(TransactionMode.Manual)]
    public class WhoDid : IExternalCommand
    {
        // Token: 0x06000384 RID: 900 RVA: 0x00037E84 File Offset: 0x00036084
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
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

            ElementId id = element.Id;
            WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(document, id);
            string text = "";
            text = text + "\nCreated by : " + worksharingTooltipInfo.Creator;
            text = text + "\nCurrent Owner : " + worksharingTooltipInfo.Owner;
            text = text + "\nLast Changed by : " + worksharingTooltipInfo.LastChangedBy;
            TaskDialog.Show("Worksharing Info", text);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}