using MediatR;
using SchoolManagement.Application.DTOs.LocalAgent;

namespace SchoolManagement.Application.Features.LocalAgents.Requests.Commands
{
    public class UpdateLocalAgentCommand : IRequest<Unit>
    {
        public LocalAgentDto LocalAgentDto { get; set; }
    }
}
