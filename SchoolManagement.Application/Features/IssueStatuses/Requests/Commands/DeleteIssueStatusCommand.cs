using MediatR;

namespace SchoolManagement.Application.Features.IssueStatuses.Requests.Commands
{
    public class DeleteIssueStatusCommand : IRequest
    {
        public int IssueStatusId { get; set; }
    }
}
