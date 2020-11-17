using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Models.Enums;

namespace Models
{
    public class Tankkaart
    {
        public long Id { get; set; }
        public int Kaartnummer { get; set; }
        public DateTime GeldigheidsDatum { get; set; }

        public int Pincode { get; set; }

        public AuthenticatieTypes AuthType { get; set; }

        //enum gebruiken of string? meerdere waarden..
        //public TankkaartOpties Opties { get; set; }
        public string Opties { get; set; }

        //circular reference vermijden
        [JsonIgnore]
        public ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
