using System.Collections.Generic;

using Xamarin.Forms;

namespace Ch15_MobileApp
{
	public partial class App : Application
	{
		public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
		public static string AzureMobileAppUrl = "http://localhost:5000";
		public static IDictionary<string, string> LoginParameters => null;

		public App()
		{
			InitializeComponent();

			if (AzureNeedsSetup)
				DependencyService.Register<MockDataStore>();
			else
				DependencyService.Register<CloudDataStore>();

			SetMainPage();
		}

		public static void SetMainPage()
		{
			if (!AzureNeedsSetup && !Settings.IsLoggedIn)
			{
				Current.MainPage = new NavigationPage(new LoginPage())
				{
					BarBackgroundColor = (Color)Current.Resources["Primary"],
					BarTextColor = Color.White
				};
			}
			else
			{
				GoToMainPage();
			}
		}

		public static void GoToMainPage()
		{
			Current.MainPage = new TabbedPage
			{
				Children = {
					new NavigationPage(new ItemsPage())
					{
						Title = "Browse"
					},
					new NavigationPage(new AboutPage())
					{
						Title = "About"
					},
				}
			};
		}
	}
}
