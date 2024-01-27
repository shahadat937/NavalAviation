using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MaritalStatus
    {
        public int MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
