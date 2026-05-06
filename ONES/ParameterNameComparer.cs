using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x02000045 RID: 69
	internal class ParameterNameComparer : IEqualityComparer<Parameter>
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x00022C79 File Offset: 0x00020E79
		public bool Equals(Parameter x, Parameter y)
		{
			return x != null && y != null && x.Definition.Name.Equals(y.Definition.Name);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00022C6C File Offset: 0x00020E6C
		public int GetHashCode(Parameter obj)
		{
			return obj.Id.IntegerValue;
		}
	}
}
