using Commands.ChauffeurCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.ChauffeurHandlers
{
    public class UpdateChauffeurCommandHandler : IRequestHandler<UpdateChauffeurCommand, Unit>
    {
        private readonly INHRepository<Chauffeur> _chauffeurContext;
        public UpdateChauffeurCommandHandler(INHRepository<Chauffeur> chauffeurContext)
        {
            _chauffeurContext = chauffeurContext;

        }
        public async Task<Unit> Handle(UpdateChauffeurCommand command, CancellationToken cancellationToken)
        {
            Chauffeur chauffeurVanDB = _chauffeurContext.Chauffeurs.FirstOrDefault(c => c.Id == command.UpdateChauffeurDTO.Id);

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

            };

            _chauffeurContext.BeginTransaction();

            try
            {
                //_session.Evict(chauffeur);

                await _chauffeurContext.Update(chauffeur);
                await _chauffeurContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _chauffeurContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
