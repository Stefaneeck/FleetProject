using Models.Enums;
using System;

namespace Models
{
    public class Application : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual DateTime ApplicationDate { get; set; }
        public virtual ApplicationTypes ApplicationType { get; set; }
        public virtual string PossibleDates { get; set; }
        public virtual ApplicationStatuses ApplicationStatus { get; set; }
        public virtual long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual long DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
