namespace WCFReadData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chauffeur
    {
        public long Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime GeboorteDatum { get; set; }

        [Required]
        public string RijksRegisterNummer { get; set; }

        public int TypeRijbewijs { get; set; }

        public bool Actief { get; set; }

        public long AdresId { get; set; }

        public long TankkaartId { get; set; }

        public virtual Adressen Adressen { get; set; }

        public virtual Tankkaarten Tankkaarten { get; set; }
    }
}
