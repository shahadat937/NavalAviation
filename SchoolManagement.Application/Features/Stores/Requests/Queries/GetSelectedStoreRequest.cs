using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Stores.Requests.Queries
{
    public class GetSelectedStoreRequest : IRequest<List<SelectedModel>>
    {
    }
}
