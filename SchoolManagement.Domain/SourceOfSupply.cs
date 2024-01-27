using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class SourceOfSupply : BaseDomainEntity
    {
        public SourceOfSupply()
        {
            Acceptances = new HashSet<Acceptance>();
        }

        public int SourceOfSupplyId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
    }
}
