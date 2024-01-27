namespace SchoolManagement.Application.DTOs.GseScheduleWorkType
{
    public class CreateGseScheduleWorkTypeDto : IGseScheduleWorkTypeDto
    {
        public int GseScheduleWorkTypeId { get; set; }
        public int? GseMaintenanceScheduleNameId { get; set; }
        public string? ScheduleWorkName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }
    }
}
