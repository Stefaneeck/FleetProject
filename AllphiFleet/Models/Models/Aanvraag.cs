using Models.Enums;
using System;

namespace Models
{
    public class Aanvraag : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual DateTime DatumAanvraag { get; set; }
        public virtual AanvraagTypes TypeAanvraag { get; set; }

        //ef ondersteunt geen lijsten, aparte tabel van maken of string bewerking
        public virtual string GewensteData { get; set; }
        public virtual AanvraagStatussen StatusAanvraag { get; set; }
        public virtual long VoertuigId { get; set; }
        public virtual Voertuig Voertuig { get; set; }
    }
}
