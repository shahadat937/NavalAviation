using MediatR;
using SchoolManagement.Application.DTOs.PartOfShipment;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.PartOfShipments.Requests.Commands
{
    public class CreatePartOfShipmentCommand : IRequest<BaseCommandResponse>
    {
        public CreatePartOfShipmentDto PartOfShipmentDto { get; set; }
    }
}
