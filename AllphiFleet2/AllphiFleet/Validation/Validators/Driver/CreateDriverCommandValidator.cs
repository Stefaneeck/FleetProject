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
            RuleFor(c => c.CreateDriverDTO.Email).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.BirthDate).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.SocSecNr).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.Active).Must(x => x == false || x == true);
            RuleFor(c => c.CreateDriverDTO.DriverLicenseType).IsInEnum();
            RuleFor(c => c.CreateDriverDTO.Email).NotEmpty();

            RuleFor(c => c.CreateDriverDTO.Address.Street).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.Address.Number).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.Address.Zipcode).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.Address.City).NotEmpty();
       
            RuleFor(c => c.CreateDriverDTO.FuelCard.AuthType).IsInEnum();
            RuleFor(c => c.CreateDriverDTO.FuelCard.ValidUntilDate).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.FuelCard.Pincode).NotEmpty();
            RuleFor(c => c.CreateDriverDTO.FuelCard.Active).Must(x => x == false || x == true);

        }
    }
}
