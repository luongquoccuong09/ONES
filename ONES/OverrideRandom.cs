using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000060 RID: 96
    [Transaction(TransactionMode.Manual)]
    public class OverrideRandom : IExternalCommand
    {
        // Token: 0x06000240 RID: 576 RVA: 0x000256C8 File Offset: 0x000238C8
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
            ICollection<ElementId> elementIds = selection.GetElementIds();
            if (elementIds.Count == 0)
            {
                TaskDialog.Show("No Selection", "Please Select Elements");
                return Result.Cancelled;
            }

            using (Transaction transaction = new Transaction(document, "Override Graphics"))
            {
                transaction.Start();
                if (Settings.Default.OverrideNest)
                {
                    using (IEnumerator<ElementId> enumerator = elementIds.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            ElementId elementId = enumerator.Current;
                            try
                            {
                                Element element = document.GetElement(elementId);
                                OverrideRandom.OverrideElementNestedRandom(element, activeView);
                            }
                            catch (Exception)
                            {
                            }
                        }

                        goto IL_149;
                    }
                }

                foreach (ElementId elementId2 in elementIds)
                {
                    try
                    {
                        Random random = new Random();
                        Color color = new Color((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
                        OverrideGraphicSettings overrideGraphicSettings = Utils.OverrideGraphicDefault(document, color);
                        activeView.SetElementOverrides(elementId2, overrideGraphicSettings);
                        Thread.Sleep(15);
                    }
                    catch (Exception)
                    {
                    }
                }

                IL_149:
                    transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }

        // Token: 0x06000241 RID: 577 RVA: 0x0002588C File Offset: 0x00023A8C
        private static void OverrideElementNestedRandom(Element element, View view)
        {
            Thread.Sleep(20);
            Random random = new Random();
            Color color = new Color((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
            OverrideGraphicSettings overrideGraphicSettings = Utils.OverrideGraphicDefault(view.Document, color);
            if (element is FamilyInstance)
            {
                FamilyInstance familyInstance = element as FamilyInstance;
                ICollection<ElementId> subComponentIds = familyInstance.GetSubComponentIds();
                if (subComponentIds.Count > 0)
                {
                    using (IEnumerator<ElementId> enumerator = subComponentIds.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            ElementId elementId = enumerator.Current;
                            try
                            {
                                Element element2 = view.Document.GetElement(elementId);
                                OverrideRandom.OverrideElementNestedRandom(element2, view);
                            }
                            catch (Exception)
                            {
                            }
                        }

                        return;
                    }
                }

                view.SetElementOverrides(element.Id, overrideGraphicSettings);
                return;
            }

            view.SetElementOverrides(element.Id, overrideGraphicSettings);
        }
    }
}