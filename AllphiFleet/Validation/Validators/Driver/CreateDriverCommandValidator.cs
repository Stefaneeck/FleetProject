using FluentValidation;
using Commands.DriverCommands;

namespace Validation.Validators
{
    //validation with fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
    {
        public CreateDriverCommandValidator()
        {
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
