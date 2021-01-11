using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class ApplicationMap : ClassMapping<Application>
    {

        public ApplicationMap()
        {
            this.Table("Application");

            this.Id(x => x.Id, x =>
            {
                x.Generator(Generators.Native);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
                x.UnsavedValue(0);
            });

            this.Property(a => a.ApplicationDate);
            this.Property(a => a.ApplicationType);
            this.Property(a => a.PossibleDates);
            this.Property(a => a.ApplicationStatus);

            //rel voertuig
            ManyToOne(a => a.Vehicle, map =>
            {
                map.Column("VehicleId");
                //on delete, delete orphans
                //cascade merge because we use merge with update, if this is not set only application will be updated
                map.Cascade(Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });
        }
    }
}
