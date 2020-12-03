using MediatR;
using Models;

namespace Commands.AanvraagCommands
{
    public class DeleteAanvraagCommand : IRequest<Unit>, IIdentifiable
    {
        //public DeleteAanvraagDTO DeleteAdresDTO { get; set; }
        public long Id { get; set; }
    }
}
