using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Thana : BaseDomainEntity
    {
        public int ThanaId { get; set; }
        public int DistrictId { get; set; }
        public string ThanaName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual District District { get; set; } = null!;
    }
}
