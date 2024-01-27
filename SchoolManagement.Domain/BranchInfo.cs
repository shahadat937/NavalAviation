using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class BranchInfo :BaseDomainEntity
    {
        public BranchInfo()
        {
            Users = new HashSet<User>();
        }

        public int BranchInfoId { get; set; }
        public string BranchCode { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string ContactPerson { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Telephone { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public long? CountryCode { get; set; }
        public long? ZoneInfoIdentity { get; set; }
        public string BranchLevel { get; set; } = null!;
        public string FirstLevel { get; set; } = null!;
        public string SecondLevel { get; set; } = null!;
        public string ThirdLevel { get; set; } = null!;
        public string? FourthLevel { get; set; }
        public string? FifthLevel { get; set; }
        public string BranchType { get; set; } = null!;
        public string? NativeBranchCode { get; set; }
        public long? CurrencyCode { get; set; }
        public string? OwnBranchCode { get; set; }
        public int? UserId { get; set; }
        public string? ServerName { get; set; }
        public string? AccountNoFc { get; set; }
        public string? AccountNoLc { get; set; }
        public decimal? MinimumCoverFund { get; set; }
        public byte? WorkingTimeFrom { get; set; }
        public byte? WorkingTimeTo { get; set; }
        public decimal? MinimumNrdbalance { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
