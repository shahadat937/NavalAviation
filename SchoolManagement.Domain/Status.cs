using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Status : BaseDomainEntity
    {
        public Status()
        {
            AcStatuses = new HashSet<AcStatus>();
            
        }

        public int StatusId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AcStatus> AcStatuses { get; set; }
    }
}
