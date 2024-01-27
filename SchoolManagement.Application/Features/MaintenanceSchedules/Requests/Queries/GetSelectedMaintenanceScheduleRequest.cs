using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
    public class GetSelectedMaintenanceScheduleRequest : IRequest<List<SelectedModel>>
    {
    }
}
