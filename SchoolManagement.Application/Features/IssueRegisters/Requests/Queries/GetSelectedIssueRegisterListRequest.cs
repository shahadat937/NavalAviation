using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Queries
{

    public class GetSelectedIssueRegisterListRequest : IRequest<List<IssueRegisterDto>>
    {
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }
    }
}   
   