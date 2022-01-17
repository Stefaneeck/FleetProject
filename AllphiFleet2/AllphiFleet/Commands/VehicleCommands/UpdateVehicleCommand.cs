using DTO;
using MediatR;

namespace Commands.VehicleCommands
{
    public class UpdateVehicleCommand : IRequest<Unit>
    {
        public UpdateVehicleDTO UpdateVehicleDTO { get; set; }
    }
}
