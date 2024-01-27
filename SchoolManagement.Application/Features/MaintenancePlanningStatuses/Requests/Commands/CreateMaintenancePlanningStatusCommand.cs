using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Commands
{
    public class CreateMaintenancePlanningStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaintenancePlanningStatusDto MaintenancePlanningStatusDto { get; set; }
    }
}
