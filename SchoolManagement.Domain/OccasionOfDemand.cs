using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class OccasionOfDemand : BaseDomainEntity
    {
        public OccasionOfDemand()
        {
            Demands = new HashSet<Demand>();
        }

        public int OccasionOfDemandId { get; set; }
        public string? Name { get; set; }
        public int? FiscalYearId { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
        public virtual FiscalYear? FiscalYear { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
    }
}
