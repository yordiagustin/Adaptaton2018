using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChaskiGO.Domain;
using ChaskiGO.Helpers;
using ChaskiGO.Models;
using ChaskiGO.Pages;
using Realms;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class AddContactViewModel : BaseViewModel
    {

        #region Members

        private Contact _contact;
        

        #endregion

        #region Properties

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Commands
        
        public ICommand SaveContactCommand => new Command(async () => await SaveContactOnDb());


        #endregion

        #region Constructor

        public AddContactViewModel(Page page) : base(page)
        {
            Contact = new Contact();
        }

        #endregion

        #region CommandMethods


        #endregion

        #region Methods


        private async Task SaveContactOnDb()
        {
            var vRealmDb = Realm.GetInstance();
            var vEmpId = vRealmDb.All<Contact>().Count() + 1;
            var vContact = new Contact()
            {
                Id = vEmpId,
                Name = Contact.Name,
                PhoneNumber = Contact.PhoneNumber
            };
            vRealmDb.Write(() => {
                vContact = vRealmDb.Add(vContact);
            });
            await ModalNavigateGoBack();
        }

        #endregion
    }
}
