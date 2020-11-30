using DTO;
using MediatR;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class UpdateChauffeurCommand : IRequest<Unit>
    {
        public UpdateChauffeurDTO UpdateChauffeurDTO { get; set; }
    }
}
