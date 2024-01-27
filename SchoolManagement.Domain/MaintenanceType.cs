using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class MaintenanceType : BaseDomainEntity
    {
        public MaintenanceType()
        {
            MaintenancePlannings = new HashSet<MaintenancePlanning>();
            MaintenanceCategories = new HashSet<MaintenanceCategory>();
            MaintenanceSchedules = new HashSet<MaintenanceSchedule>();
            MaintenanceSubCategories = new HashSet<MaintenanceSubCategory>();
            RequiredSparesForMaintenances = new HashSet<RequiredSparesForMaintenance>();
        }

        public int MaintenanceTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ICollection<MaintenancePlanning> MaintenancePlannings { get; set; }
        public virtual ICollection<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
        public virtual ICollection<MaintenanceCategory> MaintenanceCategories { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<MaintenanceSubCategory> MaintenanceSubCategories { get; set; }
  }
}
