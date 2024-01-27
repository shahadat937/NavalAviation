using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetSelectedMaintenancePlanningRequest : IRequest<List<SelectedModel>>
    {
    }
}
