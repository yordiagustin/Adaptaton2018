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
using Plugin.Geolocator;
using Xamarin.Forms;

namespace ChaskiGO.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand SosCommand => new Command(async () => await GoSOS());

        private async Task GoSOS()
        {
            try
            {
                IsBusy = true;
                var http = new HttpClient();
                var url = "http://chaskigoapi20180429091803.azurewebsites.net/api/messaging";

                var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));
                var emergencyLongitude = position.Longitude.ToString();
                var emergencyLatitude = position.Latitude.ToString();

                var emergency = new Emergency()
                {
                    Title = "EMERGENCIA",
                    Description = "ALERTA MÁXIMA",
                    EmergencyStatus = "ALERTA ROJA",
                    FullName = "YORDI AGUSTIN PAREDES",
                    Latitude = emergencyLatitude,
                    Longitude = emergencyLongitude
                };
                
               

                var serializer = JsonConvert.SerializeObject(emergency);

                var content = new StringContent(serializer, Encoding.UTF8, "application/json");

                var response = await http.PostAsync(url, content);

                IsBusy = false;

                await OnMessage(
                    "Se acaba de avisar a todos sus contactos cercanos, estar alerta ante cualquier situación. ¡Estamos para apoyarte!");

                return;
            }
            catch (Exception e)
            {
                await OnMessageError();
            }
        }
    }
}
