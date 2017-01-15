using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ch15_MobileApp
{
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;

		public ItemDetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
