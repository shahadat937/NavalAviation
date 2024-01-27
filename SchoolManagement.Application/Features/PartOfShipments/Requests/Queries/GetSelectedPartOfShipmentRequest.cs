using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PartOfShipments.Requests.Queries
{
    public class GetSelectedPartOfShipmentRequest : IRequest<List<SelectedModel>>
    {
    }
}
