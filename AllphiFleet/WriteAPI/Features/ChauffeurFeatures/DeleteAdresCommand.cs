using MediatR;

namespace WriteAPI.Features.AdresFeatures
{
    public class DeleteAdresCommand : IRequest<int>
    {
        //public DeleteAdresDTO DeleteAdresDTO { get; set; }
        public long Id { get; set; }
    }
}
