using MediatR;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Commands
{
    public class CreatePlaceOfDeliveryCommand : IRequest<BaseCommandResponse>
    {
        public CreatePlaceOfDeliveryDto PlaceOfDeliveryDto { get; set; }
    }
}
