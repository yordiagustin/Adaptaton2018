using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChaskiGO.Helpers;
using ChaskiGO.Models;
using ChaskiGO.Pages;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class UserVerificationVIewModel : BaseViewModel
    {
        #region Members

        private string _accessCode;

        #endregion

        #region Properties

        public string AcessCode
        {
            get => _accessCode;
            set
            {
                _accessCode = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand => new Command(async () => await ValidateCode());

        #endregion

        #region Constructor

        public UserVerificationVIewModel(Page page) : base(page)
        {
            AcessCode = string.Empty;
        }


        #endregion

        #region Private Methods
        
        private async Task ValidateCode()
        {
            if (AcessCode == Constants.AccessCode)
            {
                await NavigateToModal(new MainPage());
                return;
            }

            await OnMessage("Código no válido");
            await ModalNavigateGoBack();
        }

        #endregion
    }
}
