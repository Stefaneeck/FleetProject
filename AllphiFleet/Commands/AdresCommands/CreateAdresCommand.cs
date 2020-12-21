using DTO;
using MediatR;

namespace Commands.AdresCommands
{
    public class CreateAdresCommand : IRequest<int>
    {
        public CreateAdresDTO CreateAdresDTO { get; set; }
    }
}
