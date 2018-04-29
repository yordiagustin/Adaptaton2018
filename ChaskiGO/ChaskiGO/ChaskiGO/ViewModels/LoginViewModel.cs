using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChaskiGO.Helpers;
using ChaskiGO.Models;
using ChaskiGO.Pages;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Members

        private string _phoneNumber;

        #endregion

        #region Properties

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
    

        #endregion

        #region Commands
        
        public ICommand LoginCommand => new Command(async () => await SendAccessCode());


        public ICommand SkipCommand => new Command(async () => await GoToMain());

        #endregion

        #region Constructor

        public LoginViewModel(Page page) : base(page)
        {
        }

        #endregion

        #region CommandMethods
        
        private async Task GoToMain()
        {
            await NavigateToModal(new MainPage());
        }

        #endregion

        #region Methods

        private async Task SendAccessCode()
        {
            try
            {
                IsBusy = true;
                var http = new HttpClient();
                var url = "http://chaskigoapi20180429091803.azurewebsites.net/api/messaging";

                AccessCode accessCode = new AccessCode();

                accessCode.PhoneNumber = PhoneNumber;
                accessCode.SecretCode = GetRandom(1000, 9999).ToString();

                Constants.AccessCode = accessCode.SecretCode;

                var serializer = JsonConvert.SerializeObject(accessCode);

                var content = new StringContent(serializer, Encoding.UTF8, "application/json");

                var response = await http.PostAsync(url, content);

                IsBusy = false;

                await NavigateToModal(new UserVerificationPage());

                return;
            }
            catch (Exception e)
            {
                await OnMessageError();
            }
        }

        #endregion

        #region Private Methods

        public double GetRandom(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        } 

        #endregion
    }
}
