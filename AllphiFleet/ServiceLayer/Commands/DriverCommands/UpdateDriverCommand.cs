using DTO;
using MediatR;

namespace Commands.DriverCommands
{
    public class UpdateDriverCommand : IRequest<Unit>
    {
        public UpdateDriverDTO UpdateDriverDTO { get; set; }
    }
}
