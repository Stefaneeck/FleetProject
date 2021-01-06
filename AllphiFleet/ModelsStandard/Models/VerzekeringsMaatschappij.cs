using System.Collections.Generic;

namespace ModelsStandard
{
    public class VerzekeringsMaatschappij : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual int ReferentieNrVerzekeringsMaatschappij { get; set; }
        public virtual ICollection<Herstelling> Herstellingen { get; set; }
    }
}