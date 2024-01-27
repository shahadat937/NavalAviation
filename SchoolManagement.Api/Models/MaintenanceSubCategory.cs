using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MaintenanceSubCategory
    {
        public MaintenanceSubCategory()
        {
            MaintenancePlannings = new HashSet<MaintenancePlanning>();
            MaintenanceSchedules = new HashSet<MaintenanceSchedule>();
            RequiredSparesForMaintenances = new HashSet<RequiredSparesForMaintenance>();
        }

        public int MaintenanceSubCategoryId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? TotalDaysCount { get; set; }
        public string SubCategoryName { get; set; }
        public string AllowedExtension { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual MaintenanceCategory MaintenanceCategory { get; set; }
        public virtual MaintenanceType MaintenanceType { get; set; }
        public virtual ICollection<MaintenancePlanning> MaintenancePlannings { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
    }
}
