using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000094 RID: 148
    [Transaction(TransactionMode.Manual)]
    public class HideOwnedElements : IExternalCommand
    {
        // Token: 0x06000378 RID: 888 RVA: 0x00036EFC File Offset: 0x000350FC
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            View activeView = document.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, document.ActiveView.Id).WhereElementIsNotElementType();
            List<ElementId> list = new List<ElementId>();
            foreach (Element element in filteredElementCollector)
            {
                if (WorksharingUtils.GetCheckoutStatus(document, element.Id) == CheckoutStatus.OwnedByOtherUser)
                {
                    list.Add(element.Id);
                }
            }

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Hide Owned Elements");
                if (list.Count != 0)
                {
                    activeView.HideElementsTemporary(list);
                }
                else
                {
                    TaskDialog.Show("Message", "There is no owned elements now");
                }

                transaction.Commit();
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
