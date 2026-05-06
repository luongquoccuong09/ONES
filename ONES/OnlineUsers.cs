using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ONES
{
    // Token: 0x02000093 RID: 147
    [Transaction(TransactionMode.Manual)]
    public class OnlineUsers : IExternalCommand
    {
        // Token: 0x06000376 RID: 886 RVA: 0x00036DA8 File Offset: 0x00034FA8
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document).WhereElementIsNotElementType();
            HashSet<string> hashSet = new HashSet<string>();
            foreach (Element element in filteredElementCollector)
            {
                try
                {
                    WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(document, element.Id);
                    string owner = worksharingTooltipInfo.Owner;
                    if (owner != null)
                    {
                        hashSet.Add(owner);
                    }
                }
                catch (Exception)
                {
                }
            }

            hashSet.Add(document.Application.Username);
            if (hashSet.Count == 0)
            {
                TaskDialog.Show("Online Users", "There is no element owned by anyone yet");
                return Result.Cancelled;
            }

            string text = "";
            foreach (string str in hashSet)
            {
                text = text + str + "\n";
            }

            TaskDialog.Show("Online Users", text);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}