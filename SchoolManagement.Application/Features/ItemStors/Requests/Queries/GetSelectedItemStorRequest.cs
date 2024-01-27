using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetSelectedItemStorRequest : IRequest<List<SelectedModel>>
    {
    }
}
