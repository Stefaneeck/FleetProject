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
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, Unit>
    {
        private readonly INHRepository<Driver> _driverContext;
        public UpdateDriverCommandHandler(INHRepository<Driver> driverContext)
        {
            _driverContext = driverContext;

        }
        public async Task<Unit> Handle(UpdateDriverCommand command, CancellationToken cancellationToken)
        {
            Driver driverFromDb = _driverContext.Drivers.FirstOrDefault(c => c.Id == command.UpdateDriverDTO.Id);

            var driver = new Driver
            {
                Id = command.UpdateDriverDTO.Id,
                Name = command.UpdateDriverDTO.Name,
                FirstName = command.UpdateDriverDTO.FirstName,
                BirthDate = command.UpdateDriverDTO.BirthDate,
                SocSecNr = command.UpdateDriverDTO.SocSecNr,
                DriverLicenseType = command.UpdateDriverDTO.DriverLicenseType,
                Active = command.UpdateDriverDTO.Active,

                 Address = new Address
                {
                    //id from db
                    Id = driverFromDb.Address.Id,

                    Street = command.UpdateDriverDTO.Address.Street,
                    Number = command.UpdateDriverDTO.Address.Number,
                    City = command.UpdateDriverDTO.Address.City,
                    Zipcode = command.UpdateDriverDTO.Address.Zipcode
                },

                FuelCard = new FuelCard
                {
                    //id from db
                    Id = driverFromDb.FuelCard.Id,

                    CardNumber = command.UpdateDriverDTO.FuelCard.CardNumber,
                    ValidUntilDate = command.UpdateDriverDTO.FuelCard.ValidUntilDate,
                    Pincode = command.UpdateDriverDTO.FuelCard.Pincode,
                    AuthType = command.UpdateDriverDTO.FuelCard.AuthType,
                    Options = command.UpdateDriverDTO.FuelCard.Options
                }

            };

            _driverContext.BeginTransaction();

            try
            {
                //_session.Evict(chauffeur);

                await _driverContext.Update(driver);
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
