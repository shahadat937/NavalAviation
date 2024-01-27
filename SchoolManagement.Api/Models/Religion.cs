using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Religion
    {
        public Religion()
        {
            Castes = new HashSet<Caste>();
        }

        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Caste> Castes { get; set; }
    }
}
