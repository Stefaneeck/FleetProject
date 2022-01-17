using MediatR;
using Models;

namespace Commands.AddressCommands
{
    public class DeleteAddressCommand : IRequest<Unit>, IIdentifiable
    {
        public long Id { get; set; }
    }
}
