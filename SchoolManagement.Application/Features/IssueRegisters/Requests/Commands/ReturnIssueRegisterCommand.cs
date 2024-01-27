using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Commands
{
    public class ReturnIssueRegisterCommand : IRequest<Unit>
    {
        public ReturnIssueRegisterDto ReturnIssueRegisterDto { get; set; }
    }
} 
