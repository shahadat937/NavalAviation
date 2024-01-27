using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class FiscalYear : BaseDomainEntity
    {
        public FiscalYear()
        {
            Demands = new HashSet<Demand>();
            OccasionOfDemands = new HashSet<OccasionOfDemand>();
        }

        public int FiscalYearId { get; set; }
        public string? FiscalYearName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<OccasionOfDemand> OccasionOfDemands { get; set; }
    }
}
