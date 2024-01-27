using MediatR;
using SchoolManagement.Application.DTOs.PartOfShipment;

namespace SchoolManagement.Application.Features.PartOfShipments.Requests.Commands
{
    public class UpdatePartOfShipmentCommand : IRequest<Unit>
    {
        public PartOfShipmentDto PartOfShipmentDto { get; set; }
    }
}
