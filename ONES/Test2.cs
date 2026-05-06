using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitTaskDialog = Autodesk.Revit.UI.TaskDialog;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
    // Token: 0x0200006A RID: 106
    [Transaction(TransactionMode.Manual)]
    public class Test2 : IExternalCommand
    {
        // Token: 0x06000259 RID: 601 RVA: 0x00026938 File Offset: 0x00024B38
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SelectFilterForm selectFilterForm = new SelectFilterForm(activeUIDocument);
            DialogResult dialogResult = selectFilterForm.ShowDialog();
            List<ElementId> list = new List<ElementId>();
            if (dialogResult == DialogResult.OK)
            {
                list = selectFilterForm.checkedIds;
                activeUIDocument.Selection.SetElementIds(list);
            }

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            string text = "Created Date";
            string username = document.Application.Username;
            string text2 = DateTime.Now.ToString("MM/dd/yyy");
            string text3 = DateTime.Now.ToString("HH:mm:ss");
            int num = 0;
            int num2 = 0;
            using (Transaction transaction = new Transaction(document, "Test"))
            {
                transaction.Start();
                foreach (ElementId elementId in list)
                {
                    Element element = document.GetElement(elementId);
                    num2++;
                    try
                    {
                        Parameter parameter = element.GetParameters(text).First<Parameter>();
                        if (parameter != null && parameter.AsString() == "")
                        {
                            parameter.Set(text2);
                        }

                        num++;
                    }
                    catch (Exception)
                    {
                    }
                }

                transaction.Commit();
            }

            stopwatch2.Stop();
            RevitTaskDialog.Show("Time", string.Concat(new string[] { "Time:", stopwatch2.ElapsedMilliseconds.ToString(), "\nTotal Count: ", num2.ToString(), "\nModified Count: ", num.ToString() }));
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
