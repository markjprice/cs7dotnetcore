using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ch15_MobileApp
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }
		public ItemDetailViewModel(Item item = null)
		{
			Title = item.Text;
			Item = item;
		}

		int quantity = 1;
		public int Quantity
		{
			get { return quantity; }
			set { SetProperty(ref quantity, value); }
		}
	}
}
