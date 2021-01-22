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

            //not creating entire new vehicle and driver objects anymore, property instead of manytoone
            this.Property(a => a.VehicleId);
            this.Property(a => a.DriverId);

            #region comments
            //this.Property(a => a.Vehicle.Id);
            //this.Property(a => a.Driver.Id);

            /*
            //rel vehicle
            ManyToOne(a => a.Vehicle, map =>
            {
                map.Column("VehicleId");
                //cascade merge because we use merge with update, if this is not set only application will be updated
                map.Cascade(Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });
            */

            /*
            //rel driver
            ManyToOne(x => x.Driver, map =>
            {
                map.Column("DriverId");
                //cascade all also includes remove, so it would be deleted.. specific cascades because of this
                //no delete action, you can see this as cascade none for delete
                //keep driver on delete application
                map.Cascade(Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });
            */
            #endregion
        }
    }
}
