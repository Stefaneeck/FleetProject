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
                //bij delete, delete orphans
                //cascade merge omdat we bij update merge gebruiken, als dit niet aanstaat dan update hij enkel de chauffeur
                map.Cascade(Cascade.DeleteOrphans | Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });

            
            ManyToOne(x => x.Tankkaart, map =>
            {
                map.Column("TankkaartId");
                //cascade all houdt ook remove in, dus dan wordt hij verwijderd.. daarom specifiekere cascades
                //geen delete action, dus eigenlijk cascade none voor delete
                map.Cascade(Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });
        }
    }
}
