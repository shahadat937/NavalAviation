using MediatR;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands
{
    public class ApprovedMaintenancePlanningCommand : IRequest 
    {
        public int MaintenancePlanningId { get; set; } 
    }
}
