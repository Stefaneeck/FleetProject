using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WriteRepositories;

namespace Validation.Validators
{
    public static class ValidationExtensions
    {
        //elke keer als we this aanroepen, kunnen we het als command aanroepen
        //in plaats van this aan te roepen, roepen we command aan
        public static void AddCheckIfExistsInDBValidator<TCommand, TEntity>(this AbstractValidator<TCommand> validator, INHRepository<TEntity> dbContext)
            where TCommand : IIdentifiable
            where TEntity : class, IIdentifiable

        {
            string boodschap = typeof(TEntity).Name.ToString() + " bestaat niet";

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
            .WithMessage(boodschap);
        }
    }
}
