using DTO;
using MediatR;

namespace WriteAPI.Features.AanvraagFeatures
{
    //mag dto zijn?
    public class CreateAanvraagCommand : IRequest<int>
    {
        /*
        public DateTime DatumAanvraag { get; set; }
        public AanvraagTypes TypeAanvraag { get; set; }
        public string GewensteData { get; set; }
        public AanvraagStatussen StatusAanvraag { get; set; }
        public long VoertuigId { get; set; }
        */

        public CreateAanvraagDTO createAanvraagDTO { get; set; }
        
    }
}
