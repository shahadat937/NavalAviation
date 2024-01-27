using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands
{
    public class UpdateMaintenanceScheduleCommand : IRequest<Unit>
    {
        public CreateMaintenanceScheduleDto UpdateMaintenanceScheduleDto { get; set; }
    }
}
