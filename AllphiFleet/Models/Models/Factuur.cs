using System.Collections.Generic;

namespace Models
{
    public class Factuur
    {
        public virtual long Id { get; set; }
        public virtual string NaamGefactureerde { get; set; }
        public virtual ICollection<Onderhoud> OnderhoudenOpFactuur { get; set; }
    }
}