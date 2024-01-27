using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenance;

namespace SchoolManagement.Application.Features.GseMaintenances.Requests.Commands
{
    public class UpdateGseMaintenanceCommand : IRequest<Unit>
    {
        public GseMaintenanceDto GseMaintenanceDto { get; set; }
    }
}
