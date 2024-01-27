using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Authority
    {
        public Authority()
        {
            Demands = new HashSet<Demand>();
        }

        public int AuthorityId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
    }
}
