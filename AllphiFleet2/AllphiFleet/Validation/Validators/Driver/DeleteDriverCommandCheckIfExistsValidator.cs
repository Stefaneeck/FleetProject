using FluentValidation;
using Models;
using WriteRepositories;
using Commands.DriverCommands;

namespace Validation.Validators
{
    public class DeleteDriverCommandCheckIfExistsValidator : AbstractValidator<DeleteDriverCommand>
    {
        private readonly INHRepository<Driver> _driverContext;

        public DeleteDriverCommandCheckIfExistsValidator(INHRepository<Driver> driverContext)
        {
            _driverContext = driverContext;

            #region commentrulefor
            //not neccessary, by default return 405 not allowed without id parameter
            //RuleFor(c => c.Id).NotEmpty();
            #endregion

            this.AddCheckIfIdExistsInDBValidator(_driverContext);
            #region commentclassicway
            //if this would be called using the classic static way
            //ValidationExtensions.AddCheckIfExistsInDBValidator(this, _chauffeurContext);
            #endregion
        }
    }
}
