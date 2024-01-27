using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries
{
    public class GetDailyAirworthinessFromCategoryListRequest : IRequest<PagedResult<DailyAirworthinessFromCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
