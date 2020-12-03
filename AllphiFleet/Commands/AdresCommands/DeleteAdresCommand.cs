using MediatR;
using Models;

namespace Commands.AdresCommands
{
    public class DeleteAdresCommand : IRequest<Unit>, IIdentifiable
    {
        //public DeleteAdresDTO DeleteAdresDTO { get; set; }
        public long Id { get; set; }
    }
}
