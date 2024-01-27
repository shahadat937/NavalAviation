using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Country : BaseDomainEntity
    {
        public Country()
        {
            CurrencyNames = new HashSet<CurrencyName>();
        }

        public int CountryId { get; set; }
        public int? CountryGroupId { get; set; }
        public int? CurrencyNameId { get; set; }
        public string CountryName { get; set; } = null!;
        public int? CurrentPrice { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CountryGroup? CountryGroup { get; set; }
        public virtual CurrencyName? CurrencyName { get; set; }
        public virtual ICollection<CurrencyName> CurrencyNames { get; set; }
    }
}
