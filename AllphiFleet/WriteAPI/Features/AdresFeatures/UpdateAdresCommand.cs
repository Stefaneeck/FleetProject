using DTO;
using MediatR;

namespace WriteAPI.Features.AdresFeatures
{
    public class UpdateAdresCommand : IRequest<int>
    {
        public UpdateAdresDTO UpdateAdresDTO { get; set; }
    }
}
