using NHibernate.Mapping;
using System.Collections.Generic;

namespace Models
{
    public class Address : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int Number { get; set; }
        public virtual string City { get; set; }
        public virtual int Zipcode { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
