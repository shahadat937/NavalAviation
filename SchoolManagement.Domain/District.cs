using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class District : BaseDomainEntity
    {
        public District()
        {
            BaseNames = new HashSet<BaseName>();
            Thanas = new HashSet<Thana>();
        }

        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public string DistrictName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Division Division { get; set; } = null!;
        public virtual ICollection<BaseName> BaseNames { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
    }
}
