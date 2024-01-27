using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DemandDoc : BaseDomainEntity
    {
        public DemandDoc()
        {
            Demands = new HashSet<Demand>();
        }

        public int DemandDocId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
    }
}
