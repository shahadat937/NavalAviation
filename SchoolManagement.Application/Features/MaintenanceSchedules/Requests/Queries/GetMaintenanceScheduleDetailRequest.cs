using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
    public class GetMaintenanceScheduleDetailRequest : IRequest<MaintenanceScheduleDto>
    {
        public int MaintenanceScheduleId { get; set; }
    }
}
