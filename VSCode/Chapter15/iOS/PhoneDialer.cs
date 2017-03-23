using Foundation;
using Ch15_MobileApp.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Ch15_MobileApp.iOS
{
	public class PhoneDialer : IDialer
	{
		public bool Dial(string number)
		{
			return UIApplication.SharedApplication.OpenUrl(
					  new NSUrl("tel:" + number));
		}
	}
}
