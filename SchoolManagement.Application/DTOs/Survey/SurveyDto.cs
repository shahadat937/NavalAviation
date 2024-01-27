using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Survey
{
    public class SurveyDto : ISurveyDto
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

        public string? DepartmentName { get; set; }
        public string? PattNo { get; set; }
        public string? ItemName { get; set; }
        public string? IMC { get; set; }
        public string? ItemCategory { get; set; }
    }
}
