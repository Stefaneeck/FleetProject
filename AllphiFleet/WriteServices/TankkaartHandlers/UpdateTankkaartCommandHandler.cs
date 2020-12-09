using Commands.TankkaartCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.TankkaartHandlers
{
    public class UpdateTankkaartCommandHandler : IRequestHandler<UpdateTankkaartCommand, Unit>
    {
        private readonly INHRepository<Tankkaart> _tankkaartContext;
        public UpdateTankkaartCommandHandler(INHRepository<Tankkaart> tankkaartContext)
        {
            _tankkaartContext = tankkaartContext;

        }
        public async Task<Unit> Handle(UpdateTankkaartCommand command, CancellationToken cancellationToken)
        {
            Tankkaart tankkaartVanDB = _tankkaartContext.Tankkaarten.FirstOrDefault(t => t.Id == command.UpdateTankkaartDTO.Id);

            var tankkaart = new Tankkaart
            {
                Id = command.UpdateTankkaartDTO.Id,
                AuthType = command.UpdateTankkaartDTO.AuthType,
                GeldigheidsDatum = command.UpdateTankkaartDTO.GeldigheidsDatum,
                Kaartnummer = command.UpdateTankkaartDTO.Kaartnummer,
                Opties = command.UpdateTankkaartDTO.Opties,
                Pincode = command.UpdateTankkaartDTO.Pincode
            };

            _tankkaartContext.BeginTransaction();

            try
            {
                await _tankkaartContext.Update(tankkaart);
                await _tankkaartContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _tankkaartContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
