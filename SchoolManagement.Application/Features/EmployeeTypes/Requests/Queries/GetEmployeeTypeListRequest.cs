using SchoolManagement.Application.DTOs.EmployeeType;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.EmployeeTypes.Requests.Queries
{
    public class GetEmployeeTypeListRequest : IRequest<PagedResult<EmployeeTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
