using DTO;
using MediatR;

namespace Commands.ChauffeurCommands
{
    public class UpdateChauffeurCommand : IRequest<Unit>
    {
        public UpdateChauffeurDTO UpdateChauffeurDTO { get; set; }
    }
}
