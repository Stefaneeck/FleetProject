using System;

namespace Models
{
    public class Onderhoud
    {
        public long Id { get; set; }
        public DateTime DatumOnderhoud { get; set; }
        public decimal Prijs { get; set; }
        public string Garage { get; set; }

        //rel factuur
        public long FactuurId { get; set; }
        public Factuur Factuur { get; set; }

        //rel voertuig
        public long VoertuigId { get; set; }
        public Voertuig Voertuig { get; set; }
    }
}
