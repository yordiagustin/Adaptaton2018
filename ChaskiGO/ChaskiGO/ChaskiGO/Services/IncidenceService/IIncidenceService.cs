using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.Models;

namespace ChaskiGO.Services.IncidenceService
{
    public interface IIncidenceService
    {
        Task SaveIncidence(Incidence incidence);
        Task<List<Incidence>> GetAll();
    }
}
