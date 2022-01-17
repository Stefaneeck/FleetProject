using System.Collections.Generic;

namespace Models
{
    public class InsuranceCompany : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual int RefNrInsuranceCompany { get; set; }
        public virtual ICollection<Repair> Repairs { get; set; }
    }
}