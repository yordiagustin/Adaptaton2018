using System;
using System.Collections.Generic;
using System.Text;

namespace ChaskiGO.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VerificationCode { get; set; }
    }
}
