using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Commands
{
    public class UpdateMaintenancePlanningStatusCommand : IRequest<Unit>
    { 
        public MaintenancePlanningStatusDto MaintenancePlanningStatusDto { get; set; }
    }
}
