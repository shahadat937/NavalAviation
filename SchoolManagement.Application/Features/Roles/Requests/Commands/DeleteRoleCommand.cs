using MediatR;

namespace SchoolManagement.Application.Features.Roles.Requests.Commands
{
    public class DeleteRoleCommand : IRequest
    {
        public int RoleId { get; set; }
    }
}
