using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries
{
    public class GetDailyAirworthinessFromCategoryDetailRequest : IRequest<DailyAirworthinessFromCategoryDto>
    {
        public int DailyAirworthinessFromCategoryId { get; set; }
    }
}
