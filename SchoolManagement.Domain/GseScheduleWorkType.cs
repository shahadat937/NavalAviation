using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class GseScheduleWorkType : BaseDomainEntity
    {
        public GseScheduleWorkType()
        {
            GseMaintenances = new HashSet<GseMaintenance>();
        }

        public int GseScheduleWorkTypeId { get; set; }
        public int? GseMaintenanceScheduleNameId { get; set; }
        public string? ScheduleWorkName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual GseMaintenanceScheduleName? GseMaintenanceScheduleName { get; set; }
        public virtual ICollection<GseMaintenance> GseMaintenances { get; set; }
    }
}
