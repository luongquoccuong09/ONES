using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x020000A6 RID: 166
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[Guid("000208D7-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Sheets : IEnumerable
	{
		// Token: 0x060003A8 RID: 936
		void _VtblGap1_3();

		// Token: 0x060003A9 RID: 937
		[LCIDConversion(4)]
		[DispId(181)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Before, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object After, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Count, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Type);

		// Token: 0x060003AA RID: 938
		void _VtblGap2_4();

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060003AB RID: 939
		[DispId(170)]
		object Item { [DispId(170)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.IDispatch)] get; }
	}
}
