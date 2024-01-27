using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class GseMaintenance
    {
        public int GseMaintenanceId { get; set; }
        public int? GseItemNameId { get; set; }
        public int? GseScheduleWorkTypeId { get; set; }
        public int? GseMaintenanceScheduleNameId { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual GseItemName GseItemName { get; set; }
        public virtual GseMaintenanceScheduleName GseMaintenanceScheduleName { get; set; }
        public virtual GseScheduleWorkType GseScheduleWorkType { get; set; }
    }
}
