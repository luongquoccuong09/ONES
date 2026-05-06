using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000020 RID: 32
    [Transaction(TransactionMode.Manual)]
    public class βGravityCenter : IExternalCommand
    {
        // Token: 0x060000BA RID: 186 RVA: 0x000118F4 File Offset: 0x0000FAF4
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICollection<ElementId> elementIds = activeUIDocument.Selection.GetElementIds();
            using (Transaction transaction = new Transaction(document, "CreateDisplacementAndPath"))
            {
                transaction.Start();
                List<Solid> list = new List<Solid>();
                foreach (ElementId elementId in elementIds)
                {
                    try
                    {
                        Element element = document.GetElement(elementId);
                        if (element is Group)
                        {
                            Group group = element as Group;
                            IList<ElementId> memberIds = group.GetMemberIds();
                            using (IEnumerator<ElementId> enumerator2 = memberIds.GetEnumerator())
                            {
                                while (enumerator2.MoveNext())
                                {
                                    ElementId elementId2 = enumerator2.Current;
                                    try
                                    {
                                        Element element2 = document.GetElement(elementId2);
                                        list.AddRange(Utils.SolidList(element, activeView));
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }

                                continue;
                            }
                        }

                        list.AddRange(Utils.SolidList(element, activeView));
                    }
                    catch (Exception)
                    {
                    }
                }

                XYZ xyz = new XYZ();
                double num = 0.0;
                foreach (Solid solid in list)
                {
                    double volume = solid.Volume;
                    xyz += solid.ComputeCentroid() * volume;
                    num += volume;
                }

                XYZ center = xyz / num;
                Solid solid2 = this.SolidSphere(center);
                DirectShape directShape = DirectShape.CreateElement(document, new ElementId(-2000151));
                directShape.ApplicationId = "Application id";
                directShape.ApplicationDataId = "Geometry object id";
                directShape.SetShape(new GeometryObject[] { solid2 });
                transaction.Commit();
            }

            stopwatch.Stop();
            TaskDialog.Show("test", stopwatch.ElapsedMilliseconds.ToString());
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x060000BB RID: 187 RVA: 0x00011B9C File Offset: 0x0000FD9C
        public Solid SolidSphere(XYZ center)
        {
            List<Curve> list = new List<Curve>();
            double num = 0.5;
            XYZ xyz = center + new XYZ(0.0, num, 0.0);
            XYZ xyz2 = center - new XYZ(0.0, num, 0.0);
            list.Add(Line.CreateBound(xyz, xyz2));
            list.Add(Arc.Create(xyz2, xyz, center + new XYZ(num, 0.0, 0.0)));
            CurveLoop curveLoop = CurveLoop.Create(list);
            SolidOptions solidOptions = new SolidOptions(ElementId.InvalidElementId, ElementId.InvalidElementId);
            Frame frame = new Frame(center, XYZ.BasisX, -XYZ.BasisZ, XYZ.BasisY);
            if (Frame.CanDefineRevitGeometry(frame))
            {
                return GeometryCreationUtilities.CreateRevolvedGeometry(frame, new CurveLoop[] { curveLoop }, 0.0, 6.2831853071795862, solidOptions);
            }

            return null;
        }
    }
}