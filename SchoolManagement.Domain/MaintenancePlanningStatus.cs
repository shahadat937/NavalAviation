using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class MaintenancePlanningStatus : BaseDomainEntity
    {
        public MaintenancePlanningStatus()
        {
            MaintenancePlannings = new HashSet<MaintenancePlanning>();
            MaintenanceSchedules = new HashSet<MaintenanceSchedule>();
        }

        public int MaintenancePlanningStatusId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MaintenancePlanning> MaintenancePlannings { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
    }
}
