using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000046 RID: 70
	internal class ElementCurveComparerX : IComparer<Element>
	{
		// Token: 0x060001FA RID: 506 RVA: 0x00022CA0 File Offset: 0x00020EA0
		public int Compare(Element a, Element b)
		{
			LocationCurve locationCurve = a.Location as LocationCurve;
			LocationCurve locationCurve2 = b.Location as LocationCurve;
			XYZ endPoint = locationCurve.Curve.GetEndPoint(0);
			XYZ endPoint2 = locationCurve2.Curve.GetEndPoint(0);
			if (endPoint.X == endPoint2.X)
			{
				return 0;
			}
			if (endPoint.X < endPoint2.X)
			{
				return -1;
			}
			return 1;
		}
	}
}
