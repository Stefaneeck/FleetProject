using Models.Enums;

namespace DTO
{
    public class VoertuigDTO
    {
        public virtual long Id { get; set; }
        public virtual long ChassisNr { get; set; }
        public virtual BrandstofTypes TypeBrandStof { get; set; }
        public virtual WagenTypes TypeWagen { get; set; }
        public virtual int KilometerStand { get; set; }

    }
}
