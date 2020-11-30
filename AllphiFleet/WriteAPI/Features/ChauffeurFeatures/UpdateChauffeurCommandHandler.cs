using AutoMapper;
using MediatR;
using Models;
using NHibernate;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class UpdateChauffeurCommandHandler : IRequestHandler<UpdateChauffeurCommand, int>
    {
        private readonly INHRepository<Chauffeur> _chauffeurContext;
        private readonly INHRepository<Adres> _adresContext;
        private readonly INHRepository<Tankkaart> _tankkaartContext;

        //voor evict
        //private readonly ISession _session;

        //private readonly IMapper _mapper;

        //inhrepository van createchauffeurdto ipv chauffeur? niet meer mappen dan
        public UpdateChauffeurCommandHandler(INHRepository<Chauffeur> chauffeurContext, INHRepository<Adres> adresContext, 
            INHRepository<Tankkaart> tankkaartContext, IMapper mapper, ISession session)
        {
            _chauffeurContext = chauffeurContext;
            _adresContext = adresContext;
            _tankkaartContext = tankkaartContext;
            //_mapper = mapper;

            //_session = session;
        }
        public async Task<int> Handle(UpdateChauffeurCommand command, CancellationToken cancellationToken)
        {
            //Adres adresVanChauffeur = _adresContext.Adressen.FirstOrDefault(a => a.Id == command.UpdateChauffeurDTO.Adres.Id);
            Chauffeur chauffeurVanDB = _chauffeurContext.Chauffeurs.FirstOrDefault(c => c.Id == command.UpdateChauffeurDTO.Id);
            //Tankkaart tankkaartVanChauffeur = _tankkaartContext.Tankkaarten.FirstOrDefault(t => t.Id == command.UpdateChauffeurDTO.Tankkaart.Id);

            var chauffeur = new Chauffeur
            {
                Id = command.UpdateChauffeurDTO.Id,
                Naam = command.UpdateChauffeurDTO.Naam,
                Voornaam = command.UpdateChauffeurDTO.Voornaam,
                GeboorteDatum = command.UpdateChauffeurDTO.GeboorteDatum,
                RijksRegisterNummer = command.UpdateChauffeurDTO.RijksRegisterNummer,
                TypeRijbewijs = command.UpdateChauffeurDTO.TypeRijbewijs,
                Actief = command.UpdateChauffeurDTO.Actief,

                 Adres = new Adres
                {
                    //id opgehaald uit db
                    Id = chauffeurVanDB.Adres.Id,

                    Straat = command.UpdateChauffeurDTO.Adres.Straat,
                    Nummer = command.UpdateChauffeurDTO.Adres.Nummer,
                    Stad = command.UpdateChauffeurDTO.Adres.Stad,
                    Postcode = command.UpdateChauffeurDTO.Adres.Postcode
                },

                Tankkaart = new Tankkaart
                {
                    //id uit db
                    Id = chauffeurVanDB.Tankkaart.Id,

                    Kaartnummer = command.UpdateChauffeurDTO.Tankkaart.Kaartnummer,
                    GeldigheidsDatum = command.UpdateChauffeurDTO.Tankkaart.GeldigheidsDatum,
                    Pincode = command.UpdateChauffeurDTO.Tankkaart.Pincode,
                    AuthType = command.UpdateChauffeurDTO.Tankkaart.AuthType,
                    Opties = command.UpdateChauffeurDTO.Tankkaart.Opties
                }

                /*

            Adres = new Adres
                {
                    //hard code undo
                    Id = 2,
                    Straat = command.UpdateChauffeurDTO.Adres.Straat,
                    Nummer = command.UpdateChauffeurDTO.Adres.Nummer,
                    Stad = command.UpdateChauffeurDTO.Adres.Stad,
                    Postcode = command.UpdateChauffeurDTO.Adres.Postcode
                },

                Tankkaart = new Tankkaart
                {
                    Id = 2,
                    Kaartnummer = command.UpdateChauffeurDTO.Tankkaart.Kaartnummer,
                    GeldigheidsDatum = command.UpdateChauffeurDTO.Tankkaart.GeldigheidsDatum,
                    Pincode = command.UpdateChauffeurDTO.Tankkaart.Pincode,
                    AuthType = command.UpdateChauffeurDTO.Tankkaart.AuthType,
                    Opties = command.UpdateChauffeurDTO.Tankkaart.Opties
                }

                */
            };

            _chauffeurContext.BeginTransaction();

            try
            {
                //_session.Evict(chauffeur);
                //_session.Evict(chauffeur.Adres);
                //_session.Evict(chauffeur.Tankkaart);


                //_session.Flush();
                await _chauffeurContext.Update(chauffeur);
                await _chauffeurContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _chauffeurContext.Rollback();
            }

            return (int)chauffeur.Id;
        }
    }
}
