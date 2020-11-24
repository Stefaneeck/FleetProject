﻿using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteAPI.DataLayer.Mappings
{
    public class AanvraagMap : ClassMapping<Aanvraag>
    {

        public AanvraagMap()
        {
            this.Table("Aanvraag");

            this.Id(x => x.Id, x =>
            {
                x.Generator(Generators.Native);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
                x.UnsavedValue(0);
            });

            this.Property(a => a.DatumAanvraag);
            this.Property(a => a.TypeAanvraag);
            this.Property(a => a.GewensteData);
            this.Property(a => a.StatusAanvraag);

            //rel voertuig
            this.Property(a => a.VoertuigId);
        }
    }
}
