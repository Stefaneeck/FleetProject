using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteAPI
{
    public class ChauffeurMap : ClassMapping<Chauffeur>
    {
        public ChauffeurMap()
        {
            this.Table("Chauffeurs");

            this.Id(c => c.Id, c =>
            {
                //native = what ever is native in underlying db
                c.Generator(Generators.Native);
                c.Type(NHibernateUtil.Int64);
                c.Column("Id");
                c.UnsavedValue(0);
            });
            
            //this.Id(c => c.Id);
            this.Property(c => c.Naam);
            this.Property(c => c.Voornaam);
            this.Property(c => c.GeboorteDatum);
            this.Property(c => c.RijksRegisterNummer);
            this.Property(c => c.TypeRijbewijs);
            this.Property(c => c.Actief);

            //this.Property(c => c.TankkaartId);

            ManyToOne(x => x.Adres, map =>
            {
                map.Column("AdresId");
                map.Cascade(Cascade.All);
            });

            
            ManyToOne(x => x.Tankkaart, map =>
            {
                map.Column("TankkaartId");
                map.Cascade(Cascade.All);
            });
        }
    }
}
