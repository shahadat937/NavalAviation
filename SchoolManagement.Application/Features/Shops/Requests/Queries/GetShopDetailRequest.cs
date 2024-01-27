using SchoolManagement.Application.DTOs.Shop;
using MediatR;

namespace SchoolManagement.Application.Features.Shops.Requests.Queries
{
    public class GetShopDetailRequest : IRequest<ShopDto>
    {
        public int ShopId { get; set; }
    }
}
