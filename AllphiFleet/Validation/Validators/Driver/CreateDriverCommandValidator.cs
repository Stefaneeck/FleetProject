using FluentValidation;
using Commands.DriverCommands;
using WriteRepositories;
using Models;
using System.Linq;

namespace Validation.Validators
{
    //validation with fluentvalidation package
    public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
    {
        private readonly INHRepository<Driver> _driverContext;

        public CreateDriverCommandValidator(INHRepository<Driver> driverContext)
        {
            _driverContext = driverContext;

            RuleFor(command => command.CreateDriverDTO.SocSecNr)
            .Must(socSecNr =>
            {
                var obj = _driverContext.Drivers.FirstOrDefault(driver => driver.SocSecNr.ToLower().Trim() == socSecNr.ToLower().Trim());
                return obj == null;
            })
            .WithErrorCode("AlreadyExists")
            .WithMessage("Driver already exists.");

            RuleFor(c => c.CreateDriverDTO.Name).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.FirstName).NotEmpty();

            #region commentrulefor
            //doesnt work, notempty with boolean -> only ok if true
            //RuleFor(c => c.CreateDriverDTO.Actief).NotEmpty();
            //not neccessary, if he gets other value he will fail even before this
            //RuleFor(c => c.CreateDriverDTO.Actief).Must(actief => actief == false || actief == true);
            #endregion

            RuleFor(c => c.CreateDriverDTO.BirthDate).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.SocSecNr).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.DriverLicenseType).IsInEnum();
            RuleFor(c => c.CreateDriverDTO.FuelCard.AuthType).IsInEnum();
            RuleFor(c => c.CreateDriverDTO.Email).NotEmpty();
        }
    }
}
