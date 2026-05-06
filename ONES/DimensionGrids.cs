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
    // Token: 0x0200000D RID: 13
    [Transaction(TransactionMode.Manual)]
    public class DimensionGrids : IExternalCommand
    {
        // Token: 0x0600002A RID: 42 RVA: 0x0000686C File Offset: 0x00004A6C
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, activeView.Id).OfCategory((BuiltInCategory)(-2000220)).WhereElementIsNotElementType();
            List<Grid> list = new List<Grid>();
            HashSet<double> hashSet = new HashSet<double>();
            Dictionary<double, List<Grid>> dictionary = new Dictionary<double, List<Grid>>();
            foreach (Element element in filteredElementCollector)
            {
                Grid grid = (Grid)element;
                try
                {
                    list.Add(grid);
                    Line line = grid.Curve as Line;
                    double item = Math.Round(Math.Abs(line.Direction.X), 5);
                    hashSet.Add(item);
                }
                catch (Exception)
                {
                }
            }

            using (Transaction transaction = new Transaction(document, "Dimension Grids"))
            {
                transaction.Start();
                foreach (double num in hashSet)
                {
                    try
                    {
                        List<Grid> list2 = new List<Grid>();
                        ReferenceArray referenceArray = new ReferenceArray();
                        foreach (Element element2 in filteredElementCollector)
                        {
                            Grid grid2 = (Grid)element2;
                            Line line2 = grid2.Curve as Line;
                            double num2 = Math.Round(Math.Abs(line2.Direction.X), 5);
                            if (num2 == num)
                            {
                                list2.Add(grid2);
                            }
                        }

                        IComparer<Grid> comparer = new GridComparer();
                        list2.Sort(comparer);
                        foreach (Grid grid3 in list2)
                        {
                            referenceArray.Append(new Reference(grid3));
                        }

                        double num3 = 3.28084;
                        double num4 = 1.64042;
                        Curve curve = list2.First<Grid>().Curve;
                        Line line3 = curve as Line;
                        double num5 = Math.Round(Math.Abs(line3.Direction.X), 5);
                        double num6 = Math.Round(Math.Abs(line3.Direction.Y), 5);
                        XYZ endPoint = list2.First<Grid>().Curve.GetEndPoint(0);
                        XYZ endPoint2 = list2.Last<Grid>().Curve.GetEndPoint(0);
                        if (num5 <= 0.0 & curve.GetEndPoint(0).Y > curve.GetEndPoint(1).Y)
                        {
                            endPoint = list2.First<Grid>().Curve.GetEndPoint(1);
                            endPoint2 = list2.Last<Grid>().Curve.GetEndPoint(1);
                        }
                        else if (num5 > 0.0 & curve.GetEndPoint(0).X > curve.GetEndPoint(1).X)
                        {
                            endPoint = list2.First<Grid>().Curve.GetEndPoint(1);
                            endPoint2 = list2.Last<Grid>().Curve.GetEndPoint(1);
                        }

                        XYZ xyz = new XYZ(num5 * num3, num6 * num3, 0.0);
                        XYZ xyz2 = new XYZ(num5 * num4, num6 * num4, 0.0);
                        XYZ xyz3 = endPoint + xyz;
                        XYZ xyz4 = endPoint2 + xyz;
                        Line line4 = Line.CreateBound(xyz3, xyz4);
                        XYZ xyz5 = endPoint + xyz2;
                        XYZ xyz6 = endPoint2 + xyz2;
                        Line line5 = Line.CreateBound(xyz5, xyz6);
                        ReferenceArray referenceArray2 = new ReferenceArray();
                        referenceArray2.Append(new Reference(list2.First<Grid>()));
                        referenceArray2.Append(new Reference(list2.Last<Grid>()));
                        document.Create.NewDimension(activeView, line4, referenceArray);
                        document.Create.NewDimension(activeView, line5, referenceArray2);
                        XYZ endPoint3 = list2.First<Grid>().Curve.GetEndPoint(1);
                        XYZ endPoint4 = list2.Last<Grid>().Curve.GetEndPoint(1);
                        if (num5 <= 0.0 & curve.GetEndPoint(0).Y > curve.GetEndPoint(1).Y)
                        {
                            endPoint3 = list2.First<Grid>().Curve.GetEndPoint(0);
                            endPoint4 = list2.Last<Grid>().Curve.GetEndPoint(0);
                        }
                        else if (num5 > 0.0 & curve.GetEndPoint(0).X > curve.GetEndPoint(1).X)
                        {
                            endPoint3 = list2.First<Grid>().Curve.GetEndPoint(0);
                            endPoint4 = list2.Last<Grid>().Curve.GetEndPoint(0);
                        }

                        XYZ xyz7 = endPoint3 - xyz;
                        XYZ xyz8 = endPoint4 - xyz;
                        Line line6 = Line.CreateBound(xyz7, xyz8);
                        XYZ xyz9 = endPoint3 - xyz2;
                        XYZ xyz10 = endPoint4 - xyz2;
                        Line line7 = Line.CreateBound(xyz9, xyz10);
                        document.Create.NewDimension(activeView, line6, referenceArray);
                        document.Create.NewDimension(activeView, line7, referenceArray2);
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