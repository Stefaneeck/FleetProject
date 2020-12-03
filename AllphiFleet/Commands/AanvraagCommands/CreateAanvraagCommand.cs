using DTO;
using MediatR;

namespace Commands.AanvraagCommands
{
    public class CreateAanvraagCommand : IRequest<int>
    {
        public CreateAanvraagDTO CreateAanvraagDTO { get; set; }
        
    }
}
