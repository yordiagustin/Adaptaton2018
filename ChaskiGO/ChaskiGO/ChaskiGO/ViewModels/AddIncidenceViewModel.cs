using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChaskiGO.Models;
using ChaskiGO.Services.IncidenceService;
using ChaskiGO.Services.MediaService;
using ChaskiGO.Services.StorageService;
using Plugin.Geolocator;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class AddIncidenceViewModel : BaseViewModel
    {
        #region Members

        private readonly IIncidenceService _incidenceService;
        private readonly IStorageService _storageService;
        private readonly IMediaService _mediaService;

        private MediaFile _picture;

        private Incidence _incidence;

        #endregion

        #region Properties

        public MediaFile Picture
        {
            get => _picture;
            set
            {
                _picture = value;
                OnPropertyChanged();
            }
        }

        public Incidence Incidence
        {
            get => _incidence;
            set
            {
                _incidence = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand NavigateToBackCommand => new Command(async () => await NavigateGoBack());
        public ICommand PostIncidenceCommand => new Command(async () => await PostIncidence());

        public ICommand TakePhotoCommand => new Command(async () => await TakePicture());

        #endregion

        #region Constructor

        public AddIncidenceViewModel(Page page) : base(page)
        {
            _incidenceService = new IncidenceService();
            _storageService = new StorageService();
            _mediaService = new MediaService();
            Incidence = new Incidence();
        }

        #endregion

        #region Command Methods

        private async Task PostIncidence()
        {
            IsBusy = true;
            try
            {
                //Set Picture URL to Photo
                var pictureUrl = await _storageService.UploadImage(Picture.GetStream());
                Incidence.ImageUrl = pictureUrl;
                //Get Realtime Position (GPS)
                var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));
                Incidence.Longitude = position.Longitude.ToString();
                Incidence.Latitude = position.Latitude.ToString();
                Incidence.Status = "Por Observar";
                Incidence.EmergencyStatus = "Incidencia";
                Incidence.IncidenceType = "Incidencia";
                await _incidenceService.SaveIncidence(Incidence);
                IsBusy = false;
                await OnMessage("¡Tu incidencia  fue reportada!");
                await ModalNavigateGoBack();
            }
            catch (Exception e)
            {
                await OnMessageError();
                Console.WriteLine(e);
                //throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task TakePicture()
        {
            var picture = await _mediaService.TakePicture();
            if (picture != null)
            {
                Picture = picture;
                return;
            }
            else
            {
                await OnMessage("¡Vamos! ¡Intenta otra vez!");
            }

        }

        #endregion

        #region Private Methods



        #endregion
    }
}
