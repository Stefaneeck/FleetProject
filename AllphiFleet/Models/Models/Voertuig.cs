using System.Collections.Generic;
using System.Text.Json.Serialization;
using Models.Enums;

namespace Models
{
    public class Voertuig
    {
        public long Id { get; set; }
        public ICollection<Nummerplaat> Nummerplaten { get; set; }

        public BrandstofTypes TypeBrandStof { get; set; }
        
        public WagenTypes TypeWagen { get; set; }

        public int KilometerStand { get; set; }

        public ICollection<Onderhoud> OnderhoudsBeurten { get; set; }

        [JsonIgnore]
        public ICollection<Aanvraag> Aanvragen { get; set; }
    }
}
