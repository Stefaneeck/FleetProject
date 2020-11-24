using MediatR;
using Models;
using Models.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.AanvraagFeatures
{
    //mag dto zijn?
    public class CreateAanvraagCommand : IRequest<int>
    {
        public DateTime DatumAanvraag { get; set; }
        public AanvraagTypes TypeAanvraag { get; set; }
        public string GewensteData { get; set; }
        public AanvraagStatussen StatusAanvraag { get; set; }
        public long VoertuigId { get; set; }

        //handler in aparte klasse?
        public class CreateAanvraagCommandHandler : IRequestHandler<CreateAanvraagCommand, int>
        {
            private readonly IMapperSession<Aanvraag> _context;
            public CreateAanvraagCommandHandler(IMapperSession<Aanvraag> context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateAanvraagCommand command, CancellationToken cancellationToken)
            {
                //mapping maken
                var aanvraag = new Aanvraag();

                aanvraag.DatumAanvraag = command.DatumAanvraag;
                aanvraag.TypeAanvraag = command.TypeAanvraag;
                aanvraag.GewensteData = command.GewensteData;
                aanvraag.StatusAanvraag = command.StatusAanvraag;
                aanvraag.VoertuigId = command.VoertuigId;

                //_context.Chauffeurs.Add(chauffeur);

                _context.BeginTransaction();
                await _context.Save(aanvraag);
                await _context.Commit();
                return (int)aanvraag.Id;
            }
        }
    }
}
