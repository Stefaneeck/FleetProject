using Commands.AddressCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.AddressHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly INHRepository<Address> _context;

        public CreateAddressCommandHandler(INHRepository<Address> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            var address = new Address
            {
                Id = 0,
                Street = command.CreateAddressDTO.Street,
                Number = command.CreateAddressDTO.Number,
                City = command.CreateAddressDTO.City,
                Zipcode = command.CreateAddressDTO.Zipcode
            };

            _context.BeginTransaction();

            try
            {
                await _context.Save(address);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }

            return (int)address.Id;
        }
    }
}
