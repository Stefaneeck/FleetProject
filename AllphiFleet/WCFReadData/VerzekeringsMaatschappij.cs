namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VerzekeringsMaatschappij")]
    public partial class VerzekeringsMaatschappij
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VerzekeringsMaatschappij()
        {
            Herstellings = new HashSet<Herstelling>();
        }

        public long Id { get; set; }

        public int ReferentieNrVerzekeringsMaatschappij { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Herstelling> Herstellings { get; set; }
    }
}
