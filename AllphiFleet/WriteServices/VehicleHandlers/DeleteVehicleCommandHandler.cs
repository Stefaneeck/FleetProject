using Commands.VehicleCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.VehicleHandlers
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Unit>
    {
        private readonly INHRepository<Vehicle> _context;

        public DeleteVehicleCommandHandler(INHRepository<Vehicle> context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
        {
            //address from db
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == command.Id);

            _context.BeginTransaction();

            try
            {
                await _context.Delete(vehicle);
                await _context.Commit();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                await _context.Rollback();
            }

            return Unit.Value;
        }
    }
}
