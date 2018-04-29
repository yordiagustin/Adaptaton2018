using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChaskiGO.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddIncidence : ContentPage
	{
	    private AddIncidenceViewModel viewModel;
		public AddIncidence ()
		{
			InitializeComponent ();
		    BindingContext = viewModel = new AddIncidenceViewModel(this);
		}
	}
}