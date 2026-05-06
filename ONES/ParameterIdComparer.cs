using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000044 RID: 68
	internal class ParameterIdComparer : IEqualityComparer<Parameter>
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x00022C51 File Offset: 0x00020E51
		public bool Equals(Parameter x, Parameter y)
		{
			return x != null && y != null && x.Id.Equals(y.Id);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00022C6C File Offset: 0x00020E6C
		public int GetHashCode(Parameter obj)
		{
			return obj.Id.IntegerValue;
		}
	}
}
