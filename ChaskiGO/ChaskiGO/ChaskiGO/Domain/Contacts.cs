using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace ChaskiGO.Domain
{
    public class Contact : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

}
