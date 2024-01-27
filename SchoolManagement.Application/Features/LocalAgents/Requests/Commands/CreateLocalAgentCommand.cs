using MediatR;
using SchoolManagement.Application.DTOs.LocalAgent;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.LocalAgents.Requests.Commands
{
    public class CreateLocalAgentCommand : IRequest<BaseCommandResponse>
    {
        public CreateLocalAgentDto LocalAgentDto { get; set; }
    }
}
