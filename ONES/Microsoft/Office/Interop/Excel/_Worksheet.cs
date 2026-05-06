using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x020000AE RID: 174
	[CompilerGenerated]
	[Guid("000208D8-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Worksheet
	{
		// Token: 0x060003B9 RID: 953
		void _VtblGap1_11();

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060003BA RID: 954
		// (set) Token: 0x060003BB RID: 955
		[DispId(110)]
		string Name { [DispId(110)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(110)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x060003BC RID: 956
		void _VtblGap2_32();

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060003BD RID: 957
		[DispId(238)]
		Range Cells { [DispId(238)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003BE RID: 958
		void _VtblGap3_47();

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060003BF RID: 959
		[DispId(197)]
		Range Range { [DispId(197)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
