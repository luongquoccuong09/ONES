using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000043 RID: 67
	internal class ElementIdComparer : IEqualityComparer<ElementId>
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x00022C2C File Offset: 0x00020E2C
		public bool Equals(ElementId x, ElementId y)
		{
			return !(x == null) && !(y == null) && x.Equals(y);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00022C49 File Offset: 0x00020E49
		public int GetHashCode(ElementId obj)
		{
			return obj.IntegerValue;
		}
	}
}
