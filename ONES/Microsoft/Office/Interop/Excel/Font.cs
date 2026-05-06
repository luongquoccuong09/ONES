using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x020000A4 RID: 164
	[CompilerGenerated]
	[InterfaceType(2)]
	[Guid("0002084D-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Font
	{
		// Token: 0x0600039C RID: 924
		void _VtblGap1_5();

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600039D RID: 925
		// (set) Token: 0x0600039E RID: 926
		[DispId(96)]
		object Bold { [DispId(96)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(96)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
