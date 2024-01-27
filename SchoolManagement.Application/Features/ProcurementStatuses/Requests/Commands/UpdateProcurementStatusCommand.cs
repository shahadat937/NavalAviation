using MediatR;
using SchoolManagement.Application.DTOs.ProcurementStatus;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Requests.Commands
{
    public class UpdateProcurementStatusCommand : IRequest<Unit>
    {
        public ProcurementStatusDto ProcurementStatusDto { get; set; }
    }
}
