using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Models.Enums;

namespace Models
{
    //annotations for WCF
    [DataContract]
    public class FuelCard : IIdentifiable
    {
        [DataMember]
        public virtual long Id { get; set; }
        [DataMember]
        public virtual int CardNumber { get; set; }
        [DataMember]
        public virtual DateTime ValidUntilDate { get; set; }
        [DataMember]
        public virtual int Pincode { get; set; }
        [DataMember]
        public virtual AuthenticationTypes AuthType { get; set; }
        [DataMember]
        public virtual string Options { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
