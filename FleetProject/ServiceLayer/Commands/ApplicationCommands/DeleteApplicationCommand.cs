using MediatR;
using Models;

namespace Commands.ApplicationCommands
{
    public class DeleteApplicationCommand : IRequest<Unit>, IIdentifiable
    {
        public long Id { get; set; }
    }
}
