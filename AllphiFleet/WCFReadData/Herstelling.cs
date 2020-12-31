namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Herstelling")]
    public partial class Herstelling
    {
        public long Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DatumHerstelling { get; set; }

        [Required]
        public string SchadeOmschrijving { get; set; }

        public long VerzekeringsMaatschappijId { get; set; }

        public string Fotos { get; set; }

        public string Documenten { get; set; }

        public virtual VerzekeringsMaatschappij VerzekeringsMaatschappij { get; set; }
    }
}
