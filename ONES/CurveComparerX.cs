using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000048 RID: 72
	internal class CurveComparerX : IComparer<Curve>
	{
		// Token: 0x060001FE RID: 510 RVA: 0x00022D60 File Offset: 0x00020F60
		public int Compare(Curve a, Curve b)
		{
			XYZ endPoint = a.GetEndPoint(0);
			XYZ endPoint2 = b.GetEndPoint(0);
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
