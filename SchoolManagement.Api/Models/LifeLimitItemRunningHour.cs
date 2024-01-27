using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class LifeLimitItemRunningHour
    {
        public int LifeLimitItemRunningHourId { get; set; }
        public int? LifeLimitItemId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? ItemDetailId { get; set; }
        public string SlNo { get; set; }
        public DateTime? FlightDate { get; set; }
        public string FlightTimeHr { get; set; }
        public string FlightTimeMin { get; set; }
        public int? DepartmentNameId { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ItemDetail ItemDetail { get; set; }
        public virtual LifeLimitItem LifeLimitItem { get; set; }
        public virtual MaintenanceCategory MaintenanceCategory { get; set; }
    }
}
