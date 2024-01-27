using MediatR;
using SchoolManagement.Application.DTOs.DemandType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DemandTypes.Requests.Commands
{
    public class CreateDemandTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateDemandTypeDto DemandTypeDto { get; set; }
    }
}
