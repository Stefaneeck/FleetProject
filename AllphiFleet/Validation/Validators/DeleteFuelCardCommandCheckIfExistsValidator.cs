using FluentValidation;
using Models;
using WriteRepositories;
using Commands.FuelCardCommands;

namespace Validation.Validators
{
    public class DeleteFuelCardCommandCheckIfExistsValidator : AbstractValidator<DeleteFuelCardCommand>
    {
        private readonly INHRepository<FuelCard> _fuelCardContext;
        public DeleteFuelCardCommandCheckIfExistsValidator(INHRepository<FuelCard> fuelCardContext)
        {
            _fuelCardContext = fuelCardContext;

            this.AddCheckIfExistsInDBValidator(_fuelCardContext);

        }
    }
}
