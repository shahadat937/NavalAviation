using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Division
    {
        public Division()
        {
            BaseNames = new HashSet<BaseName>();
            Districts = new HashSet<District>();
        }

        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BaseName> BaseNames { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
