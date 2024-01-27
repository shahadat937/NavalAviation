using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Gender : BaseDomainEntity
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
