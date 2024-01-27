using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Queries
{
    public class GetSelectedPlaceOfDeliveryRequest : IRequest<List<SelectedModel>>
    {
    }
}
