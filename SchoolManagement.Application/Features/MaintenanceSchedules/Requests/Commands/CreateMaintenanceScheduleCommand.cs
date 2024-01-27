using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands
{
    public class CreateMaintenanceScheduleCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaintenanceScheduleDto MaintenanceScheduleDto { get; set; }
    }
}
