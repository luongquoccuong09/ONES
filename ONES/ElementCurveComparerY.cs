using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000047 RID: 71
	internal class ElementCurveComparerY : IComparer<Element>
	{
		// Token: 0x060001FC RID: 508 RVA: 0x00022D00 File Offset: 0x00020F00
		public int Compare(Element a, Element b)
		{
			LocationCurve locationCurve = a.Location as LocationCurve;
			LocationCurve locationCurve2 = b.Location as LocationCurve;
			XYZ endPoint = locationCurve.Curve.GetEndPoint(0);
			XYZ endPoint2 = locationCurve2.Curve.GetEndPoint(0);
			if (endPoint.Y == endPoint2.Y)
			{
				return 0;
			}
			if (endPoint.Y < endPoint2.Y)
			{
				return -1;
			}
			return 1;
		}
	}
}
