using Models.Enums;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Driver : IIdentifiable
    {
        //virtual to support nhibernate lazy loading
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string FirstName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string SocSecNr { get; set; }
        public virtual DriverLicenseTypes DriverLicenseType { get; set; }
        public virtual bool Active { get; set; }

        //rel address
        public virtual long AddressId { get; set; }
        public virtual Address Address { get; set; }

        //rel fuelcard
        public virtual long FuelCardId { get; set; }
        public virtual FuelCard FuelCard { get; set; }

        //rel application
        public virtual ICollection<Application> Applications { get; set; }

    }
}

