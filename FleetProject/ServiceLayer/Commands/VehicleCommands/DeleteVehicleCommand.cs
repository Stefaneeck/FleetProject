using MediatR;
using Models;

namespace Commands.VehicleCommands
{
    public class DeleteVehicleCommand : IRequest<Unit>, IIdentifiable
    {
        public long Id { get; set; }
    }
}
