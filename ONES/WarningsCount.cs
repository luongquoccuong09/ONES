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
    // Token: 0x02000069 RID: 105
    [Transaction(TransactionMode.Manual)]
    public class WarningsCount : IExternalCommand
    {
        // Token: 0x06000257 RID: 599 RVA: 0x00026710 File Offset: 0x00024910
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
            IList<FailureMessage> warnings = document.GetWarnings();
            HashSet<ElementId> hashSet = new HashSet<ElementId>();
            foreach (FailureMessage failureMessage in warnings)
            {
                ICollection<ElementId> failingElements = failureMessage.GetFailingElements();
                foreach (ElementId item in failingElements)
                {
                    hashSet.Add(item);
                }
            }

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (ElementId elementId in hashSet)
            {
                WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(document, elementId);
                if (worksharingTooltipInfo != null)
                {
                    string creator = worksharingTooltipInfo.Creator;
                    try
                    {
                        Dictionary<string, int> dictionary2 = dictionary;
                        string key = creator;
                        int num = dictionary2[key];
                        dictionary2[key] = num + 1;
                    }
                    catch (Exception)
                    {
                        dictionary.Add(creator, 1);
                    }
                }
            }

            string text = "";
            foreach (KeyValuePair<string, int> keyValuePair in dictionary)
            {
                try
                {
                    text = string.Concat(new string[] { text, keyValuePair.Key, ": ", keyValuePair.Value.ToString(), "\n" });
                }
                catch (Exception)
                {
                }
            }

            TaskDialog.Show("Warning Counts by User", text);
            stopwatch.Stop();
            Utils.ONESLogs(commandData.Application.ActiveUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}