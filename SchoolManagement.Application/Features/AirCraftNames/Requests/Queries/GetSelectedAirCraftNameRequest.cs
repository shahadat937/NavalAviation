using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Queries
{
    public class GetSelectedAirCraftNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
