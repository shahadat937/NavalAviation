using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class CountryGroup : BaseDomainEntity
    {
        public CountryGroup()
        {
            Countries = new HashSet<Country>();
        }

        public int CountryGroupId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
