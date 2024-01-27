using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Attendence
{
    public class CreateAttendenceDto : IAttendenceDto
    {
        public int AttendenceId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? TrainingCrewId { get; set; }
        public DateTime? AttendenceDate { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
