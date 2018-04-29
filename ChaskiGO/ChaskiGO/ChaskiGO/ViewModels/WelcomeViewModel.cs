using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ChaskiGO.Pages;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        #region Members


        #endregion

        #region Properties



        #endregion

        #region Commands

        public ICommand NavigateToLoginCommand => new Command(async () => await NavigateTo(new LoginPage()));
        public ICommand NavigateToRegisterCommand => new Command(async () => await NavigateTo(new RegisterPage()));

        #endregion

        #region Constructor

        public WelcomeViewModel(Page page) : base(page)
        {
        }

        #endregion

        #region CommandMethods


        #endregion

        #region Methods




        #endregion
    }
}
