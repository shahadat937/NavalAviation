using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Status
    {
        public Status()
        {
            AcStatuses = new HashSet<AcStatus>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AcStatus> AcStatuses { get; set; }
    }
}
