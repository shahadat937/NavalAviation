using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class MaintenanceCategory : BaseDomainEntity
    {
        public MaintenanceCategory()
        {
            LifeLimitItemRunningHours = new HashSet<LifeLimitItemRunningHour>();
            MaintenancePlannings = new HashSet<MaintenancePlanning>();
            MaintenanceSubCategories = new HashSet<MaintenanceSubCategory>();
            MaintenanceSchedules = new HashSet<MaintenanceSchedule>();
            RequiredSparesForMaintenances = new HashSet<RequiredSparesForMaintenance>();
        }

        public int MaintenanceCategoryId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public string? CategoryName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }

        public virtual MaintenanceType? MaintenanceType { get; set; }
        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ICollection<LifeLimitItemRunningHour> LifeLimitItemRunningHours { get; set; }
        public virtual ICollection<MaintenancePlanning> MaintenancePlannings { get; set; }
        public virtual ICollection<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
        public virtual ICollection<MaintenanceSubCategory> MaintenanceSubCategories { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
    }
}
