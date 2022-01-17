using Commands.AddressCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.AddressHandlers
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Unit>
    {
        private readonly INHRepository<Address> _addressContext;
        public DeleteAddressCommandHandler(INHRepository<Address> addressContext)
        {
            _addressContext = addressContext;
        }

        //you must always return something with mediatr
        //unit is void equivalent of mediatr
        public async Task<Unit> Handle(DeleteAddressCommand command, CancellationToken cancellationToken)
        {
            //address from db
            var address = _addressContext.Addresses.FirstOrDefault(a => a.Id == command.Id);

            _addressContext.BeginTransaction();

            try
            {
                await _addressContext.Delete(address);
                await _addressContext.Commit();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                await _addressContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
