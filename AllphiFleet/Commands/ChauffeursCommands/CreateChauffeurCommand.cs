using DTO;
using MediatR;

namespace Commands.ChauffeurCommands
{
    public class CreateChauffeurCommand : IRequest<int>
    {
        public CreateChauffeurDTO CreateChauffeurDTO { get; set; }
    }
}
