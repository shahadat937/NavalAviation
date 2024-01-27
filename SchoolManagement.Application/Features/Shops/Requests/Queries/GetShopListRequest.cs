using SchoolManagement.Application.DTOs.Shop;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Shops.Requests.Queries
{
    public class GetShopListRequest : IRequest<PagedResult<ShopDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
