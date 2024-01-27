using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanning;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeRequest : IRequest<List<MaintenancePlanningDto>>
    {
        public int MaintenanceTypeId { get; set; }
        public int AirCraftNameId { get; set; }  
        public int DepartmentNameId { get; set; }
        
    } 
}

 