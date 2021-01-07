using FluentValidation;
using Models;
using System.Linq;
using WriteRepositories;

namespace Validation.Validators
{
    public static class ValidationExtensions
    {
        //in plaats van this aan te roepen, roepen we command aan
        public static void AddCheckIfExistsInDBValidator<TCommand, TEntity>(this AbstractValidator<TCommand> validator, INHRepository<TEntity> dbContext)
            where TCommand : class, IIdentifiable
            where TEntity : class, IIdentifiable

        {
            string message = typeof(TEntity).Name.ToString() + " does not exist.";

            //als we een command hebben met een id, moet er ook een chauffeur bestaan met die id in de database
            //lamdba, input is TCommand, output is id
            //voor elke command die we als input krijgen, geef zijn id terug
            //must gaat die id gebruiken om regel te definieren
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
