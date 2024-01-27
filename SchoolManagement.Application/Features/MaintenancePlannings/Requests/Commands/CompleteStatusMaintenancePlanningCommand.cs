using MediatR;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands
{
    public class CompleteStatusMaintenancePlanningCommand : IRequest 
    {
        public int MaintenancePlanningId { get; set; } 
    }
}
