using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public string? RequestingEmployeeId { get; set; }

        public virtual LeaveType LeaveType { get; set; } = null!;
    }
}
