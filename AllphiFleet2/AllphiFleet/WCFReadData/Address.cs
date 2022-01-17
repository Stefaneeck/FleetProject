using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WCFReadData
{
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Drivers = new HashSet<Driver>();
        }

        public long Id { get; set; }

        [Required]
        public string Street { get; set; }

        public int Number { get; set; }

        [Required]
        public string City { get; set; }

        public int Zipcode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
