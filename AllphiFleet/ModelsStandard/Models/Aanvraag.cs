using Models.Enums;
using System;

namespace ModelsStandard
{
    public class Aanvraag : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual DateTime DatumAanvraag { get; set; }
        public virtual AanvraagTypes TypeAanvraag { get; set; }
        public virtual string GewensteData { get; set; }
        public virtual AanvraagStatussen StatusAanvraag { get; set; }
        public virtual long VoertuigId { get; set; }
        public virtual Voertuig Voertuig { get; set; }
    }
}
