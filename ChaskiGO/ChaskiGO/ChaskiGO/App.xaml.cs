using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChaskiGO.Pages;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace ChaskiGO
{
	public partial class App : Application
	{
	    public static MobileServiceClient MobileService = new MobileServiceClient("https://chaskigo.azurewebsites.net");
        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new WelcomePage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
