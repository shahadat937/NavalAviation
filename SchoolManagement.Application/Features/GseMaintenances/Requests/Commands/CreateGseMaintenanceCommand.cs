using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenance;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.GseMaintenances.Requests.Commands
{
    public class CreateGseMaintenanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateGseMaintenanceDto GseMaintenanceDto { get; set; }
    }
}
