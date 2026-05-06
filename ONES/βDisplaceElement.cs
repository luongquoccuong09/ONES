using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000021 RID: 33
    [Transaction(TransactionMode.Manual)]
    public class βDisplaceElement : IExternalCommand
    {
        // Token: 0x060000BD RID: 189 RVA: 0x00011C9C File Offset: 0x0000FE9C
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
            ICollection<ElementId> elementIds = activeUIDocument.Selection.GetElementIds();
            using (Transaction transaction = new Transaction(document, "CreateDisplacementAndPath"))
            {
                transaction.Start();
                foreach (ElementId elementId in elementIds)
                {
                    try
                    {
                        Element element = document.GetElement(elementId);
                        Thread.Sleep(1);
                        byte b = 100;
                        Random random = new Random();
                        XYZ xyz = new XYZ((double)((byte)random.Next((int)(-(int)b), (int)b)), (double)((byte)random.Next((int)(-(int)b), (int)b)), (double)((byte)random.Next((int)(-(int)b), (int)b)));
                        DisplacementElement displacementElement = DisplacementElement.Create(document, new ElementId[] { elementId }, xyz, activeView, null);
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

        // Token: 0x060000BE RID: 190 RVA: 0x00011DF0 File Offset: 0x0000FFF0
        private static Reference GetHorizontalEdgeReference(Element elem)
        {
            GeometryElement geometryElement = elem.get_Geometry(new Options { ComputeReferences = true });
            foreach (GeometryObject geometryObject in geometryElement)
            {
                if (geometryObject is Solid)
                {
                    Solid solid = geometryObject as Solid;
                    FaceArray faces = solid.Faces;
                    foreach (object obj in faces)
                    {
                        Face face = (Face)obj;
                        BoundingBoxUV boundingBox = face.GetBoundingBox();
                        UV uv = (boundingBox.Min + boundingBox.Max) / 2.0;
                        if (face.ComputeNormal(uv).Normalize().Z < -0.1)
                        {
                            EdgeArrayArray edgeLoops = face.EdgeLoops;
                            foreach (object obj2 in edgeLoops)
                            {
                                EdgeArray edgeArray = (EdgeArray)obj2;
                                foreach (object obj3 in edgeArray)
                                {
                                    Edge edge = (Edge)obj3;
                                    if (Math.Abs(edge.AsCurve().ComputeDerivatives(0.0, true).BasisX.DotProduct(XYZ.BasisZ)) - 1.0 <= 1E-05)
                                    {
                                        return edge.Reference;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}