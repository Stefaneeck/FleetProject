using System;

namespace Models
{
    public class Herstelling
    {
        public long Id { get; set; }
        public DateTime DatumHerstelling { get; set; }
        public string SchadeOmschrijving { get; set; }

        //rel verzekeringsmaatschappij
        public long VerzekeringsMaatschappijId { get; set; }
        public VerzekeringsMaatschappij VerzekeringsMaatschappij { get; set; }

        //opslaan als welk type?
        public string Fotos { get; set; }
        public string Documenten { get; set; }

    }
}
