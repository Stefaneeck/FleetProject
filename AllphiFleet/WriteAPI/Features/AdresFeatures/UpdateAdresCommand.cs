using DTO;
using MediatR;

namespace WriteAPI.Features.AdresFeatures
{
    public class UpdateAdresCommand : IRequest<Unit>
    {
        public UpdateAdresDTO UpdateAdresDTO { get; set; }
    }
}
