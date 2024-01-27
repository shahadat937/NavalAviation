using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class NameofPublication : BaseDomainEntity
    {
        public NameofPublication()
        {
             ArchivingforPublications = new HashSet<ArchivingforPublication>();
            
        }

        public int NameofPublicationId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Name { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }

       public virtual ICollection<ArchivingforPublication> ArchivingforPublications { get; set; }
    }
}
