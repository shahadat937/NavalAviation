using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries
{
    public class GetDailyAirworthinessFromListRequest : IRequest<PagedResult<DailyAirworthinessFromDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
