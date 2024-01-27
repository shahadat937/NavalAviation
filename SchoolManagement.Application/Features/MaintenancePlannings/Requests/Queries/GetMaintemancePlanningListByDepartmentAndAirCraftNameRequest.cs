using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanning;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetMaintemancePlanningListByDepartmentAndAirCraftNameRequest : IRequest<List<MaintenancePlanningDto>>
    {
        public int AirCraftNameId { get; set; }  
        public int DepartmentNameId { get; set; }
    } 
}

 