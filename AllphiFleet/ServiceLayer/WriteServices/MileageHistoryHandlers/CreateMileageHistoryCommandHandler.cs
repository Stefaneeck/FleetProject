using Commands.MileageHistoryCommands;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.MileageHistoryHandlers
{
    public class CreateMileageHistoryCommandHandler : IRequestHandler<CreateMileageHistoryCommand, int>
    {
        private readonly INHRepository<MileageHistory> _context;

        public CreateMileageHistoryCommandHandler(INHRepository<MileageHistory> context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMileageHistoryCommand command, CancellationToken cancellationToken)
        {
            //not being used now, code is added in UpdateVehicleCommandHandler
            var mileageHistory = new MileageHistory
            {
                Id = 0,
                Mileage = command.CreateMileageHistoryDTO.Mileage,
                VehicleId = command.CreateMileageHistoryDTO.VehicleId
            };

            _context.BeginTransaction();

            try
            {
                await _context.Save(mileageHistory);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                await _context.Rollback();
            }

            return (int)mileageHistory.Id;
        }
    }
}
