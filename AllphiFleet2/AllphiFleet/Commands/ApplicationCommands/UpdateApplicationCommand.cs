using DTO;
using MediatR;

namespace Commands.ApplicationCommands
{
    public class UpdateApplicationCommand : IRequest<Unit>
    {
        public UpdateApplicationDTO UpdateApplicationDTO { get; set; }
    }
}
