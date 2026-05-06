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
    // Token: 0x0200003E RID: 62
    [Transaction(TransactionMode.Manual)]
    public class SectionBoxGrids : IExternalCommand
    {
        // Token: 0x060001E7 RID: 487 RVA: 0x00022580 File Offset: 0x00020780
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

            ViewFamilyType viewFamilyType = new FilteredElementCollector(document).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>().FirstOrDefault((ViewFamilyType x) => x.ViewFamily == ViewFamily.ThreeDimensional);
            using (Transaction transaction = new Transaction(document, "Test"))
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
                        for (int i = 0; i < list2.Count - 1; i++)
                        {
                            View3D view3D = View3D.CreateIsometric(document, viewFamilyType.Id);
                            BoundingBoxXYZ sectionBox = view3D.GetSectionBox();
                            BoundingBoxXYZ boundingBoxXYZ = sectionBox;
                            BoundingBoxXYZ boundingBoxXYZ2 = list2[i].get_BoundingBox(activeView);
                            BoundingBoxXYZ boundingBoxXYZ3 = list2[i + 1].get_BoundingBox(activeView);
                            XYZ min = Utils.XYZModifyZ(boundingBoxXYZ2.Min, sectionBox.Min.Z);
                            XYZ max = Utils.XYZModifyZ(boundingBoxXYZ3.Max, sectionBox.Max.Z);
                            boundingBoxXYZ.Min = min;
                            boundingBoxXYZ.Max = max;
                            view3D.SetSectionBox(boundingBoxXYZ);
                            view3D.Name = "Grid_" + list2[i].Name;
                            view3D.DetailLevel = ViewDetailLevel.Fine;
                            view3D.get_Parameter(BuiltInParameter.MODEL_GRAPHICS_STYLE).Set(7);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.Message);
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
