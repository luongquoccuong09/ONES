using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ONES
{
    // Token: 0x02000081 RID: 129
    [Transaction(TransactionMode.Manual)]
    public class LinkSelectType : IExternalCommand
    {
        // Token: 0x060002DB RID: 731 RVA: 0x0002C770 File Offset: 0x0002A970
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUIDocument = application.ActiveUIDocument;
            Application application2 = application.Application;
            Document document = activeUIDocument.Document;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Selection selection = activeUIDocument.Selection;
            ICollection<ElementId> elementIds = selection.GetElementIds();
            Reference reference;
            try
            {
                reference = selection.PickObject(ObjectType.LinkedElement, "Please pick an element in the linked model");
            }
            catch (OperationCanceledException)
            {
                return Result.Cancelled;
            }

            TaskDialog.Show("first", reference.ElementId.ToString());
            TaskDialog.Show("second", reference.LinkedElementId.ToString());
            ElementId linkedElementId = reference.LinkedElementId;
            IEnumerable<Document> linkedDocuments = Utils.GetLinkedDocuments(document);
            Element element = null;
            List<ElementId> list = new List<ElementId>();
            Document document2 = null;
            foreach (Document document3 in linkedDocuments)
            {
                try
                {
                    element = document3.GetElement(linkedElementId);
                    document2 = document3;
                }
                catch (Exception)
                {
                }

                if (element != null)
                {
                    break;
                }
            }

            TaskDialog.Show("element name", element.Name);
            List<ElementId> list2 = new List<ElementId>();
            ElementId typeId = element.GetTypeId();
            Element element2 = document2.GetElement(typeId);
            string name = element2.Name;
            TaskDialog.Show("type name", name);
            try
            {
                string familyname = (element2 as FamilySymbol).FamilyName;
                List<Element> list3 = (
                    from x in new FilteredElementCollector(document2).WhereElementIsNotElementType()
                    where ((FamilyInstance)x).Symbol.Family.Name.Equals(familyname)
                    where x.Name.Equals(name)select x).Cast<Element>().ToList<Element>();
                foreach (Element element3 in list3)
                {
                    list2.Add(element3.Id);
                }
            }
            catch (Exception)
            {
                List<Element> list3 = (
                    from x in new FilteredElementCollector(document2).WhereElementIsNotElementType()
                    where x.Name.Equals(name)select x).Cast<Element>().ToList<Element>();
                foreach (Element element4 in list3)
                {
                    list2.Add(element4.Id);
                }
            }

            TaskDialog.Show("final", list2.Count.ToString());
            application.ActiveUIDocument.Selection.SetElementIds(list2);
            stopwatch.Stop();
            Utils.ONESLogs(activeUIDocument, this.ToString(), stopwatch);
            return Result.Succeeded;
        }
    }
}
