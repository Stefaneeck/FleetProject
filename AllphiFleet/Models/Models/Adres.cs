using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Adres : IIdentifiable
    {
        public long Id { get; set; }
        public string Straat { get; set; }
        public int Nummer { get; set; }
        public string Stad { get; set; }
        public int Postcode { get; set; }
        //public int ChauffeurId { get; set; }

        //jsonignore voor circular reference bij ophalen van data te omzeilen. betere oplossing zoeken?
        [JsonIgnore]
        public ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
