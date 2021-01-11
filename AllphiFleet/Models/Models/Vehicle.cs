using System.Collections.Generic;
using Models.Enums;

namespace Models
{
    public class Vehicle : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual long ChassisNr { get; set; }
        public virtual ICollection<LicensePlate> LicensePlates { get; set; }
        public virtual FuelTypes FuelType { get; set; }
        public virtual VehicleTypes VehicleType { get; set; }
        public virtual int Mileage { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
