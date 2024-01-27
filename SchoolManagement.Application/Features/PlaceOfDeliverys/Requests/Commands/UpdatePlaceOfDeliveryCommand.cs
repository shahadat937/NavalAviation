using MediatR;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Commands
{
    public class UpdatePlaceOfDeliveryCommand : IRequest<Unit>
    {
        public PlaceOfDeliveryDto PlaceOfDeliveryDto { get; set; }
    }
}
