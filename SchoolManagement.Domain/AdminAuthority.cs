using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class AdminAuthority : BaseDomainEntity
    {
        public AdminAuthority()
        {
            BaseNames = new HashSet<BaseName>();
        }

        public int AdminAuthorityId { get; set; }
        public string AdminAuthorityName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BaseName> BaseNames { get; set; }
    }
}
