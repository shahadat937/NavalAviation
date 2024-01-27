using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class RunningHour : BaseDomainEntity
    {
        public int RunningHourId { get; set; }
        public int? AirCraftNameId { get; set; }
        public DateTime? FlightDate { get; set; }
        public string? FlightTimeHr { get; set; }
        public string? FlightTimeMin { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual AirCraftName? AirCraftName { get; set; }
        public virtual BaseSchoolName? DepartmentName { get; set; }
    }
}
