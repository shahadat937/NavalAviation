using MediatR;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands
{
    public class DeleteMaintenanceScheduleCommand : IRequest
    {
        public int MaintenanceScheduleId { get; set; }
    }
}
