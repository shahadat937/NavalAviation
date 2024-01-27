using MediatR;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands
{
    public class DeleteRequiredSparesForMaintenanceCommand : IRequest
    {
        public int RequiredSparesForMaintenanceId { get; set; }
    }
}
