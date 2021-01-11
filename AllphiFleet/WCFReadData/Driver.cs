namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Driver
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        [Required]
        public string SocSecNr { get; set; }

        public int DriverLicenseType { get; set; }

        public bool Active { get; set; }

        public long AddressId { get; set; }

        public long FuelCardId { get; set; }

        public virtual Address Address { get; set; }

        public virtual FuelCard FuelCard { get; set; }
    }
}
