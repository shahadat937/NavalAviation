using MediatR;
using SchoolManagement.Application.DTOs.IssueStatus;

namespace SchoolManagement.Application.Features.IssueStatuses.Requests.Queries
{
    public class GetIssueStatusDetailRequest : IRequest<IssueStatusDto>
    {
        public int IssueStatusId { get; set; }
    }
}
