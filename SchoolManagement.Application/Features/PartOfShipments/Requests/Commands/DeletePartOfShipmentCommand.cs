using MediatR;

namespace SchoolManagement.Application.Features.PartOfShipments.Requests.Commands
{
    public class DeletePartOfShipmentCommand : IRequest
    {
        public int PartOfShipmentId { get; set; }
    }
}
