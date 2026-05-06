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
    // Token: 0x0200000A RID: 10
    [Transaction(TransactionMode.Manual)]
    public class AnalyticalEnable : IExternalCommand
    {
        // Token: 0x06000022 RID: 34 RVA: 0x000038D0 File Offset: 0x00001AD0
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ParameterValueProvider parameterValueProvider = new ParameterValueProvider(new ElementId(BuiltInParameter.STRUCTURAL_ANALYTICAL_MODEL));
            FilterIntegerRule filterIntegerRule = new FilterIntegerRule(parameterValueProvider, new FilterNumericEquals(), 0);
            ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterIntegerRule);
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, activeView.Id).WhereElementIsNotElementType();
            filteredElementCollector.WherePasses(elementParameterFilter);
            List<Element> list = (List<Element>)filteredElementCollector.ToElements();
            if (list.Count == 0)
            {
                TaskDialog.Show("Hint", "There are no enabled AnalyticalModels");
            }

            using (Transaction transaction = new Transaction(document, "Enabling Analytical Model"))
            {
                transaction.Start();
                foreach (Element element in list)
                {
                    try
                    {
                        bool flag = element.get_Parameter(BuiltInParameter.STRUCTURAL_ANALYTICAL_MODEL).Set(1);
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
