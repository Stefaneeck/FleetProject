using AutoMapper;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class CreateChauffeurCommandHandler : IRequestHandler<CreateChauffeurCommand, int>
    {
        private readonly INHRepository<Chauffeur> _context;
        private readonly INHRepository<Tankkaart> _tankkaartContext;
        private readonly IMapper _mapper;

        //inhrepository van createchauffeurdto ipv chauffeur? niet meer mappen dan
        public CreateChauffeurCommandHandler(INHRepository<Chauffeur> context, INHRepository<Tankkaart> tankkaartContext, IMapper mapper)
        {
            _context = context;
            _tankkaartContext = tankkaartContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateChauffeurCommand command, CancellationToken cancellationToken)
        {
            //mapping maken
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

                //TankkaartId = 4,
                
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

            //undo later
            //chauffeur.Tankkaart = _mapper.Map<Tankkaart>(command.CreateChauffeurDTO.Tankkaart);


            //_context.Chauffeurs.Add(chauffeur);

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
