using Models.Enums;
using System;

namespace DTO
{
    public class UpdateDriverDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public AddressDTO Address { get; set; }

        public DateTime BirthDate { get; set; }

        public string SocSecNr { get; set; }

        public DriverLicenseTypes DriverLicenseType { get; set; }

        public FuelCardDTO FuelCard { get; set; }

        public bool Active { get; set; }

        public string Email { get; set; }
    }
}
