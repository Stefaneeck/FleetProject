namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nummerplaat")]
    public partial class Nummerplaat
    {
        public long Id { get; set; }

        [Required]
        public string NummerPlaatTekens { get; set; }

        public long VoertuigId { get; set; }

        public virtual Voertuig Voertuig { get; set; }
    }
}
