namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aanvraag")]
    public partial class Aanvraag
    {
        public long Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DatumAanvraag { get; set; }

        public int TypeAanvraag { get; set; }

        public string GewensteData { get; set; }

        public int StatusAanvraag { get; set; }

        public long VoertuigId { get; set; }

        public virtual Voertuig Voertuig { get; set; }
    }
}
