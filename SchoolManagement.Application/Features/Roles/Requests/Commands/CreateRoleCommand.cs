using MediatR;
using SchoolManagement.Application.DTOs.Role;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Roles.Requests.Commands
{
    public class CreateRoleCommand : IRequest<BaseCommandResponse>
    {
        public CreateRoleDto RoleDto { get; set; } 

    }
}
