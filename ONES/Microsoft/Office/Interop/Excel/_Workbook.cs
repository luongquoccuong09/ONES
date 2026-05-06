using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x020000AD RID: 173
	[CompilerGenerated]
	[Guid("000208DA-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Workbook
	{
		// Token: 0x060003B7 RID: 951
		void _VtblGap1_105();

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060003B8 RID: 952
		[DispId(485)]
		Sheets Sheets { [DispId(485)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
