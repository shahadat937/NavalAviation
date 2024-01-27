using MediatR;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands
{
    public class ApprovedMaintenanceScheduleCommand : IRequest 
    {
        public int MaintenanceScheduleId { get; set; } 
    }
}
