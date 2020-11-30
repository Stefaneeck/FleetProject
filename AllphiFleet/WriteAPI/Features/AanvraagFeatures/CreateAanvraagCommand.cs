using DTO;
using MediatR;

namespace WriteAPI.Features.AanvraagFeatures
{
    public class CreateAanvraagCommand : IRequest<int>
    {
        public CreateAanvraagDTO CreateAanvraagDTO { get; set; }
        
    }
}
