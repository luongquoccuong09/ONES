using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ONES
{
	// Token: 0x02000079 RID: 121
	public partial class CoffeeTimeForm : Form
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x00029B5F File Offset: 0x00027D5F
		public CoffeeTimeForm(string quote)
		{
			this.InitializeComponent();
			this._quote = quote;
			this.textBox1.Text = quote;
			base.CancelButton = this.buttonDrink;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00029B8C File Offset: 0x00027D8C
		private void CoffeeTimeForm_Load(object sender, EventArgs e)
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
			base.Update();
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000A5F1 File Offset: 0x000087F1
		private void buttonDrink_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040001E5 RID: 485
		private string _quote;
	}
}
