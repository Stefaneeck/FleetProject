using DTO;
using MediatR;

namespace Commands.FuelCardCommands
{
    public class UpdateFuelCardCommand : IRequest<Unit>
    {
        public UpdateFuelCardDTO UpdateFuelCardDTO { get; set; }
    }
}
