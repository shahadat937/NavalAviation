using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandStatuses.Requests.Queries
{
    public class GetSelectedDemandStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
