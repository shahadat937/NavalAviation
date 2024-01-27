using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanning;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategoryRequest : IRequest<List<MaintenancePlanningDto>>
    {
        public int MaintenanceSubCategoryId { get; set; }
        public int MaintenanceCategoryId { get; set; }
        public int MaintenanceTypeId { get; set; }
        public int AirCraftNameId { get; set; }  
        public int DepartmentNameId { get; set; }
        
    } 
}

 