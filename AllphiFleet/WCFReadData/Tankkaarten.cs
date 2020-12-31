namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tankkaarten")]
    public partial class Tankkaarten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tankkaarten()
        {
            Chauffeurs = new HashSet<Chauffeur>();
        }

        public long Id { get; set; }

        public int Kaartnummer { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime GeldigheidsDatum { get; set; }

        public int Pincode { get; set; }

        public int AuthType { get; set; }

        [Required]
        public string Opties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
