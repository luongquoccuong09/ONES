using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000010 RID: 16
    [Transaction(TransactionMode.Manual)]
    public class JoinElements2 : IExternalCommand
    {
        // Token: 0x0600003D RID: 61 RVA: 0x00009594 File Offset: 0x00007794
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Autodesk.Revit.DB.View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SelectFilterForm2 selectFilterForm = new SelectFilterForm2(activeUIDocument);
            DialogResult dialogResult = selectFilterForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                List<ElementId> checkedIds = selectFilterForm.checkedIds1;
                List<ElementId> checkedIds2 = selectFilterForm.checkedIds2;
                using (Transaction transaction = new Transaction(document))
                {
                    transaction.Start("Join Elements");
                    foreach (ElementId elementId in checkedIds)
                    {
                        try
                        {
                            List<Element> list = new List<Element>();
                            Element element = document.GetElement(elementId);
                            int num = 0;
                            Solid solid = Utils.SolidUnion(element, activeView);
                            if (!(solid == null))
                            {
                                BoundingBoxXYZ boundingBoxXYZ = element.get_BoundingBox(activeView);
                                Outline outline = new Outline(boundingBoxXYZ.Min, boundingBoxXYZ.Max);
                                foreach (ElementId elementId2 in checkedIds2)
                                {
                                    try
                                    {
                                        if (!(elementId == elementId2))
                                        {
                                            Element element2 = document.GetElement(elementId2);
                                            BoundingBoxXYZ boundingBoxXYZ2 = element2.get_BoundingBox(activeView);
                                            Outline outline2 = new Outline(boundingBoxXYZ2.Min, boundingBoxXYZ2.Max);
                                            if (outline.Intersects(outline2, 0.0))
                                            {
                                                Solid solid2 = Utils.SolidUnion(element2, activeView);
                                                if (!(solid2 == null))
                                                {
                                                    Solid solid3 = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid2, BooleanOperationsType.Intersect);
                                                    if (solid3 != null & solid3.Volume != 0.0)
                                                    {
                                                        list.Add(element2);
                                                        num++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }

                                foreach (Element element3 in list)
                                {
                                    try
                                    {
                                        if (!JoinGeometryUtils.AreElementsJoined(document, element, element3))
                                        {
                                            JoinGeometryUtils.JoinGeometry(document, element, element3);
                                        }

                                        if (!JoinGeometryUtils.IsCuttingElementInJoin(document, element, element3))
                                        {
                                            JoinGeometryUtils.SwitchJoinOrder(document, element, element3);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    transaction.Commit();
                }
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
