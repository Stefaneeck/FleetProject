using DTO;
using MediatR;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class UpdateChauffeurCommand : IRequest<int>
    {
        public UpdateChauffeurDTO UpdateChauffeurDTO { get; set; }
    }
}
