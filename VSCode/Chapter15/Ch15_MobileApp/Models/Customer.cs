using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ch15_MobileApp.Models
{
	public class Customer : INotifyPropertyChanged
	{
		public static IList<Customer> Customers;

		static Customer()
		{
			Customers = new ObservableCollection<Customer>();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private string customerID;
		private string companyName;
		private string contactName;
		private string city;
		private string country;
		private string phone;

		public string CustomerID
		{
			get { return customerID; }
			set
			{
				customerID = value;
				if (PropertyChanged != null) PropertyChanged(this,
				  new PropertyChangedEventArgs("CustomerID"));
			}
		}

		public string CompanyName
		{
			get { return companyName; }
			set
			{
				companyName = value;
				if (PropertyChanged != null) PropertyChanged(this,
				  new PropertyChangedEventArgs("CompanyName"));
			}
		}

		public string ContactName
		{
			get { return contactName; }
			set
			{
				contactName = value;
				if (PropertyChanged != null) PropertyChanged(this,
				  new PropertyChangedEventArgs("ContactName"));
			}
		}
		public string City
		{
			get { return city; }
			set
			{
				city = value;
				if (PropertyChanged != null) PropertyChanged(this,
				  new PropertyChangedEventArgs("City"));
			}
		}

		public string Country
		{
			get { return country; }
			set
			{
				country = value;
				if (PropertyChanged != null) PropertyChanged(this,
				  new PropertyChangedEventArgs("Country"));
			}
		}

		public string Phone
		{
			get { return phone; }
			set
			{
				phone = value;
				if (PropertyChanged != null) PropertyChanged(this,
				  new PropertyChangedEventArgs("Phone"));
			}
		}

		public string Location
		{
			get
			{
				return string.Format("{0}, {1}", City, Country);
			}
		}

		// for testing before calling web service
		public static void SampleData()
		{
			Customers.Clear();

			Customers.Add(new Customer
			{
				CustomerID = "ALFKI",
				CompanyName = "Alfreds Futterkiste",
				ContactName = "Maria Anders",
				City = "Berlin",
				Country = "Germany",
				Phone = "030-0074321"
			});

			Customers.Add(new Customer
			{
				CustomerID = "FRANK",
				CompanyName = "Frankenversand",
				ContactName = "Peter Franken",
				City = "München",
				Country = "Germany",
				Phone = "089-0877310"
			});

			Customers.Add(new Customer
			{
				CustomerID = "SEVES",
				CompanyName = "Seven Seas Imports",
				ContactName = "Hari Kumar",
				City = "London",
				Country = "UK",
				Phone = "(171) 555-1717"
			});
		}
	}
}
