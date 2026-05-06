using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x0200004A RID: 74
	internal class GridComparer : IComparer<Grid>
	{
		// Token: 0x06000202 RID: 514 RVA: 0x00022DE0 File Offset: 0x00020FE0
		public int Compare(Grid a, Grid b)
		{
			XYZ endPoint = a.Curve.GetEndPoint(0);
			XYZ endPoint2 = b.Curve.GetEndPoint(0);
			Line line = a.Curve as Line;
			double num = Math.Round(Math.Abs(line.Direction.X), 5);
			if (num == 0.0)
			{
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
			else
			{
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
}
