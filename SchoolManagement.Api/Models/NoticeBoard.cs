using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class NoticeBoard
    {
        public int NoticeBoardId { get; set; }
        public int? DepartmentNameId { get; set; }
        public DateTime? Date { get; set; }
        public string Event { get; set; }
        public string OrderBy { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string NoticeDocument { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
    }
}
