using MediatR;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class DeleteChauffeurCommand : IRequest<Unit>
    {
        //public DeleteChauffeurDTO DeleteChauffeurDTO { get; set; }
        public long Id { get; set; }
    }
}
