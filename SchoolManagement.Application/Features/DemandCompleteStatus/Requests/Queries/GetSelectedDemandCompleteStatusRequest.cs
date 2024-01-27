using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Queries
{
    public class GetSelectedDemandCompleteStatusRequest : IRequest<List<SelectedModel>>
    {
    }
} 
