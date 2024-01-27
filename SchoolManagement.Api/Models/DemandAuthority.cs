using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DemandAuthority
    {
        public DemandAuthority()
        {
            Acceptances = new HashSet<Acceptance>();
            Demands = new HashSet<Demand>();
            StockTransferNsds = new HashSet<StockTransferNsd>();
        }

        public int DemandAuthorityId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<StockTransferNsd> StockTransferNsds { get; set; }
    }
}
