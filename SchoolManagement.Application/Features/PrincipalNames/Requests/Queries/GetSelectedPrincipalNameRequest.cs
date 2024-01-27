using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PrincipalNames.Requests.Queries
{
    public class GetSelectedPrincipalNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
