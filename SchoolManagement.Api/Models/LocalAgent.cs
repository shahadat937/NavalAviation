using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class LocalAgent
    {
        public LocalAgent()
        {
            Procurements = new HashSet<Procurement>();
        }

        public int LocalAgentId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Procurement> Procurements { get; set; }
    }
}
