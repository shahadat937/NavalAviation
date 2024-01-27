using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Religion : BaseDomainEntity
    {
        public Religion()
        {
            Castes = new HashSet<Caste>();
        }

        public int ReligionId { get; set; }
        public string ReligionName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Caste> Castes { get; set; }
    }
}
