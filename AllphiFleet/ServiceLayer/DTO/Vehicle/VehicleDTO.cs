using Models.Enums;

namespace DTO
{
    public class VehicleDTO
    {
        public virtual long Id { get; set; }
        public virtual long ChassisNr { get; set; }
        public virtual FuelTypes FuelType { get; set; }
        public virtual VehicleTypes VehicleType { get; set; }
        public virtual int Mileage { get; set; }

    }
}
