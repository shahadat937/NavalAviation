using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries
{
    public class GetAirCraftFlyingListRequest : IRequest<PagedResult<AirCraftFlyingDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
