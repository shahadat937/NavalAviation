namespace SchoolManagement.Application.DTOs.GseMaintenance
{
    public class GseMaintenanceDto : IGseMaintenanceDto
    {
        public int GseMaintenanceId { get; set; }
        public int? GseItemNameId { get; set; }
        public int? GseScheduleWorkTypeId { get; set; }
        public int? GseMaintenanceScheduleNameId { get; set; }
        public DateTime? Date { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }

        public string? DepartmentName { get; set; }
        public string? GseItemName { get; set; }
        public string? GseMaintenanceScheduleName { get; set; }
        public string? GseScheduleWorkType { get; set; }
    }
}
