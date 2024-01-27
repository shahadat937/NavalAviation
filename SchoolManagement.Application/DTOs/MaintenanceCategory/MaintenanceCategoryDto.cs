namespace SchoolManagement.Application.DTOs.MaintenanceCategory
{
    public class MaintenanceCategoryDto : IMaintenanceCategoryDto
    {
        public int MaintenanceCategoryId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public string? CategoryName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }
        public string? DepartmentName { get; set; }
        public string? MaintenanceType { get; set; }
    }
}
