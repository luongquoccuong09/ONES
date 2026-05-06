using System;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000058 RID: 88
    [Transaction(TransactionMode.Manual)]
    public class TypesWalls : IExternalCommand
    {
        // Token: 0x06000230 RID: 560 RVA: 0x00024C38 File Offset: 0x00022E38
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

            FilteredElementCollector source = new FilteredElementCollector(document).OfCategory((BuiltInCategory)(-2000240));
            Level level = (
                from Level x in source
                where x.Name.StartsWith("1F")select x).FirstOrDefault<Level>();
            FilteredElementCollector source2 = new FilteredElementCollector(document).OfCategory((BuiltInCategory) (- 2000011)).WhereElementIsElementType();
            using (Transaction transaction = new Transaction(document, "Test"))
            {
                transaction.Start();
                double num = 0.0;
                foreach (WallType wallType in source2.OfType<WallType>())
                {
                    try
                    {
                        XYZ xyz2 = new XYZ(xyz.X, xyz.Y + num, 0.0);
                        XYZ xyz3 = new XYZ(xyz.X + 10.0, xyz.Y + num, 0.0);
                        Line line = Line.CreateBound(xyz2, xyz3);
                        Wall wall = Wall.Create(document, line, level.Id, true);
                        wall.WallType = wallType;
                        num += 3.28084;
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