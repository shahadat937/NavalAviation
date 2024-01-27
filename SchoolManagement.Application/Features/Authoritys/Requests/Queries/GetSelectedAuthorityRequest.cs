using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Authoritys.Requests.Queries
{
    public class GetSelectedAuthorityRequest : IRequest<List<SelectedModel>>
    {
    }
}
