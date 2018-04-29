using System;
using System.Collections.Generic;
using System.Text;

namespace ChaskiGO.Models
{
    public class Emergency
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string EmergencyStatus { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string FullName { get; set; }
    }
}
