using MediatR;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Commands
{
    public class DeleteIssueRegisterCommand : IRequest
    {
        public int IssueRegisterId { get; set; }
    }
}
