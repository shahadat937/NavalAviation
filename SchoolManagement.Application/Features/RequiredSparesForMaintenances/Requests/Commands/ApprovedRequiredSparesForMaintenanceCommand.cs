using MediatR;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands
{
    public class ApprovedRequiredSparesForMaintenanceCommand : IRequest 
    {
        public int RequiredSparesForMaintenanceId { get; set; } 
    }
}
