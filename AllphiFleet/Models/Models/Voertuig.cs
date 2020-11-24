using System.Collections.Generic;
using System.Text.Json.Serialization;
using Models.Enums;

namespace Models
{
    public class Voertuig
    {
        public virtual long Id { get; set; }
        public virtual long ChassisNr { get; set; }
        public virtual ICollection<Nummerplaat> Nummerplaten { get; set; }

        public virtual BrandstofTypes TypeBrandStof { get; set; }
        
        public virtual WagenTypes TypeWagen { get; set; }

        public virtual int KilometerStand { get; set; }

        public virtual ICollection<Onderhoud> OnderhoudsBeurten { get; set; }

        [JsonIgnore]
        public virtual ICollection<Aanvraag> Aanvragen { get; set; }
    }
}
