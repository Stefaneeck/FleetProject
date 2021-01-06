using System.Collections.Generic;

namespace ModelsStandard
{
    public class Adres : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string Straat { get; set; }
        public virtual int Nummer { get; set; }
        public virtual string Stad { get; set; }
        public virtual int Postcode { get; set; }
        public virtual ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
