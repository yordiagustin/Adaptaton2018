using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChaskiGO.Models;
using ChaskiGO.Pages;
using ChaskiGO.Services.IncidenceService;
using ChaskiGO.Services.MediaService;
using ChaskiGO.Services.StorageService;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class AlertsViewModel : BaseViewModel
    {
        #region Members

        private readonly IIncidenceService _incidenceService;

        private List<Incidence> _incidences;

        #endregion

        #region Properties

        public List<Incidence> Incidences
        {
            get => _incidences;
            set
            {
                _incidences = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        

        #endregion

        #region Constructor

        public AlertsViewModel(Page page) : base(page)
        {
            _incidenceService = new IncidenceService();
            Incidences = new List<Incidence>();
        }

        #endregion

        #region Command Methods
        

        #endregion

        #region Public Methods

        public async Task<List<Incidence>> GetAllIncidences()
        {
            Incidences = await _incidenceService.GetAll();
            return Incidences;
        }

        #endregion
    }
}
