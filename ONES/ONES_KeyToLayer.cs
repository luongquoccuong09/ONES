using System;
using System.Collections.Generic;

namespace ONES
{
	// Token: 0x0200004E RID: 78
	public class ONES_KeyToLayer
	{
		// Token: 0x06000219 RID: 537 RVA: 0x00022F14 File Offset: 0x00021114
		public ONES_KeyToLayer(string key)
		{
			try
			{
				string[] array = key.Split(new char[]
				{
					';'
				});
				string text = array[0];
				string[] array2 = text.Split(new char[]
				{
					'@'
				});
				this.onesCompound = new ONES_Compound();
				this.onesCompound.Name = array[1];
				List<ONES_Layer> list = new List<ONES_Layer>();
				foreach (string text2 in array2)
				{
					if (!(text2 == ""))
					{
						ONES_Layer ones_Layer = new ONES_Layer();
						string[] array4 = text2.Split(new char[]
						{
							'@'
						});
						string[] array5 = array4[0].Split(new char[]
						{
							'*'
						});
						ones_Layer.Material = array5[0];
						ones_Layer.Width = (double)int.Parse(array5[1]);
						string[] array6 = array4[1].Split(new char[]
						{
							'*'
						});
						ones_Layer.Structural = array6[0];
						ones_Layer.Function = array6[1];
						list.Add(ones_Layer);
					}
				}
				this.onesCompound.Layers = list;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000196 RID: 406
		public ONES_Compound onesCompound;
	}
}
