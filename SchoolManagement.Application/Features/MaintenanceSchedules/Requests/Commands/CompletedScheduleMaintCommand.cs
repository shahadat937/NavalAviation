using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands
{
    public class CompletedScheduleMaintCommand : IRequest<Unit>
    {
        public CompletedScheduleMaintDto CompletedScheduleMaintDto { get; set; }
    }
} 
