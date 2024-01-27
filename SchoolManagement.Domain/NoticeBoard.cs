using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public class NoticeBoard:BaseDomainEntity
    {
        public int NoticeBoardId { get; set; }
        public int? DepartmentNameId { get; set; }
        public DateTime? Date { get; set; }
        public string? Event { get; set; }
        public string? OrderBy { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public string? NoticeDocument { get; set; } 
        public virtual BaseSchoolName? DepartmentName { get; set; }
    }
}
