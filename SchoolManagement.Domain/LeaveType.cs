using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class LeaveType : BaseDomainEntity
    {
        public LeaveType()
        {
            LeaveAllocations = new HashSet<LeaveAllocation>();
            LeaveRequests = new HashSet<LeaveRequest>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int DefaultDays { get; set; }

        public virtual ICollection<LeaveAllocation> LeaveAllocations { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
