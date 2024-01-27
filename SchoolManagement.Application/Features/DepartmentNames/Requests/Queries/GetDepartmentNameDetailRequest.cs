using MediatR;
using SchoolManagement.Application.DTOs.DepartmentName;

namespace SchoolManagement.Application.Features.DepartmentNames.Requests.Queries
{
    public class GetDepartmentNameDetailRequest : IRequest<DepartmentNameDto>
    {
        public int DepartmentNameId { get; set; }
    }
}
