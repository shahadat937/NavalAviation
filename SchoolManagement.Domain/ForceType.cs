using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ForceType : BaseDomainEntity
    {
        public ForceType()
        {
            BaseNames = new HashSet<BaseName>();
        }

        public int ForceTypeId { get; set; }
        public string ForceTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BaseName> BaseNames { get; set; }
    }
}
