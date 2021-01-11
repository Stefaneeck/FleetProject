using MediatR;
using Models;

namespace Commands.AddressCommands
{
    public class DeleteAddressCommand : IRequest<Unit>, IIdentifiable
    {
        //public DeleteAddressDTO DeleteAdresDTO { get; set; }
        public long Id { get; set; }
    }
}
