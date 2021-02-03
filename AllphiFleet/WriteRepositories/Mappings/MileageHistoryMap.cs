using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class MileageHistoryMap : ClassMapping<MileageHistory>
    {
        public MileageHistoryMap()
        {
            this.Table("MileageHistory");

            this.Id(m => m.Id, m =>
            {
                m.Generator(Generators.Native);
                m.Type(NHibernateUtil.Int64);
                m.Column("Id");
                m.UnsavedValue(0);
            });

            this.Property(m => m.VehicleId);
            this.Property(m => m.Mileage);

        }
    }
}
