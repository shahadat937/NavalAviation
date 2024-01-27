using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Roles.Requests.Queries
{
    public class GetSelectedRoleRequest : IRequest<List<SelectedModel>>
    {
    }
}
