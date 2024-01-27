using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Requests.Commands
{
    public class CreateMaintenanceTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaintenanceTypeDto MaintenanceTypeDto { get; set; }
    }
}
