using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class GseMaintenanceScheduleName
    {
        public GseMaintenanceScheduleName()
        {
            GseMaintenances = new HashSet<GseMaintenance>();
            GseScheduleWorkTypes = new HashSet<GseScheduleWorkType>();
        }

        public int GseMaintenanceScheduleNameId { get; set; }
        public string ScheduleName { get; set; }
        public string Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ICollection<GseMaintenance> GseMaintenances { get; set; }
        public virtual ICollection<GseScheduleWorkType> GseScheduleWorkTypes { get; set; }
    }
}
