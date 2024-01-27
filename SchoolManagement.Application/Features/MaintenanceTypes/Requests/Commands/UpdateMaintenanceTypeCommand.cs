using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceType;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Requests.Commands
{
    public class UpdateMaintenanceTypeCommand : IRequest<Unit>
    {
        public MaintenanceTypeDto MaintenanceTypeDto { get; set; }
    }
}
