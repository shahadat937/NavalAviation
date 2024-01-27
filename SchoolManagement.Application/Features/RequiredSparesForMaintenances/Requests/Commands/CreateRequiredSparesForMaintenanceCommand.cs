using MediatR;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands
{
    public class CreateRequiredSparesForMaintenanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateRequiredSparesForMaintenanceDto RequiredSparesForMaintenanceDto { get; set; }
    }
}
