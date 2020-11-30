using MediatR;

namespace WriteAPI.Features.AanvraagFeatures
{
    public class DeleteAanvraagCommand : IRequest<Unit>
    {
        //public DeleteAanvraagDTO DeleteAdresDTO { get; set; }
        public long Id { get; set; }
    }
}
