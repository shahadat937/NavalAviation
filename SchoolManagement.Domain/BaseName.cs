using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class BaseName : BaseDomainEntity
    {
        public int BaseNameId { get; set; }
        public int AdminAuthorityId { get; set; }
        public int DivisionId { get; set; }
        public int? DistrictId { get; set; }
        public int? ForceTypeId { get; set; }
        public string BaseNames { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? BaseLogo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual AdminAuthority AdminAuthority { get; set; } = null!;
        public virtual District? District { get; set; }
        public virtual Division Division { get; set; } = null!;
        public virtual ForceType? ForceType { get; set; }
    }
}
