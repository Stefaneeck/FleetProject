using MediatR;
using Models;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class DeleteChauffeurCommand : IRequest<Unit>, IIdentifiable
    {
        //public DeleteChauffeurDTO DeleteChauffeurDTO { get; set; }
        public long Id { get; set; }
    }
}
