using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class PresentBillet
    {
        public PresentBillet()
        {
            TrainingCrews = new HashSet<TrainingCrew>();
        }

        public int PresentBilletId { get; set; }
        public string PresentBilletName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
    }
}
