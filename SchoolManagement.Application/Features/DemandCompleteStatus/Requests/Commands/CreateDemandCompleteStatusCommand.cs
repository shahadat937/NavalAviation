using MediatR;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Commands
{
    public class CreateDemandCompleteStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateDemandCompleteStatusDto DemandCompleteStatusDto { get; set; }
    }
}
