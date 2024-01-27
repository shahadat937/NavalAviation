using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Survey
    {
        public int SurveyId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? IssueRegisterId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? SurveyQty { get; set; }
        public int? IssueQty { get; set; }
        public string SurveyNumber { get; set; }
        public DateTime? SurveyDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual IssueRegister IssueRegister { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemDetail ItemDetail { get; set; }
    }
}
