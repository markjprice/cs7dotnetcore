using System;

using Xamarin.Forms;

namespace Ch15_MobileApp
{
	public class CustomerDetails : ContentPage
	{
		public CustomerDetails()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

