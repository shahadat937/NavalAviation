using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Queries
{
    public class GetSelectedMaintenancePlanningStatusRequest : IRequest<List<SelectedModel>>
    {
    }
} 
