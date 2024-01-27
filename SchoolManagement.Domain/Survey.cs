using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Survey : BaseDomainEntity
    {
        public Survey()
        {
            
        }

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

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual IssueRegister? IssueRegister { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual ItemCategory? ItemCategory { get; set; }
    }
}
