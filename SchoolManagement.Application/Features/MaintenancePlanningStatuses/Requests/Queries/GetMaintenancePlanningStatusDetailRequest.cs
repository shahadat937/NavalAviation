using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Queries
{
    public class GetMaintenancePlanningStatusDetailRequest : IRequest<MaintenancePlanningStatusDto>
    {
        public int MaintenancePlanningStatusId { get; set; }
    }
}
