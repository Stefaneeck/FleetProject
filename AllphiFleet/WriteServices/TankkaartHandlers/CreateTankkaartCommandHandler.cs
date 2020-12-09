using Commands.TankkaartCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.TankkaartHandlers
{
    public class CreateTankkaartCommandHandler : IRequestHandler<CreateTankkaartCommand, int>
    {
        private readonly INHRepository<Tankkaart> _context;

        public CreateTankkaartCommandHandler(INHRepository<Tankkaart> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTankkaartCommand command, CancellationToken cancellationToken)
        {
            var tankkaart = new Tankkaart
            {
                AuthType = command.CreateTankkaartDTO.AuthType,
                GeldigheidsDatum = command.CreateTankkaartDTO.GeldigheidsDatum,
                Kaartnummer = command.CreateTankkaartDTO.Kaartnummer,
                Opties = command.CreateTankkaartDTO.Opties,
                Pincode = command.CreateTankkaartDTO.Pincode
            };

            _context.BeginTransaction();

            try
            {
                await _context.Save(tankkaart);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }

            return (int)tankkaart.Id;
        }
    }
}
