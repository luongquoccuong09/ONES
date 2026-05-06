using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000006 RID: 6
    [Transaction(TransactionMode.Manual)]
    public class AlignMiddle : IExternalCommand
    {
        // Token: 0x06000017 RID: 23 RVA: 0x00002D34 File Offset: 0x00000F34
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
            XYZ upDirection = activeView.UpDirection;
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    Element element = document.GetElement(elementId);
                    XYZ item = this.XYZMid(element.get_BoundingBox(activeView));
                    list.Add(item);
                }
                catch (Exception)
                {
                }
            }

            XYZ xyz = new XYZ();
            foreach (XYZ xyz2 in list)
            {
                xyz += xyz2;
            }

            XYZ xyz3 = xyz / (double)list.Count;
            using (Transaction transaction = new Transaction(document, "Align Middle"))
            {
                transaction.Start();
                foreach (ElementId elementId2 in elementIds)
                {
                    try
                    {
                        Element element2 = document.GetElement(elementId2);
                        XYZ xyz4 = this.XYZMid(element2.get_BoundingBox(activeView));
                        XYZ xyz5 = xyz3 - xyz4;
                        XYZ xyz6 = new XYZ(xyz5.X * Math.Abs(upDirection.X), xyz5.Y * Math.Abs(upDirection.Y), xyz5.Z * Math.Abs(upDirection.Z));
                        ElementTransformUtils.MoveElement(document, elementId2, xyz6);
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

        // Token: 0x06000018 RID: 24 RVA: 0x00002F64 File Offset: 0x00001164
        private XYZ XYZMid(BoundingBoxXYZ bb)
        {
            XYZ xyz = new XYZ(bb.Min.X, bb.Min.Y, bb.Min.Z);
            XYZ xyz2 = new XYZ(bb.Max.X, bb.Max.Y, bb.Max.Z);
            return (xyz + xyz2) / 2.0;
        }
    }
}