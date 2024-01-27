using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Manufacture : BaseDomainEntity
    {
        public Manufacture()
        {
            Acceptances = new HashSet<Acceptance>();
            Procurements = new HashSet<Procurement>();
            Demands = new HashSet<Demand>();
        }

        public int ManufactureId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
    }
}
