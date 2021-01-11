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

            this.Id(c => c.Id, c =>
            {
                //native = what ever is native in underlying db
                c.Generator(Generators.Native);
                c.Type(NHibernateUtil.Int64);
                c.Column("Id");
                c.UnsavedValue(0);
            });
            
            this.Property(c => c.Name);
            this.Property(c => c.FirstName);
            this.Property(c => c.BirthDate);
            this.Property(c => c.SocSecNr);
            this.Property(c => c.DriverLicenseType);
            this.Property(c => c.Active);

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
                //cascade all houdt ook remove in, dus dan wordt hij verwijderd.. daarom specifiekere cascades
                //geen delete action, dus eigenlijk cascade none voor delete
                //bij het verwijderen van een chauffeur, de tankkaart behouden
                map.Cascade(Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });
        }
    }
}
