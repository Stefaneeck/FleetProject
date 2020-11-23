﻿using Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteAPI
{
    public class TankkaartMap : ClassMapping<Tankkaart>
    {
        public TankkaartMap()
        {
            this.Table("Tankkaarten");

            this.Id(t => t.Id);
            this.Property(t => t.Kaartnummer);
            this.Property(t => t.GeldigheidsDatum);
            this.Property(t => t.Pincode);
            this.Property(t => t.AuthType);
            this.Property(t => t.Opties);

            /*
            this.Bag(x => x.Chauffeurs, mapper => {
                mapper.Inverse(true);
                mapper.Cascade(Cascade.None);
                mapper.Key(k => 
                { 
                    k.Column("TankkaartId");
                    k.NotNullable(true);
                }
                );
                mapper.Lazy(CollectionLazy.Lazy);
            },
                r => r.OneToMany()
            );

            */
        }
    }
}
