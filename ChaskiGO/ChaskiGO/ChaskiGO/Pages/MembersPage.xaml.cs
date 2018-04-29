using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.Domain;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChaskiGO.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MembersPage : ContentPage
	{
	    
		public MembersPage ()
		{
			InitializeComponent ();
		}


	    private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new AddContact());
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        var realm = Realm.GetInstance();
	        ContactsList.ItemsSource = realm.All<Contact>();
        }
	}
}