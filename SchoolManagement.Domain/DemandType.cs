using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DemandType : BaseDomainEntity
    {
        public DemandType()
        {
            Demands = new HashSet<Demand>();
            Procurements = new HashSet<Procurement>();
            Acceptances = new HashSet<Acceptance>();
        }

        public int DemandTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<Acceptance> Acceptances { get; set; }
    }
}
