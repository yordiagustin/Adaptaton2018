using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChaskiGO.Helpers;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand GoBack { get; set; }

        public Page page;
        public PopupPage popupPage;

        public BaseViewModel(Page page)
        {
            this.page = page;
            GoBack = new Command(async () => await NavigateGoBack());
        }

        public BaseViewModel()
        {
        }

        public BaseViewModel(PopupPage popupPage)
        {
            this.popupPage = popupPage;
            GoBack = new Command(async () => await NavigatePopUpBack());
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public async Task NavigatePopUpBack()
        {
            await this.popupPage.Navigation.PopPopupAsync();
        }

        public async Task ModalPopUp(PopupPage page)
        {
            await PopupNavigation.PushAsync(page);
        }

        public async Task ModalNavigateGoBack()
        {
            await this.page.Navigation.PopModalAsync();
        }

        public async Task NavigateGoBack()
        {
            await this.page.Navigation.PopAsync();
        }

        public async Task NavigateTo(Page pageView)
        {
            await this.page.Navigation.PushAsync(pageView);
        }

        public async Task NavigateToModal(Page modalView)
        {
            await page.Navigation.PushModalAsync(modalView);
        }

        public void NavigatePageInit(Page pageView)
        {
            Application.Current.MainPage = new NavigationPage(pageView)
            {
                //BarTextColor = Color.White,
                //BarBackgroundColor = Color.FromHex("#3893CF")
            };
        }

        public void NavigatePageCurrent(Page pageView)
        {
            Application.Current.MainPage = pageView;
        }

        public void ClearNavigationStack()
        {
            var history = page.Navigation.NavigationStack.ToList();

            for (var i = 0; i < history.Count - 1; i++)
            {
                page.Navigation.RemovePage(history[i]);
            }
        }

        public void DeleteBeforePage()
        {
            page.Navigation.RemovePage(page.Navigation.NavigationStack[page.Navigation.NavigationStack.Count - 2]);
        }

        public async Task OnMessageError()
        {
            await page.DisplayAlert(Constants.CompanyName, Constants.MessageError, Constants.OkMessage);
        }

        public async Task OnMessage(string message)
        {
            await page.DisplayAlert(Constants.CompanyName, message, Constants.OkMessage);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
