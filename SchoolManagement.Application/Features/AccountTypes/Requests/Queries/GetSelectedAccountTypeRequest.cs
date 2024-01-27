using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AccountTypes.Requests.Queries
{
    public class GetSelectedAccountTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
