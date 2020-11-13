using System.Collections.Generic;

namespace Models
{
    public class VerzekeringsMaatschappij
    {
        public long Id { get; set; }
        public int ReferentieNrVerzekeringsMaatschappij { get; set; }
        public ICollection<Herstelling> Herstellingen { get; set; }
    }
}