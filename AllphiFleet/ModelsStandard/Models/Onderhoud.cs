using System;

namespace ModelsStandard
{
    public class Onderhoud : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual DateTime DatumOnderhoud { get; set; }
        public virtual decimal Prijs { get; set; }
        public virtual string Garage { get; set; }

        //rel factuur
        public virtual long FactuurId { get; set; }
        public virtual Factuur Factuur { get; set; }

        //rel voertuig
        public virtual long VoertuigId { get; set; }
        public virtual Voertuig Voertuig { get; set; }
    }
}
