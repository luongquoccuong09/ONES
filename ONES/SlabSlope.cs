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
    // Token: 0x0200005B RID: 91
    [Transaction(TransactionMode.Manual)]
    public class SlabSlope : IExternalCommand
    {
        // Token: 0x06000236 RID: 566 RVA: 0x000250A4 File Offset: 0x000232A4
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Element element;
            try
            {
                if (Utils.SelectPickElement(activeUIDocument) == null)
                {
                    return Result.Failed;
                }

                element = Utils.SelectPickElement(activeUIDocument);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return Result.Failed;
            }

            Element element2 = document.GetElement(element.GetTypeId());
            IList<Parameter> parameters = element2.GetParameters("符号(タイプ)");
            Parameter parameter = parameters.FirstOrDefault<Parameter>();
            if (parameter.StorageType.Equals(3))
            {
                TaskDialog.Show("Parameter", parameter.Definition.Name + "\nasstring" + parameter.AsString());
            }
            else
            {
                TaskDialog.Show("Parameter", parameter.Definition.Name + "\nasvalue" + parameter.AsValueString());
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}