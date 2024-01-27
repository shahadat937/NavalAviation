using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ShowRight
    {
        public int ShowRightId { get; set; }
        public string ShowRightName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
