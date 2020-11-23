using MediatR;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class CreateChauffeurCommand : IRequest<int>
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        //todo validatie
        public string RijksRegisterNummer { get; set; }
        public RijbewijsTypes TypeRijbewijs { get; set; }
        public bool Actief { get; set; }
        public long AdresId { get; set; }
        public virtual long TankkaartId { get; set; }

        public class CreateChauffeurCommandHandler : IRequestHandler<CreateChauffeurCommand, int>
        {
            private readonly IMapperSession _context;
            public CreateChauffeurCommandHandler(IMapperSession context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateChauffeurCommand command, CancellationToken cancellationToken)
            {
                var chauffeur = new Chauffeur();

                chauffeur.Naam = command.Naam;
                chauffeur.Voornaam = command.Voornaam;
                chauffeur.GeboorteDatum = command.GeboorteDatum;
                chauffeur.RijksRegisterNummer = command.RijksRegisterNummer;
                chauffeur.TypeRijbewijs = command.TypeRijbewijs;
                chauffeur.Actief = command.Actief;
                chauffeur.AdresId = command.AdresId;
                chauffeur.TankkaartId = command.TankkaartId;


                //_context.Chauffeurs.Add(chauffeur);

                await _context.Save(chauffeur);
                return (int)chauffeur.Id;
            }
        }
    }
}
