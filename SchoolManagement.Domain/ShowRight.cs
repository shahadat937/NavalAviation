using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ShowRight : BaseDomainEntity
    {
        public int ShowRightId { get; set; }
        public string? ShowRightName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
