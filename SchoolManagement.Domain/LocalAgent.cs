using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class LocalAgent : BaseDomainEntity
    {
        public LocalAgent()
        {
            Procurements = new HashSet<Procurement>();
        }

        public int LocalAgentId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Procurement> Procurements { get; set; }
    }
}
