namespace Models
{
    public class Nummerplaat
    {
        public long Id { get; set; }
        public string NummerPlaatTekens { get; set; }

        //rel voertuig
        public long VoertuigId { get; set; }

        public Voertuig Voertuig { get; set; }
    }
}