using MediatR;
using SchoolManagement.Application.DTOs.IssueStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.IssueStatuses.Requests.Commands
{
    public class CreateIssueStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateIssueStatusDto IssueStatusDto { get; set; }
    }
}
