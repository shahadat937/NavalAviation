using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenanceSubCategory
{
    public class MaintenanceSubCategoryDto : IMaintenanceSubCategoryDto
    {
        public int MaintenanceSubCategoryId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? TotalDaysCount { get; set; }
        public string? SubCategoryName { get; set; }
        public string? AllowedExtension { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public string? MaintenanceCategory { get; set; }
        public string? DepartmentName { get; set; }
        public string? MaintenanceType { get; set; }
    }
}
