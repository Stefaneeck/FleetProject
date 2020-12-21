namespace Models
{
    public class Nummerplaat : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string NummerPlaatTekens { get; set; }

        //rel voertuig
        public virtual long VoertuigId { get; set; }
        public virtual Voertuig Voertuig { get; set; }
    }
}