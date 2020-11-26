using AutoMapper;
using MediatR;
using Models;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.AanvraagFeatures
{
    public class CreateAanvraagCommandHandler : IRequestHandler<CreateAanvraagCommand, int>
    {
        private readonly INHRepository<Aanvraag> _context;
        private readonly IMapper _mapper;
        public CreateAanvraagCommandHandler(INHRepository<Aanvraag> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateAanvraagCommand command, CancellationToken cancellationToken)
        {
            //mapping maken
            var aanvraag = new Aanvraag();

            aanvraag.DatumAanvraag = command.createAanvraagDTO.DatumAanvraag;
            aanvraag.TypeAanvraag = command.createAanvraagDTO.TypeAanvraag;
            aanvraag.GewensteData = command.createAanvraagDTO.GewensteData;
            aanvraag.StatusAanvraag = command.createAanvraagDTO.StatusAanvraag;
            //aanvraag.VoertuigId = command.createAanvraagDTO.VoertuigId;
            aanvraag.Voertuig = _mapper.Map<Voertuig>(command.createAanvraagDTO.Voertuig);

            //_context.Chauffeurs.Add(chauffeur);

            _context.BeginTransaction();
            await _context.Save(aanvraag);
            await _context.Commit();
            return (int)aanvraag.Id;
        }
    }
}
