using MediatR;
using SchoolManagement.Application.DTOs.RunningHour;

namespace SchoolManagement.Application.Features.RunningHours.Requests.Queries
{
    public class GetRunningHourListByDepartmentAndAirCraftNameRequest : IRequest<List<RunningHourDto>>
    {
        public int AirCraftNameId { get; set; }  
        public int DepartmentNameId { get; set; }
    } 
}

 