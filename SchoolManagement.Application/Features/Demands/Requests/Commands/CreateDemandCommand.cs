using MediatR;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Demands.Requests.Commands
{
    public class CreateDemandCommand : IRequest<BaseCommandResponse>
    {
        public CreateDemandDto DemandDto { get; set; }
    }
}
