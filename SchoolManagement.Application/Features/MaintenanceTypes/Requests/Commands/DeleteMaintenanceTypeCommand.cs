using MediatR;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Requests.Commands
{
    public class DeleteMaintenanceTypeCommand : IRequest
    {
        public int MaintenanceTypeId { get; set; }
    }
}
