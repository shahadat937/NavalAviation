using MediatR;
using SchoolManagement.Application.DTOs.ProcurementStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Requests.Commands
{
    public class CreateProcurementStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateProcurementStatusDto ProcurementStatusDto { get; set; }
    }
}
