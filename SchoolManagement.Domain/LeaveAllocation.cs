using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class LeaveAllocation : BaseDomainEntity
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public string? EmployeeId { get; set; }

        public virtual LeaveType LeaveType { get; set; } = null!;
    }
}
