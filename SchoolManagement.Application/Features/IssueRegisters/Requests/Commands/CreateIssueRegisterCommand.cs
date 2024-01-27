using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister.MultipleInsertDto;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Commands
{
    public class CreateIssueRegisterCommand : IRequest<BaseCommandResponse>
    {
        public CreateIssueRegisterDto IssueRegisterDto { get; set; }
    }
}
