using System.Collections.Generic;

namespace Models
{
    public class Adres : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string Straat { get; set; }
        public virtual int Nummer { get; set; }
        public virtual string Stad { get; set; }
        public virtual int Postcode { get; set; }
        //public int ChauffeurId { get; set; }

        //jsonignore voor circular reference bij ophalen van data te omzeilen. betere oplossing zoeken?
        //[JsonIgnore]
        public virtual ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
