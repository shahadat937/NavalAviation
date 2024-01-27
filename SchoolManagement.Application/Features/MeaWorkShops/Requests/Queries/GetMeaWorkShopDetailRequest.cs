using MediatR;
using SchoolManagement.Application.DTOs.MeaWorkShop;

namespace SchoolManagement.Application.Features.MeaWorkShops.Requests.Queries
{
    public class GetMeaWorkShopDetailRequest : IRequest<MeaWorkShopDto>
    {
        public int MeaWorkShopId { get; set; }
    }
}
