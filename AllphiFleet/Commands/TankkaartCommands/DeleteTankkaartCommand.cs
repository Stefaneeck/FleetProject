using MediatR;
using Models;

namespace Commands.TankkaartCommands
{
    public class DeleteTankkaartCommand : IRequest<Unit>, IIdentifiable
    {
        public long Id { get; set; }
    }
}
