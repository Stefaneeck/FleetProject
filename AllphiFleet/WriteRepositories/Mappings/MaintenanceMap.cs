using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class MaintenanceMap : ClassMapping<Maintenance>
    {
        public MaintenanceMap()
        {
            this.Table("Maintenance");

            this.Id(m => m.Id, m =>
            {
                m.Generator(Generators.Native);
                m.Type(NHibernateUtil.Int64);
                m.Column("Id");
                m.UnsavedValue(0);
            });

            this.Property(m => m.MaintenanceDate);
            this.Property(m => m.Price);
            this.Property(m => m.DealerName);

            //mapped so that you need to select an existing invoice and existing car.
            this.Property(m => m.VehicleId);
            this.Property(m => m.InvoiceId);
        }

    }
}
