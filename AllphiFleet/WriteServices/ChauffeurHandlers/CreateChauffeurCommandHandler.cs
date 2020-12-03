using Commands.ChauffeurCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.ChauffeurHandlers
{
    public class CreateChauffeurCommandHandler : IRequestHandler<CreateChauffeurCommand, int>
    {
        private readonly INHRepository<Chauffeur> _context;

        public CreateChauffeurCommandHandler(INHRepository<Chauffeur> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateChauffeurCommand command, CancellationToken cancellationToken)
        {
            var chauffeur = new Chauffeur
            {
                Naam = command.CreateChauffeurDTO.Naam,
                Voornaam = command.CreateChauffeurDTO.Voornaam,
                GeboorteDatum = command.CreateChauffeurDTO.GeboorteDatum,
                RijksRegisterNummer = command.CreateChauffeurDTO.RijksRegisterNummer,
                TypeRijbewijs = command.CreateChauffeurDTO.TypeRijbewijs,
                Actief = command.CreateChauffeurDTO.Actief,

                Adres = new Adres
                {
                    Id = 0,
                    Straat = command.CreateChauffeurDTO.Adres.Straat,
                    Nummer = command.CreateChauffeurDTO.Adres.Nummer,
                    Stad = command.CreateChauffeurDTO.Adres.Stad,
                    Postcode = command.CreateChauffeurDTO.Adres.Postcode
                },

                Tankkaart = new Tankkaart
                {
                    Id = 0,
                    Kaartnummer = command.CreateChauffeurDTO.Tankkaart.Kaartnummer,
                    GeldigheidsDatum = command.CreateChauffeurDTO.Tankkaart.GeldigheidsDatum,
                    Pincode = command.CreateChauffeurDTO.Tankkaart.Pincode,
                    AuthType = command.CreateChauffeurDTO.Tankkaart.AuthType,
                    Opties = command.CreateChauffeurDTO.Tankkaart.Opties
                }
            };

            _context.BeginTransaction();

            try
            {
                //optioneel: contexten apart aanspreken, meer controle over volgorde
                //await _tankkaartContext.Save(chauffeur.Tankkaart);
                await _context.Save(chauffeur);
                await _context.Commit();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }
            
            return (int)chauffeur.Id;
        }
    }
}
