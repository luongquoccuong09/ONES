using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000025 RID: 37
    [Transaction(TransactionMode.Manual)]
    public class AlignLeft : IExternalCommand
    {
        // Token: 0x060000CC RID: 204 RVA: 0x00012E98 File Offset: 0x00011098
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICollection<ElementId> elementIds = selection.GetElementIds();
            List<double> list = new List<double>();
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    Element element = document.GetElement(elementId);
                    BoundingBoxXYZ boundingBoxXYZ = element.get_BoundingBox(activeView);
                    list.Add(boundingBoxXYZ.Min.X);
                }
                catch (Exception)
                {
                }
            }

            double num = list.Min();
            using (Transaction transaction = new Transaction(document, "Align Left"))
            {
                transaction.Start();
                foreach (ElementId elementId2 in elementIds)
                {
                    try
                    {
                        Element element2 = document.GetElement(elementId2);
                        BoundingBoxXYZ boundingBoxXYZ2 = element2.get_BoundingBox(activeView);
                        if (boundingBoxXYZ2.Min.X != num)
                        {
                            XYZ xyz = new XYZ(num - boundingBoxXYZ2.Min.X, 0.0, 0.0);
                            ElementTransformUtils.MoveElement(document, elementId2, xyz);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}