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
    // Token: 0x02000005 RID: 5
    [Transaction(TransactionMode.Manual)]
    public class AlignBottom : IExternalCommand
    {
        // Token: 0x06000015 RID: 21 RVA: 0x00002B7C File Offset: 0x00000D7C
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
                    list.Add(boundingBoxXYZ.Min.Y);
                }
                catch (Exception)
                {
                }
            }

            double num = list.Min();
            using (Transaction transaction = new Transaction(document, "Align Bottom"))
            {
                transaction.Start();
                foreach (ElementId elementId2 in elementIds)
                {
                    try
                    {
                        Element element2 = document.GetElement(elementId2);
                        BoundingBoxXYZ boundingBoxXYZ2 = element2.get_BoundingBox(activeView);
                        if (boundingBoxXYZ2.Min.Y != num)
                        {
                            XYZ xyz = new XYZ(0.0, num - boundingBoxXYZ2.Min.Y, 0.0);
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