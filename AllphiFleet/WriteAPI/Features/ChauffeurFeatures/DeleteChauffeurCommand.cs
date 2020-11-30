using MediatR;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class DeleteChauffeurCommand : IRequest<int>
    {
        //public DeleteChauffeurDTO DeleteChauffeurDTO { get; set; }
        public long Id { get; set; }
    }
}
