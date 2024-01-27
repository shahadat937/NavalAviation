using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Shops.Requests.Queries
{
    public class GetSelectedShopRequest : IRequest<List<SelectedModel>>
    {
    }
}
