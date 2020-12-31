namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Onderhoud")]
    public partial class Onderhoud
    {
        public long Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DatumOnderhoud { get; set; }

        public decimal Prijs { get; set; }

        [Required]
        public string Garage { get; set; }

        public long FactuurId { get; set; }

        public long VoertuigId { get; set; }

        public virtual Factuur Factuur { get; set; }

        public virtual Voertuig Voertuig { get; set; }
    }
}
