using MediatR;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Requests.Commands
{
    public class DeleteProcurementStatusCommand : IRequest
    {
        public int ProcurementStatusId { get; set; }
    }
}
