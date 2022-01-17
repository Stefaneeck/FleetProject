using DTO;
using MediatR;

namespace Commands.ApplicationCommands
{
    public class CreateApplicationCommand : IRequest<int>
    {
        public CreateApplicationDTO CreateApplicationDTO { get; set; }
        
    }
}
