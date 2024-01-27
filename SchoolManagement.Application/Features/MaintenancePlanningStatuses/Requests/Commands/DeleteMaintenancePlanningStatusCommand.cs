using MediatR;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Commands
{
    public class DeleteMaintenancePlanningStatusCommand : IRequest
    {
        public int MaintenancePlanningStatusId { get; set; }
    }
} 
