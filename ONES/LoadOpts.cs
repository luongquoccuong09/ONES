using System;
using Autodesk.Revit.DB;

namespace ONES
{
	// Token: 0x0200004B RID: 75
	internal class LoadOpts : IFamilyLoadOptions
	{
		// Token: 0x06000204 RID: 516 RVA: 0x00022E79 File Offset: 0x00021079
		public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
		{
			overwriteParameterValues = true;
			return true;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00022E7F File Offset: 0x0002107F
		public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
		{
            source = (FamilySource)1;
            overwriteParameterValues = true;
			return true;
		}
	}
}
