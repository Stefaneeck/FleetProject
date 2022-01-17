namespace Models
{
    public class LicensePlate : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string LicensePlateCharacters { get; set; }
        public virtual bool Active { get; set; }

        //rel vehicle
        public virtual long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}