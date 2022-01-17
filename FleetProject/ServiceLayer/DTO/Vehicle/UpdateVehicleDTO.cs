using Models.Enums;

namespace DTO
{
    public class UpdateVehicleDTO
    {
        public long Id { get; set; }
        public long ChassisNr { get; set; }
        public FuelTypes FuelType { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public int Mileage { get; set; }
    }
}
