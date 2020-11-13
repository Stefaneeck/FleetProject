using System.Collections.Generic;

namespace Models
{
    public class Factuur
    {
        public long Id { get; set; }
        public string NaamGefactureerde { get; set; }
        public ICollection<Onderhoud> OnderhoudenOpFactuur { get; set; }
    }
}