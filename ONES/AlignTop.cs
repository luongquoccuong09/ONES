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
    // Token: 0x02000008 RID: 8
    [Transaction(TransactionMode.Manual)]
    public class AlignTop : IExternalCommand
    {
        // Token: 0x0600001D RID: 29 RVA: 0x00003274 File Offset: 0x00001474
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
            List<XYZ> list = new List<XYZ>();
            List<double> list2 = new List<double>();
            XYZ upDirection = activeView.UpDirection;
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    Element element = document.GetElement(elementId);
                    BoundingBoxXYZ boundingBoxXYZ = element.get_BoundingBox(activeView);
                    XYZ xyz = new XYZ(boundingBoxXYZ.Min.X, boundingBoxXYZ.Min.Y, boundingBoxXYZ.Min.Z);
                    XYZ xyz2 = new XYZ(boundingBoxXYZ.Max.X, boundingBoxXYZ.Max.Y, boundingBoxXYZ.Max.Z);
                    XYZ xyz3 = new XYZ(xyz2.X * upDirection.X, xyz2.Y * upDirection.Y, xyz2.Z * upDirection.Z);
                    list2.Add(xyz3.X + xyz3.Y + xyz3.Z);
                    list.Add(xyz3);
                }
                catch (Exception)
                {
                }
            }

            double num = list2.Max();
            XYZ xyz4 = new XYZ();
            foreach (XYZ xyz5 in list)
            {
                if (xyz5.X + xyz5.Y + xyz5.Z == num)
                {
                    xyz4 = xyz5;
                }
            }

            using (Transaction transaction = new Transaction(document, "Align Top"))
            {
                transaction.Start();
                foreach (ElementId elementId2 in elementIds)
                {
                    try
                    {
                        Element element2 = document.GetElement(elementId2);
                        BoundingBoxXYZ boundingBoxXYZ2 = element2.get_BoundingBox(activeView);
                        XYZ xyz6 = new XYZ(boundingBoxXYZ2.Min.X, boundingBoxXYZ2.Min.Y, boundingBoxXYZ2.Min.Z);
                        XYZ xyz7 = new XYZ(boundingBoxXYZ2.Max.X, boundingBoxXYZ2.Max.Y, boundingBoxXYZ2.Max.Z);
                        XYZ xyz8 = new XYZ(xyz7.X + upDirection.X, xyz7.Y + upDirection.Y, xyz7.Z + upDirection.Z);
                        XYZ xyz9 = xyz4 - xyz8;
                        XYZ xyz10 = new XYZ(xyz9.X * upDirection.X, xyz9.Y * upDirection.Y, xyz9.Z * upDirection.Z);
                        ElementTransformUtils.MoveElement(document, elementId2, xyz10);
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

        // Token: 0x0600001E RID: 30 RVA: 0x0000361C File Offset: 0x0000181C
        private XYZ XYZMid(BoundingBoxXYZ bb)
        {
            XYZ xyz = new XYZ(bb.Min.X, bb.Min.Y, bb.Min.Z);
            XYZ xyz2 = new XYZ(bb.Max.X, bb.Max.Y, bb.Max.Z);
            return (xyz + xyz2) / 2.0;
        }
    }
}