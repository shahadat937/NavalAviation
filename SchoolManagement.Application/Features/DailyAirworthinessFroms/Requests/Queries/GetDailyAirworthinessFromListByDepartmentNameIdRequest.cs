using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries
{
    public class GetDailyAirworthinessFromListByDepartmentNameIdRequest : IRequest<List<DailyAirworthinessFromDto>>
    {
        
        public int DepartmentNameId { get; set; }
        public int DocType { get; set; }
    } 
}

