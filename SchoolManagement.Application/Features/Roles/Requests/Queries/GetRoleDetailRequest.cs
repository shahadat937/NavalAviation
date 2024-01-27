using MediatR;
using SchoolManagement.Application.DTOs.Role;

namespace SchoolManagement.Application.Features.Roles.Requests.Queries
{
    public class GetRoleDetailRequest : IRequest<RoleDto>
    {
        public int RoleId { get; set; }
    }
}
