using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Attendence : BaseDomainEntity
    {
        public Attendence()
        { 
            
        }
     
        public int AttendenceId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? TrainingCrewId { get; set; }
        public DateTime? AttendenceDate { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public bool AttendanceStatus { get; set; }
        public int? OfficersStatusId { get; set; }

       public virtual BaseSchoolName? DepartmentName { get; set; }
       public virtual TrainingCrew? TrainingCrew { get; set; }


    }
}
