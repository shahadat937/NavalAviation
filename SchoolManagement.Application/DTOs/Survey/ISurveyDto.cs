using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Survey
{
    public interface ISurveyDto
    {
        public int SurveyId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? IssueRegisterId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? SurveyQty { get; set; }
        public int? IssueQty { get; set; }
        public string? SurveyNumber { get; set; }
        public DateTime? SurveyDate { get; set; }
        public bool IsActive { get; set; }
     } 
}
