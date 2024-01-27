using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DemandAuthority : BaseDomainEntity
    {
        public DemandAuthority()
        {
            Acceptances = new HashSet<Acceptance>();
            Demands = new HashSet<Demand>();
            StockTransferNsds = new HashSet<StockTransferNsd>();
         }

        public int DemandAuthorityId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<StockTransferNsd> StockTransferNsds { get; set; }
    }
}
