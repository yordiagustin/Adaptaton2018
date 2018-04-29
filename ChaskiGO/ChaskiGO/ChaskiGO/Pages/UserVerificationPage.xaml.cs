using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.Helpers;
using ChaskiGO.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChaskiGO.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserVerificationPage : ContentPage
	{
	    private UserVerificationVIewModel viewModel;
		public UserVerificationPage ()
		{
			InitializeComponent ();
		    BindingContext = viewModel = new UserVerificationVIewModel(this);
		}

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        if (FourDigitsTxt.Text == Constants.AccessCode)
	        {
	            await viewModel.NavigateToModal(new MainPage());
	            return;
	        }

	        await viewModel.OnMessage("Código no válido");
	        await viewModel.ModalNavigateGoBack();
        }
	}
}