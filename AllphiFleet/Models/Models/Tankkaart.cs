using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Models.Enums;

namespace Models
{
    public class Tankkaart
    {
        public virtual long Id { get; set; }
        public virtual int Kaartnummer { get; set; }
        public virtual DateTime GeldigheidsDatum { get; set; }

        public virtual int Pincode { get; set; }

        public virtual AuthenticatieTypes AuthType { get; set; }

        //enum gebruiken of string? meerdere waarden..
        //public TankkaartOpties Opties { get; set; }
        public virtual string Opties { get; set; }

        //circular reference vermijden
        [JsonIgnore]
        public virtual ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
