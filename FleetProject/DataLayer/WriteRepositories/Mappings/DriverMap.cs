using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class DriverMap : ClassMapping<Driver>
    {
        public DriverMap()
        {
            this.Table("Drivers");

            this.Id(d => d.Id, d =>
            {
                //native = what ever is native in underlying db
                d.Generator(Generators.Native);
                d.Type(NHibernateUtil.Int64);
                d.Column("Id");
                d.UnsavedValue(0);
            });
            
            this.Property(d => d.Name);
            this.Property(d => d.FirstName);
            this.Property(d => d.BirthDate);
            this.Property(d => d.SocSecNr);
            this.Property(d => d.DriverLicenseType);
            this.Property(d => d.Active);
            this.Property(d => d.Email);

            ManyToOne(x => x.Address, map =>
            {
                map.Column("AddressId");
                //on delete, delete orphans
                //cascade merge because we use merge with update, if this is not set only the driver will be updated
                map.Cascade(Cascade.DeleteOrphans | Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });

            ManyToOne(x => x.FuelCard, map =>
            {
                map.Column("FuelCardId");
                #region commentcascade
                //cascade all includes remove, so it would be deleted, more specific cascades specified because of this
                //no delete action, this means +- cascade none for delete
                //on delete driver, do not delete fuelcard
                #endregion
                map.Cascade(Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });
        }
    }
}
