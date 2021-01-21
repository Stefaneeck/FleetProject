using FluentValidation;
using Models;
using System.Linq;
using WriteRepositories;

namespace Validation.Validators
{
    public static class ValidationExtensions
    {
        //instead of calling this, we call command (extension)
        public static void AddCheckIfExistsInDBValidator<TCommand, TEntity>(this AbstractValidator<TCommand> validator, INHRepository<TEntity> dbContext)
            where TCommand : class, IIdentifiable
            where TEntity : class, IIdentifiable

        {
            string message = typeof(TEntity).Name.ToString() + " does not exist.";

            #region commentcommand
            //if we have a command with id, there must exist a driver in db with that id
            //lamdba, input is TCommand, output is id
            //for each command we have as input, retrieve its id
            //must will use that id to define rule
            #endregion

            validator.RuleFor(command => command.Id)
            .Must(id =>
            {
                var obj = dbContext.GenericRepository.FirstOrDefault(entity => entity.Id == id);
                return obj != null;
            })
            .WithErrorCode("AlreadyExists")
            .WithMessage(message);
        }
    }
}
