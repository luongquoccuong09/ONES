using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;

namespace ONES
{
    // Token: 0x0200008B RID: 139
    [Transaction(TransactionMode.Manual)]
    public class InspectElement : IExternalCommand
    {
        // Token: 0x0600035A RID: 858 RVA: 0x00034878 File Offset: 0x00032A78
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Document document = activeUIDocument.Document;
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

            try
            {
                ElementId id = element.Id;
                Worksheet worksheet = Utils.ExcelWorksheet("Parameters");
                IList<Parameter> orderedParameters = element.GetOrderedParameters();
                Element element2 = document.GetElement(element.GetTypeId());
                IList<Parameter> orderedParameters2 = element2.GetOrderedParameters();
                int num = orderedParameters.Count<Parameter>();
                int num2 = orderedParameters2.Count<Parameter>();
                int num3 = 1;
                worksheet.Cells[num3, 1] = "INSTANCE PARAMETERS";
                num3++;
                foreach (Parameter parameter in orderedParameters)
                {
                    worksheet.Cells[num3, 1] = parameter.Definition.Name;
                    if (parameter.StorageType == StorageType.String)
                    {
                        worksheet.Cells[num3, 2] = parameter.AsString();
                    }
                    else
                    {
                        worksheet.Cells[num3, 2] = parameter.AsValueString();
                    }

                    num3++;
                }

                num3 = 1;
                worksheet.Cells[num3, 4] = "TYPE PARAMETERS";
                num3++;
                foreach (Parameter parameter2 in orderedParameters2)
                {
                    worksheet.Cells[num3, 4] = parameter2.Definition.Name;
                    if (parameter2.StorageType == StorageType.String)
                    {
                        worksheet.Cells[num3, 5] = parameter2.AsString();
                    }
                    else
                    {
                        worksheet.Cells[num3, 5] = parameter2.AsValueString();
                    }

                    num3++;
                }

                num3 = 1;
                worksheet.Cells[num3, 7] = "INSTANCE CREATOR";
                num3++;
                WorksharingTooltipInfo worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(document, id);
                worksheet.Cells[num3, 7] = "Creator";
                worksheet.Cells[num3, 8] = worksharingTooltipInfo.Creator;
                num3++;
                worksheet.Cells[num3, 7] = "Owner";
                worksheet.Cells[num3, 8] = worksharingTooltipInfo.Owner;
                num3++;
                worksheet.Cells[num3, 7] = "Last Update";
                worksheet.Cells[num3, 8] = worksharingTooltipInfo.LastChangedBy;
                num3 = 1;
                worksheet.Cells[num3, 10] = "TYPE CREATOR";
                num3++;
                worksharingTooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(document, element.GetTypeId());
                worksheet.Cells[num3, 10] = "Creator";
                worksheet.Cells[num3, 11] = worksharingTooltipInfo.Creator;
                num3++;
                worksheet.Cells[num3, 10] = "Owner";
                worksheet.Cells[num3, 11] = worksharingTooltipInfo.Owner;
                num3++;
                worksheet.Cells[num3, 10] = "Last Update";
                worksheet.Cells[num3, 11] = worksharingTooltipInfo.LastChangedBy;
                Utils.ExcelTitleStyle(worksheet);
            }
            catch (Exception ex2)
            {
                TaskDialog.Show(" Error", ex2.Message);
                stopwatch.Stop();
                Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
                return Result.Failed;
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
