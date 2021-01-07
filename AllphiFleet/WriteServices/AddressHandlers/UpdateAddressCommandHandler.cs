using Commands.AddressCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Unit>
    {
        private readonly INHRepository<Address> _addressContext;
        public UpdateAddressCommandHandler(INHRepository<Address> addressContext)
        {
            _addressContext = addressContext;
        }
        public async Task<Unit> Handle(UpdateAddressCommand command, CancellationToken cancellationToken)
        {

            var address = new Address
            {
                Id = command.UpdateAddressDTO.Id,
                Street = command.UpdateAddressDTO.Street,
                Number = command.UpdateAddressDTO.Number,
                City = command.UpdateAddressDTO.City,
                Zipcode = command.UpdateAddressDTO.Zipcode

            };

            _addressContext.BeginTransaction();

            try
            {
                await _addressContext.Update(address);
                await _addressContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _addressContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
