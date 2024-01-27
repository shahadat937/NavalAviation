using MediatR;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Commands
{
    public class DeleteGseMaintenanceScheduleNameCommand : IRequest
    {
        public int GseMaintenanceScheduleNameId { get; set; }
    }
}
