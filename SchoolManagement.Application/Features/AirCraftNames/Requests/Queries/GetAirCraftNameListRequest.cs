using MediatR;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Queries
{
    public class GetAirCraftNameListRequest : IRequest<PagedResult<AirCraftNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
