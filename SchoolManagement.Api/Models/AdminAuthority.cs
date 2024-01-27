using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AdminAuthority
    {
        public AdminAuthority()
        {
            BaseNames = new HashSet<BaseName>();
        }

        public int AdminAuthorityId { get; set; }
        public string AdminAuthorityName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BaseName> BaseNames { get; set; }
    }
}
