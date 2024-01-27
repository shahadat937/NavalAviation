using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Commands
{
    public class CreateGseMaintenanceScheduleNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateGseMaintenanceScheduleNameDto GseMaintenanceScheduleNameDto { get; set; }
    }
}
