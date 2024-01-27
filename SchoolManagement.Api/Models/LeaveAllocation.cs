using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class LeaveAllocation
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual LeaveType LeaveType { get; set; }
    }
}
