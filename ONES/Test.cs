using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000082 RID: 130
    [Transaction(TransactionMode.Manual)]
    public class Test : IExternalCommand
    {
        // Token: 0x060002DD RID: 733 RVA: 0x0002CA3C File Offset: 0x0002AC3C
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
            using (Transaction transaction = new Transaction(document, "Test"))
            {
                transaction.Start();
                foreach (ElementId elementId in selection.GetElementIds())
                {
                    try
                    {
                        Element element = document.GetElement(elementId);
                        List<Mesh> list = Utils.MeshOfInstanceList(element, activeView);
                        TessellatedShapeBuilder tessellatedShapeBuilder = new TessellatedShapeBuilder();
                        tessellatedShapeBuilder.OpenConnectedFaceSet(true);
                        foreach (Mesh mesh in list)
                        {
                            tessellatedShapeBuilder.AddFace(new TessellatedFace(mesh.Vertices, ElementId.InvalidElementId));
                        }

                        tessellatedShapeBuilder.CloseConnectedFaceSet();
                        tessellatedShapeBuilder.Build();
                        TessellatedShapeBuilderResult buildResult = tessellatedShapeBuilder.GetBuildResult();
                        DirectShape directShape = DirectShape.CreateElement(document, new ElementId(-2000151));
                        directShape.ApplicationId = "Application id";
                        directShape.ApplicationDataId = "Geometry object id";
                        directShape.SetShape(buildResult.GetGeometricalObjects());
                    }
                    catch (Exception ex)
                    {
                    }
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x060002DE RID: 734 RVA: 0x0002CC1C File Offset: 0x0002AE1C
        public TessellatedShapeBuilderResult CreateTessellatedShape(Document doc, ElementId materialId)
        {
            List<XYZ> list = new List<XYZ>(4);
            TessellatedShapeBuilder tessellatedShapeBuilder = new TessellatedShapeBuilder();
            tessellatedShapeBuilder.OpenConnectedFaceSet(true);
            double num = 4.0;
            double num2 = 5.0;
            XYZ zero = XYZ.Zero;
            XYZ item = new XYZ(num, 0.0, 0.0);
            XYZ item2 = new XYZ(num, num, 0.0);
            XYZ item3 = new XYZ(0.0, num, 0.0);
            XYZ item4 = new XYZ(num / 2.0, num / 2.0, num2);
            list.Add(zero);
            list.Add(item);
            list.Add(item2);
            list.Add(item3);
            tessellatedShapeBuilder.AddFace(new TessellatedFace(list, materialId));
            list.Clear();
            list.Add(zero);
            list.Add(item4);
            list.Add(item);
            tessellatedShapeBuilder.AddFace(new TessellatedFace(list, materialId));
            list.Clear();
            list.Add(item);
            list.Add(item4);
            list.Add(item2);
            tessellatedShapeBuilder.AddFace(new TessellatedFace(list, materialId));
            list.Clear();
            list.Add(item2);
            list.Add(item4);
            list.Add(item3);
            tessellatedShapeBuilder.AddFace(new TessellatedFace(list, materialId));
            list.Clear();
            list.Add(item3);
            list.Add(item4);
            list.Add(zero);
            tessellatedShapeBuilder.AddFace(new TessellatedFace(list, materialId));
            tessellatedShapeBuilder.CloseConnectedFaceSet();
            tessellatedShapeBuilder.Build();
            return tessellatedShapeBuilder.GetBuildResult();
        }
    }
}