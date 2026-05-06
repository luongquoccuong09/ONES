using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x0200003D RID: 61
    [Transaction(TransactionMode.Manual)]
    public class Unjoin : IExternalCommand
    {
        // Token: 0x060001E5 RID: 485 RVA: 0x00022420 File Offset: 0x00020620
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
            ICollection<ElementId> elementIds = activeUIDocument.Selection.GetElementIds();
            using (Transaction transaction = new Transaction(document, "Unjoin"))
            {
                transaction.Start();
                foreach (ElementId elementId in elementIds)
                {
                    try
                    {
                        Element element = document.GetElement(elementId);
                        ICollection<ElementId> joinedElements = JoinGeometryUtils.GetJoinedElements(document, element);
                        foreach (ElementId elementId2 in joinedElements)
                        {
                            try
                            {
                                Element element2 = document.GetElement(elementId2);
                                JoinGeometryUtils.UnjoinGeometry(document, element, element2);
                            }
                            catch (Exception)
                            {
                            }
                        }
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