using System;
using System.Collections.Generic;

namespace ONES
{
	// Token: 0x0200004D RID: 77
	public class ONES_Compound
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00022EDE File Offset: 0x000210DE
		// (set) Token: 0x06000213 RID: 531 RVA: 0x00022EE6 File Offset: 0x000210E6
		public string Name { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00022EEF File Offset: 0x000210EF
		// (set) Token: 0x06000215 RID: 533 RVA: 0x00022EF7 File Offset: 0x000210F7
		public List<ONES_Layer> Layers { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00022F00 File Offset: 0x00021100
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00022F08 File Offset: 0x00021108
		public string Fugou { get; set; }
	}
}
