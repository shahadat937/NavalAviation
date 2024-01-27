using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class FailureStatus : BaseDomainEntity
    {
        public int FailureStatusId { get; set; }
        public string FailureStatusName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
