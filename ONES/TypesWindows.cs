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
    // Token: 0x02000056 RID: 86
    [Transaction(TransactionMode.Manual)]
    public class TypesWindows : IExternalCommand
    {
        // Token: 0x0600022C RID: 556 RVA: 0x000245C8 File Offset: 0x000227C8
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
            XYZ xyz = activeUIDocument.Selection.PickPoint();
            FilteredElementCollector source = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType();
            Level level = (
                from Level x in source
                where x.Name.StartsWith("1F")select x).First<Level>();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Windows).WhereElementIsElementType();
            List<FamilySymbol> list = new List<FamilySymbol>();
            double num = 20.0;
            double num2 = 0.0;
            foreach (Element element in filteredElementCollector)
            {
                FamilySymbol familySymbol = (FamilySymbol)element;
                try
                {
                    if (familySymbol.FamilyName.StartsWith("_"))
                    {
                        Parameter parameter = familySymbol.get_Parameter(BuiltInParameter.DOOR_WIDTH);
                        Parameter parameter2 = familySymbol.get_Parameter(BuiltInParameter.GENERIC_HEIGHT);
                        double num3 = parameter2.AsDouble();
                        double num4 = parameter.AsDouble();
                        if (num3 > num2)
                        {
                            num2 = num3;
                        }

                        num += num4 + 10.0;
                        list.Add(familySymbol);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }

            try
            {
                using (Transaction transaction = new Transaction(document, "Window Types"))
                {
                    transaction.Start();
                    XYZ xyz2 = new XYZ(xyz.X, xyz.Y, xyz.Z);
                    XYZ xyz3 = new XYZ(xyz.X + num, xyz.Y, xyz.Z);
                    Line line = Line.CreateBound(xyz2, xyz3);
                    Wall wall = Wall.Create(document, line, level.Id, true);
                    Parameter parameter3 = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);
                    parameter3.Set(num2 + 5.0);
                    LocationCurve locationCurve = wall.Location as LocationCurve;
                    double num5 = xyz.X + 10.0;
                    double y = xyz.Y;
                    double num6 = 0.0;
                    foreach (FamilySymbol familySymbol2 in list)
                    {
                        try
                        {
                            double num7 = familySymbol2.get_Parameter(BuiltInParameter.DOOR_WIDTH).AsDouble();
                            num5 += 10.0 + num7 / 2.0;
                            FamilyInstance familyInstance = document.Create.NewFamilyInstance(new XYZ(num5, y, num6), familySymbol2, wall, level, 0);
                            num5 += num7 / 2.0;
                        }
                        catch (Exception ex2)
                        {
                            Debug.Print(ex2.Message);
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex3)
            {
                TaskDialog.Show("Error", ex3.Message);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
