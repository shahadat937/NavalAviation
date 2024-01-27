using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Authority : BaseDomainEntity
    {
        public Authority()
        {
            Demands = new HashSet<Demand>();
        }

        public int AuthorityId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
    }
}
