using Ch15_MobileApp.Models;
using Xamarin.Forms;

namespace Ch15_MobileApp
{
	public partial class CustomerDetail : ContentPage
	{
		private bool newCustomer = false;

		public CustomerDetail()
		{
			InitializeComponent();
			BindingContext = new Customer();
			newCustomer = true;
			Title = "Add Customer";
		}

		public CustomerDetail(Customer customer)
		{
			InitializeComponent();
			BindingContext = customer;
			InsertButton.IsVisible = false;
		}

		async void InsertButton_Clicked(
		  object sender, System.EventArgs e)
		{
			if (newCustomer)
			{
				Customer.Customers.Add((Customer)BindingContext);
			}
			await Navigation.PopAsync(animated: true);
		}
	}
}
