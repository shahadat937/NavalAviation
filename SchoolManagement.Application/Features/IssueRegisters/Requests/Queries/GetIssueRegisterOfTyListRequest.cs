using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Queries
{

    public class GetIssueRegisterOfTyListRequest : IRequest<List<IssueRegisterDto>>
    {
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }
        public int IssueStatusId { get; set; }
    }
}   
