using DTO;
using MediatR;

namespace Commands.AddressCommands
{
    public class CreateAddressCommand : IRequest<int>
    {
        public CreateAddressDTO CreateAddressDTO { get; set; }
    }
}
