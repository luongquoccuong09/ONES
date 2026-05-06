using System;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000051 RID: 81
    [Transaction(TransactionMode.Manual)]
    public class SectionBoxDecrease : IExternalCommand
    {
        // Token: 0x06000222 RID: 546 RVA: 0x00023C48 File Offset: 0x00021E48
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                using (Transaction transaction = new Transaction(document, "Section Box"))
                {
                    transaction.Start();
                    View3D view3D = activeView as View3D;
                    BoundingBoxXYZ sectionBox = view3D.GetSectionBox();
                    Outline outline = new Outline(sectionBox.Min, sectionBox.Max);
                    outline.Scale(0.9);
                    BoundingBoxXYZ boundingBoxXYZ = sectionBox;
                    boundingBoxXYZ.Min = outline.MinimumPoint;
                    boundingBoxXYZ.Max = outline.MaximumPoint;
                    view3D.SetSectionBox(boundingBoxXYZ);
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception", ex.Message);
                return Result.Failed;
            }

            try
            {
                stopwatch.Stop();
                Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            }
            catch (Exception)
            {
            }

            return Result.Succeeded;
        }
    }
}