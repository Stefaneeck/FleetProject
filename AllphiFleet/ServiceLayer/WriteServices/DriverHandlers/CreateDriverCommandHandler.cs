using Commands.DriverCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.DriverHandlers
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, int>
    {
        private readonly INHRepository<Driver> _context;

        public CreateDriverCommandHandler(INHRepository<Driver> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
        {
            var driver = new Driver
            {
                Name = command.CreateDriverDTO.Name,
                FirstName = command.CreateDriverDTO.FirstName,
                BirthDate = command.CreateDriverDTO.BirthDate,
                SocSecNr = command.CreateDriverDTO.SocSecNr,
                DriverLicenseType = command.CreateDriverDTO.DriverLicenseType,
                Active = command.CreateDriverDTO.Active,
                Email = command.CreateDriverDTO.Email,

                Address = new Address
                {
                    Id = 0,
                    Street = command.CreateDriverDTO.Address.Street,
                    Number = command.CreateDriverDTO.Address.Number,
                    City = command.CreateDriverDTO.Address.City,
                    Zipcode = command.CreateDriverDTO.Address.Zipcode
                },

                FuelCard = new FuelCard
                {
                    Id = 0,
                    CardNumber = command.CreateDriverDTO.FuelCard.CardNumber,
                    ValidUntilDate = command.CreateDriverDTO.FuelCard.ValidUntilDate,
                    Pincode = command.CreateDriverDTO.FuelCard.Pincode,
                    AuthType = command.CreateDriverDTO.FuelCard.AuthType,
                    Options = command.CreateDriverDTO.FuelCard.Options,
                    Active = command.CreateDriverDTO.FuelCard.Active
                }
            };

            _context.BeginTransaction();

            try
            {
                //we could have spoken to the different contexts separately, for more control
                await _context.Save(driver);
                await _context.Commit();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }
            
            return (int)driver.Id;
        }
    }
}
