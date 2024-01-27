using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class MaritalStatus : BaseDomainEntity
    {
        public int MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
