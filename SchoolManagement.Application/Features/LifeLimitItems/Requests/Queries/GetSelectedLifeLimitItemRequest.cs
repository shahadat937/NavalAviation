using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.LifeLimitItems.Requests.Queries
{
    public class GetSelectedLifeLimitItemRequest : IRequest<List<SelectedModel>>
    {
    }
}
