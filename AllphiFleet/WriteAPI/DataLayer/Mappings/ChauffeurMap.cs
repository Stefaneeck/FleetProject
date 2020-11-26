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

            ManyToOne(x => x.Adres, map =>
            {
                map.Column("AdresId");
                //map.NotNullable(false);

                map.Cascade(Cascade.None);
            });
            

            //this.Property(c => c.AdresId);
            this.Property(c => c.TankkaartId);

            //hoe adresid en tankkaartid niet tonen?
            //this.Property(c => c.AdresId);

            //deze zijn null want er wordt nergens naar de property adresid verwezen, hoe oplossen?

            /*
            this.ManyToOne(c => c.Adres, a =>
            {
                a.Column("AdresId");
                a.Class(typeof(Adres));
            });
            */


            /*
            this.ManyToOne(p => p.Tankkaart, t =>
            {
                t.Column("TankkaartId");
                t.Class(typeof(Tankkaart));
            });
            */
        }
    }
}
