namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factuur")]
    public partial class Factuur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factuur()
        {
            Onderhouds = new HashSet<Onderhoud>();
        }

        public long Id { get; set; }

        [Required]
        public string NaamGefactureerde { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Onderhoud> Onderhouds { get; set; }
    }
}
