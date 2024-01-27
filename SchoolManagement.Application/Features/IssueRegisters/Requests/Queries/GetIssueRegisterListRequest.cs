using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Queries
{
    public class GetIssueRegisterListRequest : IRequest<PagedResult<IssueRegisterDto>>
    {
        public QueryParams QueryParams { get; set; }
        //public string PNo { get; set; }

    }
}
