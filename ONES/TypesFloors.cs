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
    // Token: 0x02000054 RID: 84
    [Transaction(TransactionMode.Manual)]
    public class TypesFloors : IExternalCommand
    {
        // Token: 0x06000228 RID: 552 RVA: 0x00023FD8 File Offset: 0x000221D8
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            XYZ xyz = null;
            try
            {
                xyz = activeUIDocument.Selection.PickPoint();
            }
            catch (Exception)
            {
                return Result.Cancelled;
            }

            if (xyz == null)
            {
                TaskDialog.Show("Exception", "Picked point error");
            }

            try
            {
                FilteredElementCollector source = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Levels);
                Level level = (
                    from Level x in source
                    where x.Name.StartsWith("1F")select x).FirstOrDefault<Level>();
                FilteredElementCollector source2 = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType();
                using (Transaction transaction = new Transaction(document, "Floor Types"))
                {
                    transaction.Start();
                    double num = 0.0;
                    foreach (FloorType floorType in source2.OfType<FloorType>())
                    {
                        try
                        {
                            XYZ xyz2 = new XYZ(xyz.X, xyz.Y, xyz.Z + num);
                            CurveArray curveArray = Utils.SquareCurvesArray(xyz2, 10.0);
                            CurveLoop curveLoop = new CurveLoop();
                            foreach (Curve curve in curveArray)
                            {
                                curveLoop.Append(curve);
                            }
                            Floor floor = Floor.Create(document, new List<CurveLoop> { curveLoop }, floorType.Id, level.Id);
                            num += 10.0;
                        }
                        catch (Exception)
                        {
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Exception", ex.Message);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
