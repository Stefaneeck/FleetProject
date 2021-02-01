using Models.Enums;
using System;

namespace DTO
{
    public class CreateApplicationDTO
    {
        public DateTime ApplicationDate { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public DateTime PossibleDate1 { get; set; }
        public DateTime PossibleDate2 { get; set; }
        public ApplicationStatuses ApplicationStatus { get; set; }
        #region commentobjects
        //not working with objects anymore NH, just the 2 properties
        //public Vehicle Vehicle { get; set; }

        //public Driver Driver { get; set; }
        #endregion
        public long VehicleId { get; set; }
        public long DriverId { get; set; }
        public string DriverEmail { get; set; }
    }
}
