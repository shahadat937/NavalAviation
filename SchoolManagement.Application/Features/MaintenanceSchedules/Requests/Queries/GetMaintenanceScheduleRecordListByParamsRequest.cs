using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
    public class GetMaintenanceScheduleRecordListByParamsRequest : IRequest<object>
  {
        public int DepartmentNameId { get; set; }  
        public int AirCraftNameId { get; set; }
        public int MaintenanceTypeId { get; set; }
        public int MaintenanceCategoryId { get; set; }
        public int MaintenanceSubCategoryId { get; set; }
    } 
}

