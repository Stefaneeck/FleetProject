using Models.Enums;

namespace DTO
{
    public class CreateVehicleDTO
    {
        public long ChassisNr { get; set; }
        public FuelTypes FuelType { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public int Mileage { get; set; }
    }
}
