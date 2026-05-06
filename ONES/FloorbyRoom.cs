using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000057 RID: 87
    [Transaction(TransactionMode.Manual)]
    public class FloorbyRoom : IExternalCommand
    {
        // Token: 0x0600022E RID: 558 RVA: 0x00024988 File Offset: 0x00022B88
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Autodesk.Revit.DB.View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            IList<ElementId> list = selection.GetElementIds().ToList<ElementId>();
            IList<Element> list2 = new List<Element>();
            ElementId defaultElementTypeId = document.GetDefaultElementTypeId(ElementTypeGroup.FloorType);
            FloorType floorType = document.GetElement(defaultElementTypeId) as FloorType;
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document).OfCategory(BuiltInCategory.OST_Floors);
            List<Element> list3 = filteredElementCollector.WhereElementIsElementType().ToList<Element>();
            list3.RemoveAll((Element item) => item == null);
            list3.Sort((Element x, Element y) => string.Compare(x.Name, y.Name));
            TypeSelector typeSelector = new TypeSelector(activeUIDocument, list3);
            DialogResult dialogResult = typeSelector.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return Result.Cancelled;
            }

            if (dialogResult == DialogResult.Abort)
            {
                return Result.Failed;
            }

            if (dialogResult == DialogResult.OK)
            {
                floorType = (typeSelector.ReturnType as FloorType);
            }

            foreach (ElementId elementId in list)
            {
                list2.Add(document.GetElement(elementId));
            }

            using (Transaction transaction = new Transaction(document, "Floor by Room"))
            {
                transaction.Start();
                foreach (Element element in list2)
                {
                    try
                    {
                        SpatialElement spatialElement = element as SpatialElement;
                        if (spatialElement == null)
                        {
                            continue;
                        }

                        IList<IList<BoundarySegment>> boundarySegments = spatialElement.GetBoundarySegments(new SpatialElementBoundaryOptions());
                        if (boundarySegments == null || boundarySegments.Count == 0)
                        {
                            continue;
                        }

                        List<CurveLoop> profile = new List<CurveLoop>();
                        foreach (IList<BoundarySegment> list4 in boundarySegments)
                        {
                            CurveLoop curveLoop = new CurveLoop();
                            foreach (BoundarySegment boundarySegment in list4)
                            {
                                Curve curve = boundarySegment.GetCurve();
                                if (curve != null)
                                {
                                    curveLoop.Append(curve);
                                }
                            }

                            if (curveLoop.NumberOfCurves() > 2)
                            {
                                profile.Add(curveLoop);
                            }
                        }

                        if (profile.Count == 0)
                        {
                            continue;
                        }

                        ElementId levelId = spatialElement.LevelId;
                        if (levelId == ElementId.InvalidElementId && activeView.GenLevel != null)
                        {
                            levelId = activeView.GenLevel.Id;
                        }

                        if (levelId == ElementId.InvalidElementId)
                        {
                            continue;
                        }

                        Floor.Create(document, profile, floorType.Id, levelId);
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
