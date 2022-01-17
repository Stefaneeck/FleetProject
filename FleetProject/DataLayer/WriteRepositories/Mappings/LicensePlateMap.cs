using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class LicensePlateMap : ClassMapping<LicensePlate>
    {
        public LicensePlateMap()
        {
            this.Table("LicensePlate");

            this.Id(l => l.Id, l =>
            {
                l.Generator(Generators.Native);
                l.Type(NHibernateUtil.Int64);
                l.Column("Id");
                l.UnsavedValue(0);
            });

            this.Property(l => l.LicensePlateCharacters);
            this.Property(l => l.Active);
            this.Property(l => l.VehicleId);

        }

    }
}