using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Commands
{
    public class UpdateIssueRegisterCommand : IRequest<Unit>
    {
        public IssueRegisterDto IssueRegisterDto { get; set; }
    }
}
