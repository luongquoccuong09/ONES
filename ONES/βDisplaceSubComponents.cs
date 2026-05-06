using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000022 RID: 34
    [Transaction(TransactionMode.Manual)]
    public class βDisplaceSubComponents : IExternalCommand
    {
        // Token: 0x060000C0 RID: 192 RVA: 0x00012018 File Offset: 0x00010218
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
                    FamilyInstance familyInstance = document.GetElement(elementId) as FamilyInstance;
                    DisplacementElement dispElem = DisplacementElement.Create(document, new ElementId[] { elementId }, new XYZ(0.0, 10.0, 20.0), activeView, null);
                    List<ElementId> list = familyInstance.GetSubComponentIds().ToList<ElementId>();
                    if (list.Count > 0)
                    {
                        βDisplaceSubComponents.SubComponents(activeUIDocument, list, dispElem);
                    }
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x060000C1 RID: 193 RVA: 0x0001215C File Offset: 0x0001035C
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

        // Token: 0x060000C2 RID: 194 RVA: 0x00012384 File Offset: 0x00010584
        private static void SubComponents(UIDocument uidoc, List<ElementId> elementIds, DisplacementElement dispElem)
        {
            Document document = uidoc.Document;
            View activeView = uidoc.ActiveView;
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    DisplacementElement dispElem2 = DisplacementElement.Create(document, elementIds, new XYZ(0.0, 10.0, 20.0), activeView, dispElem);
                    FamilyInstance familyInstance = document.GetElement(elementId) as FamilyInstance;
                    List<ElementId> list = familyInstance.GetSubComponentIds().ToList<ElementId>();
                    if (list.Count > 0)
                    {
                        βDisplaceSubComponents.SubComponents(uidoc, list, dispElem2);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        // Token: 0x060000C3 RID: 195 RVA: 0x00012448 File Offset: 0x00010648
        private static void SubComponentsDictionary(UIDocument uidoc, List<ElementId> elementIds, DisplacementElement dispElem)
        {
            Document document = uidoc.Document;
            View activeView = uidoc.ActiveView;
            foreach (ElementId elementId in elementIds)
            {
                try
                {
                    DisplacementElement dispElem2 = DisplacementElement.Create(document, elementIds, new XYZ(0.0, 10.0, 20.0), activeView, dispElem);
                    FamilyInstance familyInstance = document.GetElement(elementId) as FamilyInstance;
                    List<ElementId> list = familyInstance.GetSubComponentIds().ToList<ElementId>();
                    if (list.Count > 0)
                    {
                        βDisplaceSubComponents.SubComponentsDictionary(uidoc, list, dispElem2);
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}