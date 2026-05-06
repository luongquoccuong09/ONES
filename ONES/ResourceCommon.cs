using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ONES
{
	// Token: 0x02000031 RID: 49
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class ResourceCommon
	{
		// Token: 0x060000FE RID: 254 RVA: 0x000021B0 File Offset: 0x000003B0
		internal ResourceCommon()
		{
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00015D8C File Offset: 0x00013F8C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (ResourceCommon.resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("ONES.ResourceCommon", typeof(ResourceCommon).Assembly);
					ResourceCommon.resourceMan = resourceManager;
				}
				return ResourceCommon.resourceMan;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00015DC5 File Offset: 0x00013FC5
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00015DCC File Offset: 0x00013FCC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return ResourceCommon.resourceCulture;
			}
			set
			{
				ResourceCommon.resourceCulture = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00015DD4 File Offset: 0x00013FD4
		internal static string Collaboration
		{
			get
			{
				return ResourceCommon.ResourceManager.GetString("Collaboration", ResourceCommon.resourceCulture);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00015DEA File Offset: 0x00013FEA
		internal static string Export
		{
			get
			{
				return ResourceCommon.ResourceManager.GetString("Export", ResourceCommon.resourceCulture);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00015E00 File Offset: 0x00014000
		internal static string Generate
		{
			get
			{
				return ResourceCommon.ResourceManager.GetString("Generate", ResourceCommon.resourceCulture);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00015E16 File Offset: 0x00014016
		internal static string Modify
		{
			get
			{
				return ResourceCommon.ResourceManager.GetString("Modify", ResourceCommon.resourceCulture);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00015E2C File Offset: 0x0001402C
		internal static string Review
		{
			get
			{
				return ResourceCommon.ResourceManager.GetString("Review", ResourceCommon.resourceCulture);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00015E42 File Offset: 0x00014042
		internal static string Select
		{
			get
			{
				return ResourceCommon.ResourceManager.GetString("Select", ResourceCommon.resourceCulture);
			}
		}

		// Token: 0x040000E9 RID: 233
		private static ResourceManager resourceMan;

		// Token: 0x040000EA RID: 234
		private static CultureInfo resourceCulture;
	}
}
