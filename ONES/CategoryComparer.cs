using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000042 RID: 66
	internal class CategoryComparer : IEqualityComparer<Category>
	{
		// Token: 0x060001EE RID: 494 RVA: 0x00022C04 File Offset: 0x00020E04
		public bool Equals(Category x, Category y)
		{
			return x != null && y != null && x.Id.Equals(y.Id);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00022C1F File Offset: 0x00020E1F
		public int GetHashCode(Category obj)
		{
			return obj.Id.IntegerValue;
		}
	}
}
