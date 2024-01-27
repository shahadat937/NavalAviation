using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Requests.Queries
{
    public class GetSelectedOccasionOfDemandRequest : IRequest<List<SelectedModel>>
    {
    }
}
