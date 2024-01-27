using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MeaWorkShops.Requests.Queries
{
    public class GetSelectedMeaWorkShopRequest : IRequest<List<SelectedModel>>
    {
    }
}
