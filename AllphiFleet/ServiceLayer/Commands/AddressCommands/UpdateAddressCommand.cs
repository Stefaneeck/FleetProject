using DTO;
using MediatR;

namespace Commands.AddressCommands
{
    public class UpdateAddressCommand : IRequest<Unit>
    {
        public UpdateAddressDTO UpdateAddressDTO { get; set; }
    }
}
