using MediatR;
using SchoolManagement.Application.DTOs.IssueStatus;

namespace SchoolManagement.Application.Features.IssueStatuses.Requests.Commands
{
    public class UpdateIssueStatusCommand : IRequest<Unit>
    {
        public IssueStatusDto IssueStatusDto { get; set; }
    }
}
