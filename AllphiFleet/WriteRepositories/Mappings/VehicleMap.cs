using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class VehicleMap : ClassMapping<Vehicle>
    {
        public VehicleMap()
        {
            //no seperate delete
            this.Table("Vehicle");

            this.Id(v => v.Id, v =>
            {
                v.Generator(Generators.Native);
                v.Type(NHibernateUtil.Int64);
                v.Column("Id");
                v.UnsavedValue(0);
            });

            this.Property(v => v.ChassisNr);
            this.Property(v => v.Mileage);
            this.Property(v => v.FuelType);
            this.Property(v => v.VehicleType);
        }

    }
}
