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

            this.Id(x => x.Id, x =>
            {
                //native = what ever is native in underlying db
                x.Generator(Generators.Native);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
                x.UnsavedValue(0);
            });
            
            //this.Id(c => c.Id);
            this.Property(c => c.Naam);
            this.Property(c => c.Voornaam);
            this.Property(c => c.GeboorteDatum);
            this.Property(c => c.RijksRegisterNummer);
            this.Property(c => c.TypeRijbewijs);
            this.Property(c => c.Actief);
            //hoe adresid en tankkaartid niet tonen?
            //this.Property(c => c.AdresId);

            //deze zijn null want er wordt nergens naar de property adresid verwezen, hoe oplossen?
            this.Property(c => c.AdresId);
            /*
            this.ManyToOne(c => c.Adres, a =>
            {
                a.Column("AdresId");
                a.Class(typeof(Adres));
            });
            */

            this.Property(c => c.TankkaartId);
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
