using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DemandCompleteStatus : BaseDomainEntity
    {
        public int DemandCompleteStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
