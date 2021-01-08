namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FuelCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FuelCard()
        {
            Drivers = new HashSet<Driver>();
        }

        public long Id { get; set; }

        public int CardNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidUntilDate { get; set; }

        public int Pincode { get; set; }

        public int AuthType { get; set; }

        [Required]
        public string Options { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
