using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class GseMaintenanceScheduleName : BaseDomainEntity
    {
        public GseMaintenanceScheduleName()
        {
            GseMaintenances = new HashSet<GseMaintenance>();
            GseScheduleWorkTypes = new HashSet<GseScheduleWorkType>();
        }

        public int GseMaintenanceScheduleNameId { get; set; }
        public string? ScheduleName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ICollection<GseMaintenance> GseMaintenances { get; set; }
        public virtual ICollection<GseScheduleWorkType> GseScheduleWorkTypes { get; set; }
    }
}
