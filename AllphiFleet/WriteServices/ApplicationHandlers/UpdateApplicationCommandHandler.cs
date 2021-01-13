﻿using Commands.ApplicationCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.ApplicationHandlers
{
    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, Unit>
    {
        private readonly INHRepository<Application> _applicationContext;
        public UpdateApplicationCommandHandler(INHRepository<Application> applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<Unit> Handle(UpdateApplicationCommand command, CancellationToken cancellationToken)
        {
            Application applicationFromDb = _applicationContext.Applications.FirstOrDefault(application => application.Id == command.UpdateApplicationDTO.Id);

            var application = new Application
            {
                Id = command.UpdateApplicationDTO.Id,
                ApplicationDate = command.UpdateApplicationDTO.ApplicationDate,
                PossibleDates = command.UpdateApplicationDTO.PossibleDates,
                ApplicationStatus = command.UpdateApplicationDTO.ApplicationStatus,

                //from db, for now (to edit later)
                VehicleId = applicationFromDb.VehicleId,
                DriverId = applicationFromDb.DriverId,

                ApplicationType = command.UpdateApplicationDTO.ApplicationType

            };

            _applicationContext.BeginTransaction();

            try
            {
                await _applicationContext.Update(application);
                await _applicationContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);

                await _applicationContext.Rollback();
            }

            return Unit.Value;
        }
    }
}