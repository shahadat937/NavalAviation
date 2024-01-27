using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Branch : BaseDomainEntity
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
