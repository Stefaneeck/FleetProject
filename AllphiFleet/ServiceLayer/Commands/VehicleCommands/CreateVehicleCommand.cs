using DTO;
using MediatR;

namespace Commands.VehicleCommands
{
    public class CreateVehicleCommand : IRequest<int>
    {
        public CreateVehicleDTO CreateVehicleDTO { get; set; }
    }
}
