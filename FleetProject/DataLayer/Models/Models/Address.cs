using NHibernate.Mapping;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    //annotations for WCF
    [DataContract]
    public class Address : IIdentifiable
    {
        [DataMember]
        public virtual long Id { get; set; }
        [DataMember]
        public virtual string Street { get; set; }
        [DataMember]
        public virtual int Number { get; set; }
        [DataMember]
        public virtual string City { get; set; }
        [DataMember]
        public virtual int Zipcode { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
