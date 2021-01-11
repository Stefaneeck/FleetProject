using DTO;
using MediatR;

namespace Commands.FuelCardCommands
{
    public class CreateFuelCardCommand : IRequest<int>
    {
        public CreateFuelCardDTO CreateFuelCardDTO { get; set; }
    }
}
