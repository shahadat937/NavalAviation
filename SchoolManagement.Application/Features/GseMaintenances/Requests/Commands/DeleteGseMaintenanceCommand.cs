using MediatR;

namespace SchoolManagement.Application.Features.GseMaintenances.Requests.Commands
{
    public class DeleteGseMaintenanceCommand : IRequest
    {
        public int GseMaintenanceId { get; set; }
    }
}
