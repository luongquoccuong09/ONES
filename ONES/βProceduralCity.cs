using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000019 RID: 25
    [Transaction(TransactionMode.Manual)]
    public class βProceduralCity : IExternalCommand
    {
        // Token: 0x0600007B RID: 123 RVA: 0x0000C654 File Offset: 0x0000A854
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int num = 100;
            int num2 = 100;
            using (Transaction transaction = new Transaction(document, "Procedural City"))
            {
                transaction.Start();
                for (int i = 0; i <= num; i += 10)
                {
                    for (int j = 0; j <= num2; j += 10)
                    {
                        try
                        {
                            Solid solid = this.BlockSolid(new XYZ((double)i, (double)j, 0.0), 3, 20, 30);
                            if (solid != null)
                            {
                                this.BlockDS(document, solid);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x0600007C RID: 124 RVA: 0x0000C758 File Offset: 0x0000A958
        private Solid BlockSolid(XYZ xyzCenter, int maxSize, int maxH, int maxOff)
        {
            Solid solid = null;
            Random random = new Random();
            int num = random.Next(1, 10);
            for (int i = 0; i < num; i++)
            {
                Thread.Sleep(5);
                int num2 = random.Next(1, maxSize);
                int num3 = random.Next(0, maxOff);
                int num4 = random.Next(0, maxOff);
                XYZ xyz = xyzCenter + new XYZ((double)(num3 / 10), (double)(num4 / 10), 0.0);
                List<Curve> list = Utils.SquareCurves(xyz, (double)num2);
                CurveLoop item = CurveLoop.Create(list);
                List<CurveLoop> list2 = new List<CurveLoop>
                {
                    item
                };
                Solid solid2 = GeometryCreationUtilities.CreateExtrusionGeometry(list2, new XYZ(0.0, 0.0, 1.0), (double)random.Next(2, maxH));
                if (null == solid)
                {
                    solid = solid2;
                }
                else
                {
                    solid = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid2, 0);
                }
            }

            return solid;
        }

        // Token: 0x0600007D RID: 125 RVA: 0x0000C840 File Offset: 0x0000AA40
        private DirectShape BlockDS(Document doc, Solid solidUnion)
        {
            List<GeometryObject> list = new List<GeometryObject>();
            list.Add(solidUnion);
            DirectShape directShape = DirectShape.CreateElement(doc, new ElementId(-2000151));
            directShape.ApplicationId = "Application id";
            directShape.ApplicationDataId = "Geometry object id";
            directShape.SetShape(list);
            return directShape;
        }
    }
}