using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
  public class GetMaintemanceScheduleListByParamsRequest : IRequest<List<MaintenanceScheduleDto>>
    {
        public int? MaintenanceSubCategoryId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public int? AirCraftNameId { get; set; }  
        public int? DepartmentNameId { get; set; }
        
    } 
}

