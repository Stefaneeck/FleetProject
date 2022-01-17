using MediatR;
using Models;

namespace Commands.FuelCardCommands
{
    public class DeleteFuelCardCommand : IRequest<Unit>, IIdentifiable
    {
        public long Id { get; set; }
    }
}
