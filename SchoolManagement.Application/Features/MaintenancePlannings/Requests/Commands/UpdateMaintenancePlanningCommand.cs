using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanning;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands
{
    public class UpdateMaintenancePlanningCommand : IRequest<Unit>
    {
        public CreateMaintenancePlanningDto UpdateMaintenancePlanningDto { get; set; }
    }
}
