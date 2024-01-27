using MediatR;
using SchoolManagement.Application.DTOs.LocalAgent;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.LocalAgents.Requests.Queries
{
    public class GetLocalAgentListRequest : IRequest<PagedResult<LocalAgentDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
