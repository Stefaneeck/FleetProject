using DTO;
using MediatR;

namespace Commands.AdresCommands
{
    public class UpdateAdresCommand : IRequest<Unit>
    {
        public UpdateAdresDTO UpdateAdresDTO { get; set; }
    }
}
