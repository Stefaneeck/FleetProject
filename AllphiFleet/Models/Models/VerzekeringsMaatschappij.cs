using System.Collections.Generic;

namespace Models
{
    public class VerzekeringsMaatschappij
    {
        public virtual long Id { get; set; }
        public virtual int ReferentieNrVerzekeringsMaatschappij { get; set; }
        public virtual ICollection<Herstelling> Herstellingen { get; set; }
    }
}