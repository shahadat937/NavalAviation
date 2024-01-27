using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ItemInspection : BaseDomainEntity
    {
        public ItemInspection()
        {
            Acceptances = new HashSet<Acceptance>();
        }

        public int ItemInspectionId { get; set; }
        public string? Name { get; set; } 
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
    }
}
