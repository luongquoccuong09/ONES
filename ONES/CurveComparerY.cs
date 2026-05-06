using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000049 RID: 73
	internal class CurveComparerY : IComparer<Curve>
	{
		// Token: 0x06000200 RID: 512 RVA: 0x00022DA0 File Offset: 0x00020FA0
		public int Compare(Curve a, Curve b)
		{
			XYZ endPoint = a.GetEndPoint(0);
			XYZ endPoint2 = b.GetEndPoint(0);
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
