using DTO;
using MediatR;

namespace WriteAPI.Features.AdresFeatures
{
    //mag dto zijn?
    public class CreateAdresCommand : IRequest<int>
    {
        public CreateAdresDTO CreateAdresDTO { get; set; }
    }
}
