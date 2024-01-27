using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ProcurementStatus
    {
        public ProcurementStatus()
        {
            Acceptances = new HashSet<Acceptance>();
            Procurements = new HashSet<Procurement>();
        }

        public int ProcurementStatusId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
    }
}
