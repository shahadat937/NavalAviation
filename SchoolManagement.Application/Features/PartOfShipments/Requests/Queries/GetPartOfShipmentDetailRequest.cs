using MediatR;
using SchoolManagement.Application.DTOs.PartOfShipment;

namespace SchoolManagement.Application.Features.PartOfShipments.Requests.Queries
{
    public class GetPartOfShipmentDetailRequest : IRequest<PartOfShipmentDto>
    {
        public int PartOfShipmentId { get; set; }
    }
}
