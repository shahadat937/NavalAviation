using MediatR;
using SchoolManagement.Application.DTOs.IssueStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.IssueStatuses.Requests.Queries
{
    public class GetIssueStatusListRequest : IRequest<PagedResult<IssueStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
