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
    // Token: 0x0200003F RID: 63
    [Transaction(TransactionMode.Manual)]
    public class SectionBoxLevels : IExternalCommand
    {
        // Token: 0x060001E9 RID: 489 RVA: 0x00022924 File Offset: 0x00020B24
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector source = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType();
            List<Level> list = (
                from Level x in source
                orderby x.Elevation
                select x).ToList<Level>();
            ViewFamilyType viewFamilyType = new FilteredElementCollector(document).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>().FirstOrDefault((ViewFamilyType x) => x.ViewFamily == ViewFamily.ThreeDimensional);
            using (Transaction transaction = new Transaction(document, "Test"))
            {
                transaction.Start();
                for (int i = 0; i < list.Count - 1; i++)
                {
                    View3D view3D = View3D.CreateIsometric(document, viewFamilyType.Id);
                    BoundingBoxXYZ sectionBox = view3D.GetSectionBox();
                    BoundingBoxXYZ boundingBoxXYZ = sectionBox;
                    XYZ min = Utils.XYZModifyZ(sectionBox.Min, list[i].Elevation);
                    XYZ max = Utils.XYZModifyZ(sectionBox.Max, list[i + 1].Elevation);
                    boundingBoxXYZ.Min = min;
                    boundingBoxXYZ.Max = max;
                    view3D.SetSectionBox(boundingBoxXYZ);
                    view3D.Name = "Level_" + list[i].Name;
                    view3D.DetailLevel = ViewDetailLevel.Fine;
                    view3D.get_Parameter(BuiltInParameter.MODEL_GRAPHICS_STYLE).Set(7);
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
