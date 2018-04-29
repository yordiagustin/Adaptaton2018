using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.Models;
using ChaskiGO.ViewModels;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ChaskiGO.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlertsPage : ContentPage
	{
	    private AlertsViewModel viewModel;
		public AlertsPage ()
		{
			InitializeComponent ();
		    BindingContext = viewModel = new AlertsViewModel(this);
		    SetCurrentLocationMap();
		    SetPins();
        }

	    private async void SetCurrentLocationMap()
	    {
	        MyMap.IsShowingUser = false;
	        MyMap.MapType = MapType.Street;
            if (!CrossGeolocator.IsSupported)
	            return;
	        var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));
	        MyMap.MoveToRegion(
	            MapSpan.FromCenterAndRadius(
	                new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            MyMap.IsShowingUser = true;
	    }
	    private async void SetPins()
	    {
	        List<Incidence> list = await viewModel.GetAllIncidences();
	        foreach (var item in list)
	        {
	            MyMap.Pins.Add(new Pin()
	            {
                  Label = item.Title,
                  Address = item.Description,
                  Position =  new Position(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude)),
                  Type = PinType.Place
	            });
	        }
	    }

	    private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new AddIncidence());
	    }
	}
}