using Models.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    //WCF
    [DataContract]

    public class Driver : IIdentifiable
    {
        //virtual to support nhibernate lazy loading and datamember for WCF
        [DataMember]
        public virtual long Id { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string FirstName { get; set; }
        [DataMember]
        public virtual DateTime BirthDate { get; set; }
        [DataMember]
        public virtual string SocSecNr { get; set; }
        [DataMember]
        public virtual DriverLicenseTypes DriverLicenseType { get; set; }
        [DataMember]
        public virtual bool Active { get; set; }
        [DataMember]
        public virtual string Email { get; set; }

        //rel address
        public virtual long AddressId { get; set; }

        [DataMember]
        public virtual Address Address { get; set; }

        //rel fuelcard
        public virtual long FuelCardId { get; set; }

        [DataMember]
        public virtual FuelCard FuelCard { get; set; }

        //rel application
        public virtual ICollection<Application> Applications { get; set; }

    }
}

