using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Division : BaseDomainEntity
    {
        public Division()
        {
            BaseNames = new HashSet<BaseName>();
            Districts = new HashSet<District>();
        }

        public int DivisionId { get; set; }
        public string DivisionName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BaseName> BaseNames { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
