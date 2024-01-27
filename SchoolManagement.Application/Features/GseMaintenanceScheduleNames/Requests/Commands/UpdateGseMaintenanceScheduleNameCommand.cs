using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Commands
{
    public class UpdateGseMaintenanceScheduleNameCommand : IRequest<Unit>
    {
        public GseMaintenanceScheduleNameDto GseMaintenanceScheduleNameDto { get; set; }
    }
}
