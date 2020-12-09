using DTO;
using MediatR;

namespace Commands.TankkaartCommands
{
    public class CreateTankkaartCommand : IRequest<int>
    {
        public CreateTankkaartDTO CreateTankkaartDTO { get; set; }
    }
}
