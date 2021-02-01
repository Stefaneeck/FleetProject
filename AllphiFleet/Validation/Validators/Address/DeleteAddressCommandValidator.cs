using FluentValidation;
using Models;
using WriteRepositories;
using Commands.AddressCommands;

namespace Validation.Validators
{
    public class DeleteAddressCommandCheckIfExistsValidator : AbstractValidator<DeleteAddressCommand>
    {
        private readonly INHRepository<Address> _addressContext;
        public DeleteAddressCommandCheckIfExistsValidator(INHRepository<Address> addressContext)
        {
            _addressContext = addressContext;
            this.AddCheckIfIdExistsInDBValidator(_addressContext);
        }
    }
}
