using System;
using System.Collections.Generic;
using System.Text;

namespace ChaskiGO.Models
{
    public class Incidence
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public string IncidenceType { get; set; }
        public string EmergencyStatus { get; set; }
    }
}
