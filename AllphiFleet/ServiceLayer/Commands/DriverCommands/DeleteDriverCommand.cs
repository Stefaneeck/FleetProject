using MediatR;
using Models;

namespace Commands.DriverCommands
{
    public class DeleteDriverCommand : IRequest<Unit>, IIdentifiable
    {
        public long Id { get; set; }
    }
}
