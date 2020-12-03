using DTO;
using MediatR;

namespace Commands.AanvraagCommands
{
    public class UpdateAanvraagCommand : IRequest<Unit>
    {
        public UpdateAanvraagDTO UpdateAanvraagDTO { get; set; }
    }
}
