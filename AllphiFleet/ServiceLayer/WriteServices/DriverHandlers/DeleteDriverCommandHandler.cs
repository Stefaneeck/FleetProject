using Commands.DriverCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.DriverHandlers
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, Unit>
    {
        private readonly INHRepository<Driver> _driverContext;
        public DeleteDriverCommandHandler(INHRepository<Driver> driverContext)
        {
            _driverContext = driverContext;
        }
        public async Task<Unit> Handle(DeleteDriverCommand command, CancellationToken cancellationToken)
        {
            //driver from db
            var driver = new Driver();
            driver = _driverContext.Drivers.FirstOrDefault(c => c.Id == command.Id);

            _driverContext.BeginTransaction();

            try
            {
                await _driverContext.Delete(driver);
                await _driverContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _driverContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
