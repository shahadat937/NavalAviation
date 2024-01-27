using MediatR;
using SchoolManagement.Application.DTOs.LocalAgent;

namespace SchoolManagement.Application.Features.LocalAgents.Requests.Queries
{
    public class GetLocalAgentDetailRequest : IRequest<LocalAgentDto>
    {
        public int LocalAgentId { get; set; }
    }
}
