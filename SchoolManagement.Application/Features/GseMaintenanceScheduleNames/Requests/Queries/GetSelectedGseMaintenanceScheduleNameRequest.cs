using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Queries
{
    public class GetSelectedGseMaintenanceScheduleNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
