using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Queries
{
    public class GetIssueRegisterDetailRequest : IRequest<IssueRegisterDto>
    {
        public int IssueRegisterId { get; set; }
    }
}
