using DTO;
using MediatR;

namespace Commands.DriverCommands
{
    public class CreateDriverCommand : IRequest<int>
    {
        public CreateDriverDTO CreateDriverDTO { get; set; }
    }
}
