namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voertuig")]
    public partial class Voertuig
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Voertuig()
        {
            Aanvraags = new HashSet<Aanvraag>();
            Nummerplaats = new HashSet<Nummerplaat>();
            Onderhouds = new HashSet<Onderhoud>();
        }

        public long Id { get; set; }

        public int TypeBrandStof { get; set; }

        public int TypeWagen { get; set; }

        public int KilometerStand { get; set; }

        public long ChassisNr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aanvraag> Aanvraags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nummerplaat> Nummerplaats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Onderhoud> Onderhouds { get; set; }
    }
}
