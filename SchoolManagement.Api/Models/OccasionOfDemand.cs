using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class OccasionOfDemand
    {
        public OccasionOfDemand()
        {
            Demands = new HashSet<Demand>();
        }

        public int OccasionOfDemandId { get; set; }
        public string Name { get; set; }
        public int? FiscalYearId { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual FiscalYear FiscalYear { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
    }
}
