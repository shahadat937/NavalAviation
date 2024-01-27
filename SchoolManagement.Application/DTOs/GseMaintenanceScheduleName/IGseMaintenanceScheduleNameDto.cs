namespace SchoolManagement.Application.DTOs.GseMaintenanceScheduleName
{
    public interface IGseMaintenanceScheduleNameDto
    {
        public int GseMaintenanceScheduleNameId { get; set; }
        public string? ScheduleName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }
    } 
}
