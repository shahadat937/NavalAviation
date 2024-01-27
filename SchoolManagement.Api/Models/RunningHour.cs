using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class RunningHour
    {
        public int RunningHourId { get; set; }
        public int? AirCraftNameId { get; set; }
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

        public virtual AirCraftName AirCraftName { get; set; }
        public virtual BaseSchoolName DepartmentName { get; set; }
    }
}
