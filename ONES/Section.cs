using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x0200007F RID: 127
    [Transaction(TransactionMode.Manual)]
    public class Section : IExternalCommand
    {
        // Token: 0x060002D7 RID: 727 RVA: 0x0002C2E4 File Offset: 0x0002A4E4
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Grids).WhereElementIsNotElementType();
            FilteredElementCollector source = new FilteredElementCollector(document).OfClass(typeof(ViewFamilyType));
            ViewFamilyType viewFamilyType = source.Cast<ViewFamilyType>().FirstOrDefault((ViewFamilyType x) => x.ViewFamily == ViewFamily.Section);
            FilteredElementCollector filteredElementCollector2 = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType();
            List<double> list = new List<double>();
            foreach (Element element in filteredElementCollector2)
            {
                Level level = (Level)element;
                BoundingBoxXYZ boundingBoxXYZ = level.get_BoundingBox(activeView);
                list.Add(level.Elevation);
            }

            double num = list.Min();
            double num2 = list.Max();
            using (Transaction transaction = new Transaction(document, "Section Views for Grids"))
            {
                transaction.Start();
                foreach (Element element2 in filteredElementCollector)
                {
                    Grid grid = (Grid)element2;
                    try
                    {
                        Line line = grid.Curve as Line;
                        if (!(null == line))
                        {
                            XYZ endPoint = line.GetEndPoint(0);
                            XYZ endPoint2 = line.GetEndPoint(1);
                            XYZ xyz = endPoint2 - endPoint;
                            double length = xyz.GetLength();
                            BoundingBoxXYZ boundingBoxXYZ2 = grid.get_BoundingBox(activeView);
                            double num3 = Utils.UnitMilimeterToFeet(5000.0);
                            XYZ min = new XYZ(-length / 2.0, num, 0.0);
                            XYZ max = new XYZ(length / 2.0, num2, num3);
                            XYZ origin = (endPoint + endPoint2) / 2.0;
                            XYZ xyz2 = xyz.Normalize();
                            XYZ basisZ = XYZ.BasisZ;
                            XYZ basisZ2 = xyz2.CrossProduct(basisZ);
                            Transform identity = Transform.Identity;
                            identity.Origin = origin;
                            identity.BasisX = xyz2;
                            identity.BasisY = basisZ;
                            identity.BasisZ = basisZ2;
                            BoundingBoxXYZ boundingBoxXYZ3 = new BoundingBoxXYZ();
                            boundingBoxXYZ3.Transform = identity;
                            boundingBoxXYZ3.Min = min;
                            boundingBoxXYZ3.Max = max;
                            ViewSection viewSection = ViewSection.CreateSection(document, viewFamilyType.Id, boundingBoxXYZ3);
                            try
                            {
                                viewSection.Name = "通り芯" + grid.Name;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.Message);
                    }
                }

                transaction.Commit();
            }

            try
            {
                stopwatch.Stop();
                Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            }
            catch (Exception)
            {
            }

            return Result.Succeeded;
        }
    }
}
