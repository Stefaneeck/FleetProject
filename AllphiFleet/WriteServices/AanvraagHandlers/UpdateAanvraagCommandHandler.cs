using Commands.AanvraagCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.AanvraagHandlers
{
    public class UpdateAanvraagCommandHandler : IRequestHandler<UpdateAanvraagCommand, Unit>
    {
        private readonly INHRepository<Aanvraag> _aanvraagContext;
        public UpdateAanvraagCommandHandler(INHRepository<Aanvraag> aanvraagContext)
        {
            _aanvraagContext = aanvraagContext;
        }
        public async Task<Unit> Handle(UpdateAanvraagCommand command, CancellationToken cancellationToken)
        {
            Aanvraag aanvraagVanDB = _aanvraagContext.Aanvragen.FirstOrDefault(aanvraag => aanvraag.Id == command.UpdateAanvraagDTO.Id);

            var aanvraag = new Aanvraag
            {
                Id = command.UpdateAanvraagDTO.Id,

                DatumAanvraag = command.UpdateAanvraagDTO.DatumAanvraag,
                GewensteData = command.UpdateAanvraagDTO.GewensteData,
                StatusAanvraag = command.UpdateAanvraagDTO.StatusAanvraag,

                Voertuig = new Voertuig
                {
                    //id from db
                    Id = aanvraagVanDB.Voertuig.Id,

                    ChassisNr = command.UpdateAanvraagDTO.Voertuig.ChassisNr,
                    KilometerStand = command.UpdateAanvraagDTO.Voertuig.KilometerStand,
                    TypeBrandStof = command.UpdateAanvraagDTO.Voertuig.TypeBrandStof,
                    TypeWagen = command.UpdateAanvraagDTO.Voertuig.TypeWagen
                },

                TypeAanvraag = command.UpdateAanvraagDTO.TypeAanvraag

            };

            _aanvraagContext.BeginTransaction();

            try
            {
                await _aanvraagContext.Update(aanvraag);
                await _aanvraagContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _aanvraagContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
