using Commands.ApplicationCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.ApplicationHandlers
{
    public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, Unit>
    {
        private readonly INHRepository<Application> _applicationContext;
        public DeleteApplicationCommandHandler(INHRepository<Application> applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Unit> Handle(DeleteApplicationCommand command, CancellationToken cancellationToken)
        {
            var application = _applicationContext.Applications.FirstOrDefault(a => a.Id == command.Id);

            _applicationContext.BeginTransaction();

            try
            {
                await _applicationContext.Delete(application);
                await _applicationContext.Commit();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _applicationContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
