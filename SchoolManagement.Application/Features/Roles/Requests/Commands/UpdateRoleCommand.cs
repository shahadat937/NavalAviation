using MediatR;
using SchoolManagement.Application.DTOs.Role;

namespace SchoolManagement.Application.Features.Roles.Requests.Commands
{
    public class UpdateRoleCommand : IRequest<Unit>
    {
        public RoleDto RoleDto { get; set; } 
    }
}
