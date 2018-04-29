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
	public partial class AddContact : ContentPage
	{
		public AddContact ()
		{
			InitializeComponent ();
		    BindingContext = new AddContactViewModel(this);
		}
	}
}