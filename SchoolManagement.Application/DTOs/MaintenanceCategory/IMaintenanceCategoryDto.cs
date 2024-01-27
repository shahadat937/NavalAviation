namespace SchoolManagement.Application.DTOs.MaintenanceCategory
{
    public interface IMaintenanceCategoryDto
    {
        public int MaintenanceCategoryId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public string? CategoryName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }
    } 
}
