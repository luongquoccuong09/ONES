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
    // Token: 0x02000009 RID: 9
    [Transaction(TransactionMode.Manual)]
    public class AlignRight : IExternalCommand
    {
        // Token: 0x06000020 RID: 32 RVA: 0x0000368C File Offset: 0x0000188C
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
                    XYZ xyz = new XYZ(boundingBoxXYZ.Min.X, boundingBoxXYZ.Min.Y, boundingBoxXYZ.Min.Z);
                    XYZ xyz2 = new XYZ(boundingBoxXYZ.Max.X, boundingBoxXYZ.Max.Y, boundingBoxXYZ.Max.Z);
                    list.Add(boundingBoxXYZ.Max.X);
                }
                catch (Exception)
                {
                }
            }

            double num = list.Max();
            using (Transaction transaction = new Transaction(document, "Align Right"))
            {
                transaction.Start();
                foreach (ElementId elementId2 in elementIds)
                {
                    try
                    {
                        Element element2 = document.GetElement(elementId2);
                        BoundingBoxXYZ boundingBoxXYZ2 = element2.get_BoundingBox(activeView);
                        XYZ xyz3 = new XYZ(boundingBoxXYZ2.Min.X, boundingBoxXYZ2.Min.Y, boundingBoxXYZ2.Min.Z);
                        if (boundingBoxXYZ2.Max.X != num)
                        {
                            XYZ xyz4 = new XYZ(num - boundingBoxXYZ2.Max.X, 0.0, 0.0);
                            ElementTransformUtils.MoveElement(document, elementId2, xyz4);
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