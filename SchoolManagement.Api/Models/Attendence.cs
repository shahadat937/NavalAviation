using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Attendence
    {
        public int AttendenceId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? TrainingCrewId { get; set; }
        public int? OfficersStatusId { get; set; }
        public bool? AttendanceStatus { get; set; }
        public DateTime? AttendenceDate { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual TrainingCrew TrainingCrew { get; set; }
    }
}
