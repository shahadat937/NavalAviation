using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DegitalArchieveDocType : BaseDomainEntity
    {
        public DegitalArchieveDocType()
        {
            DegitalArchieves = new HashSet<DegitalArchieve>();
        }
        public int DegitalArchieveDocTypeId { get; set; }
        public string? Name { get; set; } 
        public string? Remarks { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<DegitalArchieve> DegitalArchieves { get; set; }
  }
}
