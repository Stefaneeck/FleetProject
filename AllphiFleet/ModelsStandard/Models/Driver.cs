using ModelsStandard.Enums;
using System;

namespace ModelsStandard
{
    public class Driver : IIdentifiable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string SocSecNr { get; set; }
        public RijbewijsTypes DriverLicenseType { get; set; }
        public bool Active { get; set; }
        public Address Address { get; set; }
        public FuelCard FuelCard { get; set; }

    }
}

