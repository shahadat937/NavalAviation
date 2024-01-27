using MediatR;
using SchoolManagement.Application.DTOs.Role;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Roles.Requests.Queries
{
    public class GetRoleListRequest : IRequest<PagedResult<RoleDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
