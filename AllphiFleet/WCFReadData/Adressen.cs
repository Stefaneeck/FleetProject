namespace WCFReadData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adressen")]
    public partial class Adressen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adressen()
        {
            Chauffeurs = new HashSet<Chauffeur>();
        }
        public long Id { get; set; }

        [Required]
        public string Straat { get; set; }

        public int Nummer { get; set; }

        [Required]
        public string Stad { get; set; }

        public int Postcode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
