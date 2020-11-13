using System.Collections.Generic;

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
        public ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
