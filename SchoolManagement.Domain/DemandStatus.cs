using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DemandStatus : BaseDomainEntity
    {
        public DemandStatus()
        {
            Demands = new HashSet<Demand>();
        }

        public int DemandStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
    }
}
