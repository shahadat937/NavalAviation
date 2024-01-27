using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries
{
    public class GetDailyAirworthinessFromCategoryListByDepartmentNameIdRequest : IRequest<List<DailyAirworthinessFromCategoryDto>>
    {
        
        public int DepartmentNameId { get; set; }
    } 
}

