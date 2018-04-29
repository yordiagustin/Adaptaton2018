using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChaskiGO.Helpers;
using ChaskiGO.Pages;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Members
        
      

        #endregion

        #region Properties



        #endregion

        #region Commands

        public ICommand LoginCommand => new Command(async () => await Login());
        public ICommand RegisterCommand => new Command(async () => await GoToMain());


        #endregion

        #region Constructor

        public LoginViewModel(Page page) : base(page)
        {
            //User = new User();
            //_encryptionService = new EncryptionService();
            //_userService = new UserService();
        }

        #endregion

        #region CommandMethods

        private async Task Login()
        {
            //IsBusy = true;
            //try
            //{
            //    if (User.Email != string.Empty || User.Password != string.Empty)
            //    {
            //        var pass = _encryptionService.EncryptAes(User.Password, Constants.EncryptionKey);
            //        var validated = await _userService.Login(User.Email, pass);
            //        if (validated == null)
            //        {
            //            await OnMessage("Datos Incorrectos");
            //            User = new User();
            //            IsBusy = false;
            //            return;
            //        }

            //        await SaveUserOnDb(validated, User.Password);

            //        Settings.SaveUserId = validated.Id;
            //        Constants.User = validated;
            //        Constants.User.Password = User.Password;
            //        IsBusy = false;
            //        Settings.IsLogged = true;
            //        await NavigateToModal(new MainTabbedPage());
            //    }
            //    else
            //    {
            //        await OnMessage("Completa tus datos");
            //        IsBusy = false;
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await OnMessageError();
            //    User = new User();
            //    IsBusy = false;
            //}
        }

        private async Task GoToMain()
        {
            await NavigateToModal(new MainPage());
        }

        #endregion

        #region Methods


        #endregion
    }
}
