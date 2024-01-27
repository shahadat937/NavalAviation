using MediatR;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Commands
{
    public class DeletePlaceOfDeliveryCommand : IRequest
    {
        public int PlaceOfDeliveryId { get; set; }
    }
}
