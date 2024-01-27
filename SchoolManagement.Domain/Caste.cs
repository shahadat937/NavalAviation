using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Caste : BaseDomainEntity
    {
        public int CasteId { get; set; }
        public int ReligionId { get; set; }
        public string CastName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Religion Religion { get; set; } = null!;
    }
}
