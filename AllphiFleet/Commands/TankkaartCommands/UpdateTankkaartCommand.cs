using DTO;
using MediatR;

namespace Commands.TankkaartCommands
{
    public class UpdateTankkaartCommand : IRequest<Unit>
    {
        public UpdateTankkaartDTO UpdateTankkaartDTO { get; set; }
    }
}
