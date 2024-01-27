using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class NameofPublication
    {
        public NameofPublication()
        {
            ArchivingforPublications = new HashSet<ArchivingforPublication>();
        }

        public int NameofPublicationId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ICollection<ArchivingforPublication> ArchivingforPublications { get; set; }
    }
}
