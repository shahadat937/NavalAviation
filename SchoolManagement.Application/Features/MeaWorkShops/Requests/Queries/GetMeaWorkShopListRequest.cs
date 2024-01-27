using MediatR;
using SchoolManagement.Application.DTOs.MeaWorkShop;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MeaWorkShops.Requests.Queries
{
    public class GetMeaWorkShopListRequest : IRequest<PagedResult<MeaWorkShopDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
