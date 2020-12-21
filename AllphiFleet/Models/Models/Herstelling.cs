using System;

namespace Models
{
    public class Herstelling : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual DateTime DatumHerstelling { get; set; }
        public virtual string SchadeOmschrijving { get; set; }

        //rel verzekeringsmaatschappij
        public virtual long VerzekeringsMaatschappijId { get; set; }
        public virtual VerzekeringsMaatschappij VerzekeringsMaatschappij { get; set; }
        public virtual string Fotos { get; set; }
        public virtual string Documenten { get; set; }
    }
}
