using MediatR;
using SchoolManagement.Application.DTOs.DemandStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DemandStatuses.Requests.Commands
{
    public class CreateDemandStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateDemandStatusDto DemandStatusDto { get; set; }
    }
}
