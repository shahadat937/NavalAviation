using MediatR;

namespace SchoolManagement.Application.Features.LocalAgents.Requests.Commands
{
    public class DeleteLocalAgentCommand : IRequest
    {
        public int LocalAgentId { get; set; }
    }
}
