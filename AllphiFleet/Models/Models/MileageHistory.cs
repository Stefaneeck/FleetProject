
namespace Models
{
    public class MileageHistory : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual long VehicleId { get; set; }
        public virtual int Mileage { get; set; }
    }
}
