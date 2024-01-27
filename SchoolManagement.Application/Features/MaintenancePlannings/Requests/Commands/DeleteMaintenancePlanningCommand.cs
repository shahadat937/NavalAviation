using MediatR;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands
{
    public class DeleteMaintenancePlanningCommand : IRequest
    {
        public int MaintenancePlanningId { get; set; }
    }
}
