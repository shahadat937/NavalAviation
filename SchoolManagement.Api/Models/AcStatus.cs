using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AcStatus
    {
        public int AcStatusId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? StatusId { get; set; }
        public string ExcepRelease { get; set; }
        public string UpcomingMaint { get; set; }
        public DateTime? PlannedDate { get; set; }
        public string RequiredDays { get; set; }
        public string Remarks { get; set; }
        public int? AircraftStatusCheck { get; set; }
        public int? CompletedStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual AirCraftName AirCraftName { get; set; }
        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual Status Status { get; set; }
    }
}
