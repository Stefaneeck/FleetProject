using System.Collections.Generic;

namespace ModelsStandard
{
    public class Factuur : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string NaamGefactureerde { get; set; }
        public virtual ICollection<Onderhoud> OnderhoudenOpFactuur { get; set; }
    }
}