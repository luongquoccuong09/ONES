using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace ONES
{
    // Token: 0x0200004F RID: 79
    [Transaction(TransactionMode.Manual)]
    public class FamilyChange : IExternalCommand
    {
        // Token: 0x0600021A RID: 538 RVA: 0x00023050 File Offset: 0x00021250
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Autodesk.Revit.DB.View activeView = activeUIDocument.ActiveView;
            Selection selection = activeUIDocument.Selection;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Element element;
            try
            {
                element = Utils.SelectPickElement(activeUIDocument);
                if (element == null)
                {
                    return Result.Failed;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return Result.Failed;
            }

            FamilyChangeForm familyChangeForm = new FamilyChangeForm(activeUIDocument, element);
            DialogResult dialogResult = familyChangeForm.ShowDialog();
            if (dialogResult == DialogResult.Abort)
            {
                return Result.Failed;
            }

            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}