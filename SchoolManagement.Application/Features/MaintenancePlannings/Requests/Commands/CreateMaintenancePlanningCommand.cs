using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands
{
    public class CreateMaintenancePlanningCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaintenancePlanningDto MaintenancePlanningDto { get; set; }
    }
}
