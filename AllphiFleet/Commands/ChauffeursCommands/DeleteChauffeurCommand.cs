using MediatR;
using Models;

namespace Commands.ChauffeurCommands
{
    public class DeleteChauffeurCommand : IRequest<Unit>, IIdentifiable
    {
        //public DeleteChauffeurDTO DeleteChauffeurDTO { get; set; }
        public long Id { get; set; }
    }
}
