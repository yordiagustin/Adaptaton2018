using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChaskiGO.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();
	        await SosButton.ScaleTo(1.2, 2000);
        }

	    private void EmergencyCallButton_OnClicked(object sender, EventArgs e)
	    {
	        var phoneDialer = CrossMessaging.Current.PhoneDialer;
	        if (phoneDialer.CanMakePhoneCall)
	            phoneDialer.MakePhoneCall("911");
        }

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new AlertsPage());
	    }
	}
}