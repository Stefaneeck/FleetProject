using FluentValidation;
using Models;
using WriteRepositories;
using Commands.ApplicationCommands;

namespace Validation.Validators
{
    public class DeleteApplicationCommandCheckIfExistsValidator : AbstractValidator<DeleteApplicationCommand>
    {
        private readonly INHRepository<Application> _applicationContext;
        public DeleteApplicationCommandCheckIfExistsValidator(INHRepository<Application> applicationContext)
        {
            _applicationContext = applicationContext;
            this.AddCheckIfIdExistsInDBValidator(_applicationContext);
        }
    }
}
