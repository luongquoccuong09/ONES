using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x020000AC RID: 172
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[Guid("000208D5-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Application
	{
		// Token: 0x060003AE RID: 942
		void _VtblGap1_45();

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060003AF RID: 943
		[DispId(572)]
		Workbooks Workbooks { [DispId(572)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003B0 RID: 944
		void _VtblGap2_1();

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060003B1 RID: 945
		[DispId(494)]
		Sheets Worksheets { [DispId(494)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003B2 RID: 946
		void _VtblGap3_58();

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060003B3 RID: 947
		[DispId(0)]
		string _Default { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060003B4 RID: 948
		void _VtblGap4_168();

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060003B5 RID: 949
		// (set) Token: 0x060003B6 RID: 950
		[DispId(558)]
		bool Visible { [LCIDConversion(0)] [DispId(558)] [MethodImpl(MethodImplOptions.InternalCall)] get; [LCIDConversion(0)] [DispId(558)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}


