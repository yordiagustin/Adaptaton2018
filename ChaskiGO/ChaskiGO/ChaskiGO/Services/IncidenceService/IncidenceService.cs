using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.Models;

namespace ChaskiGO.Services.IncidenceService
{
    public class IncidenceService : IIncidenceService
    {
        public async Task SaveIncidence(Incidence incidence)
        {
            if (incidence != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<Incidence>();
                    await tabla.InsertAsync(incidence);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task<List<Incidence>> GetAll()
        {
            List<Incidence> coleccion = new List<Incidence>();
            try
            {
                var tabla = App.MobileService.GetTable<Incidence>();
                coleccion = await tabla.ToListAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
            }
            return coleccion;
        }
    }
}
