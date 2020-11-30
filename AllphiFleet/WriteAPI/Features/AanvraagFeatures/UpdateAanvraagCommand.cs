using DTO;
using MediatR;

namespace WriteAPI.Features.AanvraagFeatures
{
    public class UpdateAanvraagCommand : IRequest<Unit>
    {
        public UpdateAanvraagDTO UpdateAanvraagDTO { get; set; }
    }
}
