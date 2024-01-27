using MediatR;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Queries
{
    public class GetPlaceOfDeliveryDetailRequest : IRequest<PlaceOfDeliveryDto>
    {
        public int PlaceOfDeliveryId { get; set; }
    }
}
