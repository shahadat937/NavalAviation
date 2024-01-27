using MediatR;
using SchoolManagement.Application.DTOs.DepartmentName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DepartmentNames.Requests.Queries
{
    public class GetDepartmentNameListRequest : IRequest<PagedResult<DepartmentNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
