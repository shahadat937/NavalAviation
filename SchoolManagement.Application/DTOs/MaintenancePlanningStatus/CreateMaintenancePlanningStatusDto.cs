using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;

namespace SchoolManagement.Application.DTOs.MaintenancePlanningStatus 
{
    public class CreateMaintenancePlanningStatusDto : IMaintenancePlanningStatusDto
    {
        public int MaintenancePlanningStatusId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
 