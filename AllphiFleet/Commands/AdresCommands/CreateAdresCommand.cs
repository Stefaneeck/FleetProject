using DTO;
using MediatR;

namespace Commands.AdresCommands
{
    //mag dto zijn?
    public class CreateAdresCommand : IRequest<int>
    {
        public CreateAdresDTO CreateAdresDTO { get; set; }
    }
}
