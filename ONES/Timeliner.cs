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
    // Token: 0x02000015 RID: 21
    [Transaction(TransactionMode.Manual)]
    public class Timeliner : IExternalCommand
    {
        // Token: 0x0600005C RID: 92 RVA: 0x0000AEBC File Offset: 0x000090BC
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
            TimelinerForm timelinerForm = new TimelinerForm(activeUIDocument);
            timelinerForm.ShowDialog();
            FilteredElementCollector source = new FilteredElementCollector(document).OfClass(typeof(Level));
            List<ICollection<ElementId>> idGroupsInOrder = new List<ICollection<ElementId>>();
            IEnumerable<Level> enumerable =
                from Level lvl in source
                orderby lvl.Elevation
                select lvl;
            foreach (Level level in enumerable)
            {
                Timeliner.AddInstancesOnLevelToIdGroupList(idGroupsInOrder, level, BuiltInCategory.OST_StructuralFoundation);
                Timeliner.AddInstancesOnReferenceLevelToIdGroupList(idGroupsInOrder, level, BuiltInCategory.OST_StructuralFraming);
                Timeliner.AddInstancesOnLevelToIdGroupList(idGroupsInOrder, level, BuiltInCategory.OST_Floors);
                Timeliner.AddInstancesOnLevelToIdGroupList(idGroupsInOrder, level, BuiltInCategory.OST_StructuralColumns);
                Timeliner.AddInstancesOnLevelToIdGroupList(idGroupsInOrder, level, BuiltInCategory.OST_Walls);
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x0600005D RID: 93 RVA: 0x0000AFF8 File Offset: 0x000091F8
        private static void AddInstancesOnLevelToIdGroupList(List<ICollection<ElementId>> idGroupsInOrder, Level level, BuiltInCategory category)
        {
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(level.Document);
            filteredElementCollector.WherePasses(new ElementLevelFilter(level.Id));
            filteredElementCollector.OfCategory(category);
            filteredElementCollector.WhereElementIsNotElementType();
            ICollection<ElementId> collection = filteredElementCollector.ToElementIds();
            if (collection.Count > 0)
            {
                idGroupsInOrder.Add(collection);
            }
        }

        // Token: 0x0600005E RID: 94 RVA: 0x0000B04C File Offset: 0x0000924C
        private static void AddInstancesOnReferenceLevelToIdGroupList(List<ICollection<ElementId>> idGroupsInOrder, Level level, BuiltInCategory category)
        {
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(level.Document);
            filteredElementCollector.OfCategory(category);
            filteredElementCollector.WhereElementIsNotElementType();
            FilterRule filterRule = ParameterFilterRuleFactory.CreateEqualsRule(new ElementId(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM), level.Id);
            filteredElementCollector.WherePasses(new ElementParameterFilter(filterRule));
            ICollection<ElementId> collection = filteredElementCollector.ToElementIds();
            if (collection.Count > 0)
            {
                idGroupsInOrder.Add(collection);
            }
        }

        // Token: 0x0600005F RID: 95 RVA: 0x0000B0B0 File Offset: 0x000092B0
        private static ICollection<ElementId> CollectorCategory(Document doc, View view, BuiltInCategory category)
        {
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(doc, view.Id);
            filteredElementCollector.OfCategory(category);
            filteredElementCollector.WhereElementIsNotElementType();
            return filteredElementCollector.ToElementIds();
        }
    }
}
