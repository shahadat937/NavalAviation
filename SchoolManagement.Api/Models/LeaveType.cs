using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            LeaveAllocations = new HashSet<LeaveAllocation>();
            LeaveRequests = new HashSet<LeaveRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual ICollection<LeaveAllocation> LeaveAllocations { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
